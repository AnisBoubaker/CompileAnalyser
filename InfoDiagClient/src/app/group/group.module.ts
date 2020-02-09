import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { GroupListComponent } from "./group-list/group-list.component";
import { EditGroupComponent } from "./edit-group/edit-group.component";
import { StatsModule } from "../stats/stats.module";
import { GroupComponent } from "./group.component";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from "@angular/material/dialog";
import { MatIconModule } from "@angular/material/icon";
import { MatListModule } from "@angular/material/list";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatSelectModule } from "@angular/material/select";
import { MatTableModule } from "@angular/material/table";
import { StatsService } from '../services/stat.service';
import { GroupService } from '../services/group.service';

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
    MatListModule,
    StatsModule
  ],
  entryComponents: [EditGroupComponent],
  providers: [StatsService, GroupService]
})
export class GroupModule {}
