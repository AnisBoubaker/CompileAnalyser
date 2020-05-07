import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorCategoryComponent } from './error-category.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { LayoutModule } from '@angular/cdk/layout';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { AddErrorCategoryComponent } from './add-error-category/add-error-category.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [ErrorCategoryComponent, AddErrorCategoryComponent],
  imports: [
    CommonModule,
    FormsModule,
    LayoutModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatExpansionModule,
    MatOptionModule,
    MatCardModule,
    MatProgressSpinnerModule
  ],
  entryComponents:[AddErrorCategoryComponent]
})
export class ErrorCategoryModule { }
