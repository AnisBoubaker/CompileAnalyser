import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorCodeListComponent } from './error-code-list/error-code-list.component';
import { MatTableModule } from '@angular/material';

@NgModule({
  declarations: [ErrorCodeListComponent],
  imports: [
    CommonModule,
    MatTableModule
  ]
})
export class ErrorCodeModule { }
