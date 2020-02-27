import { Component, OnInit, ViewChild } from "@angular/core";
import { Student } from "src/app/generic/models/student";
import { StudentService } from "src/app/services/student.service";
import { Router } from "@angular/router";
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
  styleUrls: ["./student-list.component.css"]
})
export class StudentListComponent implements OnInit {
  students: MatTableDataSource<Student>;
  displayedColumns: string[] = ["name", "email", "actions"];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  loaded = false;

  constructor(private studentService: StudentService, private router: Router) {}

  ngOnInit() {
    this.studentService.getStudents().subscribe((students) => {
      this.students = new MatTableDataSource<Student>(students);
      this.students.paginator = this.paginator;
      this.loaded = true;
    });
  }
  
  stats(id) {
    this.router.navigate(["/student/" + id]);
  }
}
