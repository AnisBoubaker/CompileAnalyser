import { Component, OnInit } from "@angular/core";
import { Student } from "src/app/generic/models/student";
import { StudentService } from "src/app/services/student.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
  styleUrls: ["./student-list.component.css"]
})
export class StudentListComponent implements OnInit {
  students: Student[] = [];
  displayedColumns: string[] = ["name", "email", "actions"];
  loaded = false;

  constructor(private studentService: StudentService, private router: Router) {}

  /*ngOnInit() {
    this.studentService.getStudents().subscribe((students) => {
      this.students = students;
      this.loaded = true;
    });
  }*/
  ngOnInit() {
    this.students[0] = {
      id: 1,
      email: "student1@student.com",
      name: "Student1"
    };
    this.students[1] = {
      id: 2,
      email: "student2@student.com",
      name: "Student2"
    };
    this.students[2] = {
      id: 3,
      email: "student3@student.com",
      name: "Student3"
    };
    this.students[3] = {
      id: 4,
      email: "student4@student.com",
      name: "Student3"
    };
    this.loaded = true;
  }
  stats(id) {
    this.router.navigate(["/student/" + id]);
  }
}
