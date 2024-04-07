import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BooksPageComponent } from './pages/books-page/books-page.component';

// Component Pages

const routes: Routes = [
  {
    path: '',
    component: BooksPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookRoutingModule {}
