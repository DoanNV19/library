import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbCarouselModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';

import { SharedModule } from '../../shared/shared.module';
import { BookRoutingModule } from './book-routing.module';
import { BooksComponent } from './components/books/books.component';
import { BooksPageComponent } from './pages/books-page/books-page.component';

@NgModule({
  declarations: [BooksPageComponent, BooksComponent],
  exports: [],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, NgbToastModule, NgbCarouselModule, BookRoutingModule, SharedModule]
})
export class BookModule {}
