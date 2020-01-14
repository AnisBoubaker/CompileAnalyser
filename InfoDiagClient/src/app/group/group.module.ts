import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupListComponent } from './group-list/group-list.component';
import { EditGroupComponent } from './edit-group/edit-group.component';
import { GroupComponent } from './group.component';
import { MatTableModule, MatPaginatorModule, MatButtonModule, MatIconModule, MatDialogModule } from '@angular/material';



@NgModule({
  declarations: [GroupListComponent, EditGroupComponent, GroupComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule
  ],
  entryComponents: [EditGroupComponent]
})
export class GroupModule { }
