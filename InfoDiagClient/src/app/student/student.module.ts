import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { StudentComponent } from "./student.component";
import { StatsModule } from "../stats/stats.module";
import { StudentListComponent } from "./student-list/student-list.component";
import {
  MatTableModule,
  MatIconModule,
  MatButtonModule,
  MatPaginatorModule
} from "@angular/material";
import { StudentService } from "../services/student.service";

@NgModule({
  declarations: [StudentComponent, StudentListComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    StatsModule
  ],
  providers: [StudentService]
})
export class StudentModule {}
