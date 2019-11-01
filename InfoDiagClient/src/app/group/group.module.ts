import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupListComponent } from './group-list/group-list.component';
import { NewGroupComponent } from './new-group/new-group.component';
import { GroupComponent } from './group.component';



@NgModule({
  declarations: [GroupListComponent, NewGroupComponent, GroupComponent],
  imports: [
    CommonModule
  ]
})
export class GroupModule { }
