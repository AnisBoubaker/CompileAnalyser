import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ErrorCodeListComponent } from "./error-code-list/error-code-list.component";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatTableModule } from "@angular/material/table";
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
