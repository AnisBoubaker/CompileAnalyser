import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import { Group } from 'src/app/generic/models/group';
import { GroupService } from 'src/app/services/group.service';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.css']
})
export class GroupListComponent implements OnInit {
  loaded = false;
  groups: MatTableDataSource<Group>;
  displayedColumns: string[] = ['id', 'name', 'description', 'link'];
  base: Group[];
  searchbar = '';
  searchLoading = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(
    private errorCodeService: GroupService
  ) {}

  ngOnInit() {
    this.initErrorCodes();
  }

  initErrorCodes() {
    this.loaded = false;
    this.errorCodeService.getGroups().subscribe(g => {
      this.base = g;
      this.groups = new MatTableDataSource<Group>(g);
      this.groups.paginator = this.paginator;
      this.loaded = true;
    });
  }
}
