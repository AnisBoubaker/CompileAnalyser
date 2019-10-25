import { Component, OnInit } from '@angular/core';
import { ErrorCodeService } from 'src/app/services/error-code.service';
import { ErrorCode } from 'src/app/generic/models/errorCode';
import { handleError } from 'src/app/helpers/helperFunctions';

@Component({
  selector: 'app-error-code-list',
  templateUrl: './error-code-list.component.html',
  styleUrls: ['./error-code-list.component.css']
})
export class ErrorCodeListComponent implements OnInit {

  private loaded = false;
  private errorCodes: ErrorCode[] = []

  constructor(private errorCodeService: ErrorCodeService) { }

  ngOnInit() {
    this.errorCodeService.getErrorCodes().subscribe(ec => {
      this.errorCodes = ec;
      this.loaded = true;
    });
  }

  seed() {
    this.errorCodeService.seed().subscribe(() => {}, error => handleError())
  }

}
