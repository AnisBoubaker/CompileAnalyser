import { Component, OnInit, Inject, ViewChild } from "@angular/core";
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatSelectionList
} from "@angular/material";
import { Group } from "src/app/generic/models/group";
import { UserService } from "src/app/services/user.service";

@Component({
  selector: "app-edit-group",
  templateUrl: "./edit-group.component.html",
  styleUrls: ["./edit-group.component.css"]
})
export class EditGroupComponent implements OnInit {
  @ViewChild("users", { static: true }) userTable: MatSelectionList;
  isEditing = !!this.data;
  title = this.isEditing
    ? "Modification de " + this.data.id
    : "Ajouter un cours group";
  possibleUsers = [
    { firstName: "Samuel", lastName: "Leclerc" },
    { firstName: "Nicolas", lastName: "Charland" }
  ];
  loaded = false;
  constructor(
    public dialogRef: MatDialogRef<EditGroupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Group,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.getUsers().subscribe(users => {});
  }
}
