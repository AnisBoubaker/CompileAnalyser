import { Component, OnInit } from "@angular/core";
import { Student } from "../generic/models/student";
import { StudentService } from "../services/student.service";
import { Router, ActivatedRoute, Params, ParamMap } from "@angular/router";
import { Observable } from "rxjs";
import { switchMap } from "rxjs/operators";

@Component({
  selector: "app-student",
  templateUrl: "./student.component.html",
  styleUrls: ["./student.component.css"]
})
export class StudentComponent implements OnInit {
  stats: any = [];
  currentStudent: Student;
  student: Observable<Student>;
  students: Observable<Student[]>;

  constructor(
    private studentService: StudentService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  /**
   * type = ce qui me dit si les true et false sont ensemble
   */
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.student = this.studentService.getStudent(+params.get("id"));
    });

    console.log("Student : ", this.student);

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
