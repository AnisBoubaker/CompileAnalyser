import { Component, OnInit, ViewChild } from '@angular/core';
import { ErrorCodeService } from '../services/error-code.service';
import { ErrorCategoryService } from '../services/error-category.service';
import { MatSelectionList } from '@angular/material/list';
import { ErrorCode } from '../generic/models/errorCode';

@Component({
  selector: 'app-error-category',
  templateUrl: './error-category.component.html',
  styleUrls: ['./error-category.component.css']
})
export class ErrorCategoryComponent implements OnInit {
  searchbar1 = '';
  searchbar2 = '';
  searchLoading1 = false;
  searchLoading2 = false;

  errorCodes: ErrorCode[] = [];
  loaded = false;

  @ViewChild(MatSelectionList) errorCodeList: MatSelectionList;

  constructor(private errorCodeService: ErrorCodeService,
              private errorCategoryService: ErrorCategoryService) { }

  ngOnInit(): void {
    this.errorCodeService.getErrorCodes().subscribe(result => {console.log(typeof this.errorCodes);this.errorCodes = Array.of(...result); console.log(typeof this.errorCodes); this.loaded = true; });
  }

  searchChange1() {}
  searchChange2() {}

  hack(val) {
    return Array.from(val)
  }
}
