import { Component, OnInit } from "@angular/core";
import { Group } from '../generic/models/group';
import { GroupService } from '../services/group.service';
import { StatsService } from '../services/stat.service';
import { ActivatedRoute } from '@angular/router';
import { zip } from 'rxjs';

@Component({
  selector: "app-group",
  templateUrl: "./group.component.html",
  styleUrls: ["./group.component.css"]
})
export class GroupComponent implements OnInit {
  stats: any = [];
  group: Group;
  loaded = false;
  constructor(
    private groupService: GroupService,
    private statsService: StatsService,
    private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      zip(
        this.groupService.getGroup(params.get("id")),
        this.statsService.getStats(params.get("id"))
      )
      .subscribe(results => {
        this.group = results[0];
        this.stats = results[1];
        this.loaded = true;  
      });
    });
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
