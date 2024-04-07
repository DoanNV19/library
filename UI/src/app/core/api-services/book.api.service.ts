import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from 'src/app/shared/models/book.model';
import { CommonResponse, DataPageList, SearchCommonModel } from 'src/app/shared/models/common.model';

@Injectable({
  providedIn: 'root'
})
export class BookApiService {
  constructor(private http: HttpClient) {}
  getPageBook(filter: SearchCommonModel): Observable<CommonResponse<DataPageList<Book>>> {
    filter = JSON.parse(JSON.stringify(filter).replace(/"\s+|\s+"/g, '"'));
    return this.http.post<CommonResponse<DataPageList<Book>>>(`/Book/GetPageBook`, filter);
  }
}
