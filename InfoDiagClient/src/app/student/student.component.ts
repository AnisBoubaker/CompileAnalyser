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
          nbOccurence: 4,
          name: "a Type",
          type: 2,
          isErrorCode: false
        },
        {
          nbOccurence: 1,
          name: "Ein",
          type: 2,
          isErrorCode: true
        },
        {
          nbOccurence: 1,
          name: "Zwei",
          type: 2,
          isErrorCode: true
        },
        {
          nbOccurence: 3,
          name: "another Type of error",
          type: 3,
          isErrorCode: false
        },
        {
          nbOccurence: 10,
          name: "First",
          type: 3,
          isErrorCode: true
        },
        {
          nbOccurence: 1,
          name: "Drei",
          type: 2,
          isErrorCode: true
        },
        {
          nbOccurence: 20,
          name: "Second",
          type: 3,
          isErrorCode: true
        },
        {
          nbOccurence: 10,
          name: "Third error!!!",
          type: 3,
          isErrorCode: true
        },
        {
          nbOccurence: 1,
          name: "Vier",
          type: 2,
          isErrorCode: true
        }
      ]
    };
  }
}
