import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './authentication.service';
import { StudentService } from './student.service';
import { UserService } from './user.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    AuthenticationService,
    StudentService,
    UserService
  ]
})
export class ServicesModule { }
