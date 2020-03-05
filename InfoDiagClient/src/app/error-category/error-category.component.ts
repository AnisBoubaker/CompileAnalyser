import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error-category',
  templateUrl: './error-category.component.html',
  styleUrls: ['./error-category.component.css']
})
export class ErrorCategoryComponent implements OnInit {
  searchbar1 = ''
  searchbar2 = ''
  searchLoading1 = false
  searchLoading2 = false;

  constructor() { }

  ngOnInit(): void {
  }

  searchChange1() {}
  searchChange2() {}
}
