import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-student",
  templateUrl: "./student.component.html",
  styleUrls: ["./student.component.css"]
})
export class StudentComponent implements OnInit {
  stats: any = [];
  stats2 = "allo";
  constructor() {}

  /**
   * type = ce qui me dit si les true et false sont ensemble
   */
  ngOnInit() {
    this.stats = {
      date: Date.now(),
      lines: [
        {
          nbOccurence: 3,
          name: "a Type",
          type: 2,
          isErrorCode: false
        },
        {
          nbOccurence: 1,
          name: "an error",
          type: 2,
          isErrorCode: true
        },
        {
          nbOccurence: 2,
          name: "an error2",
          type: 2,
          isErrorCode: true
        }
      ]
    };
  }
  displayStats() {
    let line = this.stats.lines;
    line.forEach(element => {
      console.log(element.nbOccurence);
    });
    //const o = this.stats.lines;
    //o.array.forEach(element => {
    //console.log(element);
    //});
  }
}
