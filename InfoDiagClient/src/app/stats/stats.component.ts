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
    this.createDisplay(JSON.parse(JSON.stringify(this.stats)));
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
}
