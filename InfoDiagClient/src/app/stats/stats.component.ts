import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-stats",
  templateUrl: "./stats.component.html",
  styleUrls: ["./stats.component.css"]
})
export class StatsComponent implements OnInit {
  @Input() stats: any = [];

  panelOpenState = false;
  display: any = [];
  localStats: any;
  constructor() {}

  ngOnInit() {
    this.localStats = JSON.parse(JSON.stringify(this.stats));
    this.createDisplay();
    this.removeDisplayFromStats();
    this.addCorresponding();
    console.log(this.display);
  }
  createDisplay() {
    this.localStats.lines.forEach(element => {
      if (!element.isErrorCode) {
        this.display.push(element);
      }
    });
  }
  removeDisplayFromStats() {
    this.localStats.lines = this.localStats.lines.filter(
      val => !this.display.includes(val)
    );
  }
  addCorresponding() {
    this.display.forEach(element => {
      element.subs = this.localStats.lines.filter(
        val => val.type === element.type
      );
    });
  }
}
