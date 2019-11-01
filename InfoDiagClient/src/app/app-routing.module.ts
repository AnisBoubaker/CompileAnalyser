
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
import { ErrorCodeListComponent } from './error-code/error-code-list/error-code-list.component';
import { ErrorCodeModule } from './error-code/error-code.module';
import { GroupListComponent } from './group/group-list/group-list.component';
import { GroupModule } from './group/group.module';
import { GroupComponent } from './group/group.component';

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'student/all', component: StudentListComponent, canActivate: [AuthGuard] },
    { path: 'student/:id', component: StudentComponent, canActivate: [AuthGuard] },
    { path: 'student', redirectTo: 'student/all'},
    { path: 'group/all', component: GroupListComponent, canActivate: [AuthGuard]},
    { path: 'group/:id', component: GroupComponent, canActivate: [AuthGuard]},
    { path: 'group', redirectTo: 'group/all'},
    { path: 'errorCode/all', component: ErrorCodeListComponent, canActivate: [AuthGuard]},
    { path: 'errorCode', redirectTo: 'errorCode/all'},
    { path: '**', component: PageNotFoundComponent}
  ];

@NgModule({
    imports: [
      RouterModule.forRoot(routes),
      HomeModule,
      StudentModule,
      ErrorModule,
      LoginModule,
      ErrorCodeModule,
      GroupModule
    ],
    exports: [ RouterModule ]
  })
  export class AppRoutingModule { }
