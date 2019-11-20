import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupListComponent } from './group-list/group-list.component';
import { NewGroupComponent } from './new-group/new-group.component';
import { GroupComponent } from './group.component';
import { MatTableModule, MatPaginatorModule } from '@angular/material';



@NgModule({
  declarations: [GroupListComponent, NewGroupComponent, GroupComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule
  ]
})
export class GroupModule { }
