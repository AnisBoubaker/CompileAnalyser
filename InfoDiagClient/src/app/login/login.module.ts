import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ServicesModule } from '../services/services.module';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ServicesModule,
    MatCardModule
  ],
})
export class LoginModule { }
