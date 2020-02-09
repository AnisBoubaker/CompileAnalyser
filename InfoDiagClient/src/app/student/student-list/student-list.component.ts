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

  ngOnInit() {
    this.studentService.getStudents().subscribe((students) => {
      this.students = students;
      this.loaded = true;
    });
  }
  
  stats(id) {
    this.router.navigate(["/student/" + id]);
  }
}
