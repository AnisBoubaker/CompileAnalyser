import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ErrorCodeListComponent } from "./error-code-list/error-code-list.component";
import {
  MatTableModule,
  MatButtonModule,
  MatPaginatorModule,
  MatFormFieldModule,
  MatInputModule,
  MatIconModule,
  MatProgressSpinnerModule
} from "@angular/material";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [ErrorCodeListComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatProgressSpinnerModule,
    FormsModule
  ]
})
export class ErrorCodeModule {}
