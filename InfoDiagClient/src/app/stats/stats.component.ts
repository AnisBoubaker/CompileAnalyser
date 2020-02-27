import { Component, OnInit, Input } from "@angular/core";
import { Stats } from "../generic/models/stats"

@Component({
  selector: "app-stats",
  templateUrl: "./stats.component.html",
  styleUrls: ["./stats.component.css"]
})
export class StatsComponent implements OnInit {
  @Input() stats: Stats[] = [];

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
    toUse.lines = toUse.lines.filter(
      val => !this.display.includes(val)
    );
    this.display.forEach(element => {
      element.subs = toUse.lines.filter(
        val => val.type === element.type
      );
    });
  }

  changeBeginnig(from: string) {

  }

  changeEnd(to: string) {}

  concat(toConcat: Stats[]): Stats {
    const concated: Stats = toConcat[0];

    toConcat.forEach((tc,i) => {
      if (i != 0) {
        tc.lines.forEach(l => {
          const temp = concated.lines.find(l1 => l1.name === l.name)
          if (temp) {
            temp.nbOccurence += l.nbOccurence;
          } else {
            concated.lines.push(l);
          }
        })
      }
    });

    return concated;
  }

  goto(link: string) {
    window.open(link, '_blank');
  }
}
