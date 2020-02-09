import { Component, OnInit } from "@angular/core";
import { Student } from "../generic/models/student";
import { StudentService } from "../services/student.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-student",
  templateUrl: "./student.component.html",
  styleUrls: ["./student.component.css"]
})
export class StudentComponent implements OnInit {
  stats: any = [];
  student: Student;
  loaded = false;

  constructor(
    private studentService: StudentService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      console.log(params);
      this.studentService.getStudent(params.get("id")).subscribe(student => {
        this.student = student;
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
