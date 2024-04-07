import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbCarouselModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { FlatpickrModule } from 'angularx-flatpickr';

import { SharedModule } from '../../shared/shared.module';
import { BookRoutingModule } from './book-routing.module';
import { BooksComponent } from './components/books/books.component';
import { BooksPageComponent } from './pages/books-page/books-page.component';
@NgModule({
  declarations: [BooksPageComponent, BooksComponent],
  exports: [],
  imports: [
    FlatpickrModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NgbToastModule,
    NgbCarouselModule,
    BookRoutingModule,
    SharedModule,
    NgbPaginationModule
  ]
})
export class BookModule {}
