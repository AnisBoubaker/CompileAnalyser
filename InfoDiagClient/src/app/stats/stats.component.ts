import { Component, OnInit, Input } from "@angular/core";
import { Stats } from "../generic/models/stats";
import { ErrorCategory } from "../generic/models/errorCategory";

@Component({
  selector: "app-stats",
  templateUrl: "./stats.component.html",
  styleUrls: ["./stats.component.css"]
})
export class StatsComponent implements OnInit {
  @Input() stats: Stats[] = [];
  @Input() errorCategories: ErrorCategory[] = [];
  panelOpenState = false;
  display: any = [];
  constructor() {}

  ngOnInit() {
    this.createDisplay(this.concat(this.stats));
  }

  createDisplay(toUse) {
    toUse.lines.forEach(element => {
      if (!element.isErrorCode) {
        this.display.push(element);
      }
    });
    toUse.lines = toUse.lines.filter(val => !this.display.includes(val));
    this.display.forEach(element => {
      const content = toUse.lines.filter(val => val.type === element.type);
      const subs = [{name: "Autres", id: -1, subsub: [], nbOccurence: 0}]
      content.forEach(l => {
        const cat = this.errorCategories.find(v => v.relatedErrors.includes(l.errorCodeId));
        const where = cat ? subs.find(s => s.id == cat.id) : subs.find(s => s.id == -1);
        if(subs.length != 0 && cat && !where) {
          subs.push({name: cat.name, id: Number(cat.id), subsub: [l], nbOccurence: l.nbOccurence})
        } else {
          where.subsub.push(l);
          where.nbOccurence += l.nbOccurence;
        }
      });
      element.subs = subs.sort((a, b) => b.nbOccurence - a.nbOccurence);
    });
  }

  changeBeginnig(from: string) {}

  changeEnd(to: string) {}

  concat(toConcat: Stats[]): Stats {
    const concated: Stats = toConcat[0];

    toConcat.forEach((tc, i) => {
      if (i != 0) {
        tc.lines.forEach(l => {
          const temp = concated.lines.find(l1 => l1.name === l.name);
          if (temp) {
            temp.nbOccurence += l.nbOccurence;
          } else {
            concated.lines.push(l);
          }
        });
      }
    });

    return concated;
  }

  goto(link: string) {
    window.open(link, "_blank");
  }
}
