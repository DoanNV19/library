import { Component, OnInit } from '@angular/core';
import { BookApiService } from 'src/app/core/api-services/book.api.service';
import { BOOK_STATUS_CONSTANT } from 'src/app/shared/constants/book-status';
import { Book } from 'src/app/shared/models/book.model';
import { DataPageList, SearchCommonModel } from 'src/app/shared/models/common.model';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  public filter: SearchCommonModel = {
    pageIndex: 1,
    pageSize: 10,
    keySearch: ''
  };
  BOOK_STATUS_CONSTANT = BOOK_STATUS_CONSTANT;
  public books?: DataPageList<Book>;

  constructor(private bookApiService: BookApiService) {}

  ngOnInit(): void {
    this.getPageBook();
  }

  getPageBook() {
    this.bookApiService.getPageBook(this.filter).subscribe(x => {
      this.books = x.data;
    });
  }
}
