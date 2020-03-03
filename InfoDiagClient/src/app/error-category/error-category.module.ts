import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorCategoryComponent } from './error-category.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { LayoutModule } from '@angular/cdk/layout';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [ErrorCategoryComponent],
  imports: [
    CommonModule,
    FormsModule,
    LayoutModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatExpansionModule
  ]
})
export class ErrorCategoryModule { }
