
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { StudentListComponent } from './student/student-list/student-list.component';
import { StudentComponent } from './student/student.component';
import { PageNotFoundComponent } from './error/page-not-found/page-not-found.component';
import { StudentModule } from './student/student.module';
import { ErrorModule } from './error/error.module';

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'student/all', component: StudentListComponent},
    { path: 'student/:id', component: StudentComponent},
    { path: 'student', redirectTo: 'student/all'},
    { path: '**', component: PageNotFoundComponent}
  ];

@NgModule({
    imports: [
      RouterModule.forRoot(routes),
      HomeModule,
      StudentModule,
      ErrorModule
    ],
    exports: [ RouterModule ]
  })
  export class AppRoutingModule { }
