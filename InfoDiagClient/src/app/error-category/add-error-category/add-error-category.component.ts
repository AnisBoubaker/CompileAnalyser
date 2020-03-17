import { Component, OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { ErrorCategoryService } from "src/app/services/error-category.service";

@Component({
  selector: "app-add-error-category",
  templateUrl: "./add-error-category.component.html",
  styleUrls: ["./add-error-category.component.css"]
})
export class AddErrorCategoryComponent implements OnInit {
  name: string;

  constructor(
    public dialogRef: MatDialogRef<AddErrorCategoryComponent>,
    private errorCategoryService: ErrorCategoryService
  ) {}

  ngOnInit(): void {}

  submit() {
    this.errorCategoryService.add(this.name).subscribe(result => {
      this.dialogRef.close({data: result});
    });
  }
}
