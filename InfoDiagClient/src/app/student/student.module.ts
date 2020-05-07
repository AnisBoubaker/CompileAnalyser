import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { StudentComponent } from "./student.component";
import { StatsModule } from "../stats/stats.module";
import { StudentListComponent } from "./student-list/student-list.component";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatTableModule } from "@angular/material/table";
import { StudentService } from "../services/student.service";
import { StatsService } from '../services/stat.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [StudentComponent, StudentListComponent],
  imports: [
    FormsModule,
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatProgressSpinnerModule,
    StatsModule
  ],
  providers: [StudentService, StatsService]
})
export class StudentModule {}
