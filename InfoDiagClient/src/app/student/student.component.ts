import { Component, OnInit } from "@angular/core";
import { Student } from "../generic/models/student";
import { StudentService } from "../services/student.service";
import { ActivatedRoute } from "@angular/router";
import { zip } from 'rxjs';
import { StatsService } from '../services/stat.service';
import { Stats } from '../generic/models/stats';

@Component({
  selector: "app-student",
  templateUrl: "./student.component.html",
  styleUrls: ["./student.component.css"]
})
export class StudentComponent implements OnInit {
  stats: Stats[];
  student: Student;
  loaded = false;

  constructor(
    private studentService: StudentService,
    private statsService: StatsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      zip(
        this.studentService.getStudent(params.get("id")),
        this.statsService.getStats(params.get("id"))
      )
      .subscribe(results => {
        this.student = results[0];
        this.stats = results[1];
        this.loaded = true;  
      });
    });
  }
}
