import { Component, OnInit, ViewChild } from "@angular/core";
import { MatTableDataSource, MatPaginator, MatDialog } from "@angular/material";
import { Group } from "src/app/generic/models/group";
import { GroupService } from "src/app/services/group.service";
import { AuthenticationService } from "src/app/services/authentication.service";
import { Role } from "src/app/generic/models/user";
import { EditGroupComponent } from "../edit-group/edit-group.component";
import { Router } from "@angular/router";

@Component({
  selector: "app-group-list",
  templateUrl: "./group-list.component.html",
  styleUrls: ["./group-list.component.css"]
})
export class GroupListComponent implements OnInit {
  loaded = false;
  groups: MatTableDataSource<Group>;
  displayedColumns: string[] = ["course", "term", "groupNumber", "actions"];
  base: Group[];
  searchbar = "";
  searchLoading = false;
  isAdmin = Number(Role[this.auth.currentUserValue.Role]) === Role.Admin;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private groupService: GroupService,
    private auth: AuthenticationService,
    public dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit() {
    this.init();
  }

  init() {
    this.loaded = false;
    this.groupService.getGroups().subscribe(g => {
      this.base = g;
      this.groups = new MatTableDataSource<Group>(g);
      this.groups.paginator = this.paginator;
      this.loaded = true;
    });
  }

  add() {
    const dialogRef = this.dialog.open(EditGroupComponent, {
      width: "600px"
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log("The dialog was closed");
      this.init();
    });
  }

  edit(element) {
    const dialogRef = this.dialog.open(EditGroupComponent, {
      width: "600px",
      data: element
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log("The dialog was closed");
      this.init();
    });
  }

  stats(id) {
    this.router.navigate(["/group/" + id]);
  }
}
