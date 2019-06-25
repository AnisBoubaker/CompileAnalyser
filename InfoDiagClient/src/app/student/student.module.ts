import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentComponent } from './student.component';
import { StudentListComponent } from './student-list/student-list.component';

@NgModule({
  declarations: [
    StudentComponent,
    StudentListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class StudentModule { }
