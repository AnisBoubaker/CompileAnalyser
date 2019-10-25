import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/generic/models/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  students: Student[] = [];
  displayedColumns: string[] = ['name', 'email'];
  loaded = false;

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this.studentService.getStudents().subscribe((students) => {
      this.students = students;
      this.loaded = true;
    });
  }

}
