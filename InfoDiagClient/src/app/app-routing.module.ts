
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { StudentListComponent } from './student/student-list/student-list.component';
import { StudentComponent } from './student/student.component';
import { PageNotFoundComponent } from './error/page-not-found/page-not-found.component';
import { StudentModule } from './student/student.module';
import { ErrorModule } from './error/error.module';
import { LoginComponent } from './login/login.component';
import { LoginModule } from './login/login.module';
import { AuthGuard } from './helpers/auth.guard';

const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'student/all', component: StudentListComponent, canActivate: [AuthGuard] },
    { path: 'student/:id', component: StudentComponent, canActivate: [AuthGuard] },
    { path: 'student', redirectTo: 'student/all'},
    { path: '**', component: PageNotFoundComponent}
  ];

@NgModule({
    imports: [
      RouterModule.forRoot(routes),
      HomeModule,
      StudentModule,
      ErrorModule,
      LoginModule
    ],
    exports: [ RouterModule ]
  })
  export class AppRoutingModule { }
