import { Component, OnInit, ViewChild } from "@angular/core";
import { ErrorCodeService } from "../services/error-code.service";
import { ErrorCategoryService } from "../services/error-category.service";
import { MatSelectionList, MatSelectionListChange } from "@angular/material/list";
import { ErrorCode } from "../generic/models/errorCode";
import { AddErrorCategoryComponent } from './add-error-category/add-error-category.component';
import { MatDialog } from '@angular/material/dialog';
import { ErrorCategory } from '../generic/models/errorCategory';
import { zip } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: "app-error-category",
  templateUrl: "./error-category.component.html",
  styleUrls: ["./error-category.component.css"]
})
export class ErrorCategoryComponent implements OnInit {
  searchbar1 = "";
  searchbar2 = "";
  searchLoading1 = false;
  searchLoading2 = false;

  errorCodes: ErrorCode[] = [];
  filteredErrorCodes: ErrorCode[] = [];

  categories: ErrorCategory[];
  filteredCategories: ErrorCategory[];
  selectedCategory: ErrorCategory;
  selectedErrors: string[];
  possibleErrorCodes: ErrorCode[];
  loaded = false;

  @ViewChild(MatSelectionList) errorCodeList: MatSelectionList;

  constructor(
    private errorCodeService: ErrorCodeService,
    private errorCategoryService: ErrorCategoryService,
    private toastService: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    zip(this.errorCodeService.getErrorCodes(), this.errorCategoryService.getAll())
    .subscribe(result => {
      this.categories = result[1];
      this.filteredCategories = this.categories;
      this.possibleErrorCodes = result[0];
      this.initErrorCodes();
      this.filteredErrorCodes = this.errorCodes;
      
      this.loaded = true;
    });
  }

  initErrorCodes() {
    const temp = this.categories.flatMap(c => c.relatedErrors);
      this.errorCodes = this.possibleErrorCodes.filter(r => !temp.includes(r.id));
      this.filteredErrorCodes = this.errorCodes;
  }

  searchChange1() {
    this.searchLoading1 = true;
    this.errorCodeList.deselectAll();
    const value: string = this.searchbar1.toUpperCase();
    if (value && value.length > 1) {
      this.filteredErrorCodes = this.errorCodes.filter(
        ec =>
          ec.id.toUpperCase().includes(value)
      );
    } else {
      this.filteredErrorCodes = this.errorCodes;
    }
    this.searchLoading1 = false;
  }

  searchChange2() {
    this.searchLoading2 = true;
    const value: string = this.searchbar2.toUpperCase();
    if (value && value.length > 1) {
      this.filteredCategories = this.categories.filter(
        ec => {
          var toEval = ec.name.toUpperCase();
          ec.relatedErrors.forEach(re => toEval += ';' + re.toUpperCase());
          return toEval.includes(value);
        }
      );
    } else {
      this.filteredCategories = this.categories;
    }
    this.searchLoading2 = false;
  }

  add() {
    const dialogRef = this.dialog.open(AddErrorCategoryComponent, {
      width: "600px"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result && result.data) {
        this.categories = [...this.categories, {...result.data, relatedErrors: []}]
        this.searchChange2(); 
      }
    });
  }

  assign() {
    if (this.selectedCategory) {
      const errorCodeIds = this.errorCodeList.selectedOptions.selected.map(ec => ec.value.id as string);
      this.errorCategoryService.assign(Number(this.selectedCategory.id), errorCodeIds)
      .subscribe(() => {
        this.selectedCategory.relatedErrors.push(...errorCodeIds);
        this.errorCodes = this.errorCodes.filter(ec => !errorCodeIds.includes(ec.id));
        this.searchChange1();
      }); 
    } else {
      this.toastService.error("Aucune catégorie n'est sélectionnée")
    }
  }

  unassign() {
    this.errorCategoryService.unassign(this.selectedErrors).subscribe(() => {
        this.selectedCategory.relatedErrors = 
        this.selectedCategory.relatedErrors.filter(re => !this.selectedErrors.includes(re));        
        this.selectedErrors = [];
        this.initErrorCodes();
    });
  }

  opened(c: any) {
    this.selectedCategory = c;
  }

  closed() {
    this.selectedCategory = undefined;
    this.selectedErrors = [];
  }

  selectionChange($event : MatSelectionListChange) {
    this.selectedErrors = $event.source._value;
  }

  deleteCategory(category: ErrorCategory) {
    this.errorCategoryService.delete(Number(category.id)).subscribe(() => {
      const errorsToAdd = this.possibleErrorCodes.filter(pec => category.relatedErrors.includes(pec.id));
      this.errorCodes.push(...errorsToAdd);
      this.categories = this.categories.filter(c => c.id != category.id);
      this.searchChange1();
      this.searchChange2();
    });
  }

  editCategory(category: ErrorCategory) {
    this.errorCategoryService.delete(Number(category.id)).subscribe(() => {
      const errorsToAdd = this.possibleErrorCodes.filter(pec => category.relatedErrors.includes(pec.id));
      this.errorCodes.push(...errorsToAdd);
      this.categories = this.categories.filter(c => c.id != category.id);
      this.searchChange1();
      this.searchChange2();
    });
  }
}
