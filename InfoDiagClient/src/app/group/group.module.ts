import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { GroupListComponent } from "./group-list/group-list.component";
import { EditGroupComponent } from "./edit-group/edit-group.component";
import { GroupComponent } from "./group.component";
import {
  MatTableModule,
  MatPaginatorModule,
  MatButtonModule,
  MatIconModule,
  MatDialogModule,
  MatSelectModule,
  MatListModule
} from "@angular/material";

@NgModule({
  declarations: [GroupListComponent, EditGroupComponent, GroupComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatListModule
  ],
  entryComponents: [EditGroupComponent]
})
export class GroupModule {}
