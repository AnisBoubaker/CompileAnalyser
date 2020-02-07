import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-group",
  templateUrl: "./group.component.html",
  styleUrls: ["./group.component.css"]
})
export class GroupComponent implements OnInit {
  stats: any = [];
  constructor() {}

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
