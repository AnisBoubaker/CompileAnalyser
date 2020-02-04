import { Component, OnInit, Input } from "@angular/core";
import { StudentComponent } from "../student/student.component";

@Component({
  selector: "app-stats",
  templateUrl: "./stats.component.html",
  styleUrls: ["./stats.component.css"]
})
export class StatsComponent implements OnInit {
  panelOpenState = false;
  @Input() stats: any = [];
  constructor() {}
  ngOnInit() {}
  displayStats() {
    console.log(this.stats);
    let line = this.stats.lines;
    line.forEach(element => {
      console.log(element.nbOccurence);
    });
  }
}
