import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentComponent } from './student.component';
import { StudentListComponent } from './student-list/student-list.component';
import { MatTableModule } from '@angular/material';

@NgModule({
  declarations: [
    StudentComponent,
    StudentListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule
  ]
})
export class StudentModule { }
