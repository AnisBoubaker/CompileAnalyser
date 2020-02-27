import { Component, OnInit, Inject, ViewChild } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { MatSelectionList } from "@angular/material/list";
import { Group } from "src/app/generic/models/group";
import { UserService } from "src/app/services/user.service";
import { User } from "src/app/generic/models/user";
import { GroupService } from "src/app/services/group.service";
import { zip, Observable } from "rxjs";
import { zipAll } from "rxjs/operators";
import { TermService } from "src/app/services/term.service";
import { CourseService } from "src/app/services/course.service";

@Component({
  selector: "app-edit-group",
  templateUrl: "./edit-group.component.html",
  styleUrls: ["./edit-group.component.css"]
})
export class EditGroupComponent implements OnInit {
  @ViewChild("users", { static: true }) users: MatSelectionList;
  isEditing = !!this.data;
  title = this.isEditing
    ? "Modification de " + this.data.id
    : "Ajouter un groupe";
  possibleUsers: User[];
  saving = false;
  loaded = false;

  possibleCourses: string[];
  courseId: string;

  possibleTerms: string[];
  termId: string;

  groupNumber: number;

  constructor(
    public dialogRef: MatDialogRef<EditGroupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Group,
    private userService: UserService,
    private groupService: GroupService,
    private termService: TermService,
    private courseService: CourseService
  ) {}

  ngOnInit() {
    this.init();
  }

  init() {
    const obs: Observable<any>[] = [this.userService.getUsers()];

    if (this.isEditing) {
      obs.push(this.groupService.getPermitedUsers(this.data.id));
    } else {
      obs.push(this.courseService.getCourseAliases());
      obs.push(this.termService.getTerms());
    }

    zip(...obs).subscribe(results => {
      this.possibleUsers = results[0];
      if (this.isEditing) {
        setTimeout(() => {
          var temp = this.users.options.filter(e =>
            results[1].some(u => e.value.id == u)
          );
          if (temp) {
            this.users.selectedOptions.select(...temp);
          }
        }, 10);
      } else {
        this.possibleCourses = results[1];
        this.possibleTerms = results[2];
      }
      this.loaded = true;
    });
  }

  submit() {
    this.saving = true;
    if (this.isEditing) {
      this.groupService
        .assign(
          this.data.id,
          this.users.selectedOptions.selected.map(e => e.value.id)
        )
        .subscribe(result => {
          this.saving = false;
          this.dialogRef.close();
        });
    } else {
      this.groupService.postGroup(
        this.courseId,
        this.termId,
        this.groupNumber,
        this.users.selectedOptions.selected.map(e => e.value.id)
      ).subscribe(result => {
        this.saving = false;
        this.dialogRef.close();
      });
    }
  }

  addCurrentTerm() {
    this.termService.createCurrentTerm().subscribe(result => {
      this.termId = undefined;
      this.possibleTerms = result;
    })
  }
}
