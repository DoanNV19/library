import { CdkDrag, DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { RouterModule } from '@angular/router';
import { NgbAccordionModule, NgbDropdownModule, NgbModule, NgbNavModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
// Counter
import { FlatpickrModule } from 'angularx-flatpickr';
// Load Icons
import { defineElement } from 'lord-icon-element';
import lottie from 'lottie-web';
import { NgxEditorModule } from 'ngx-editor';
import { NgxMaskModule } from 'ngx-mask';
// Swiper Slider
import { SimplebarAngularModule } from 'simplebar-angular';

import { BreadcrumbsComponent } from './components/breadcrumbs/breadcrumbs.component';
import { CommonModalComponent } from './components/modals/common-modal/common-modal.component';
import { CommonModalRejectComponent } from './components/modals/common-modal-reject/common-modal-reject.component';
import { CommonSyncModalComponent } from './components/modals/common-sync-modal/common-sync-modal.component';
import { NotDataShowComponent } from './components/not-data-show/not-data-show.component';
import { NoSpaceDirective } from './directives/no-space.directive';
import { OnlyNumberDirective } from './directives/only-number.directive';
import { OnlyNumberCurrencyDirective } from './directives/only-number-currency.directive';
import { ScrollspyDirective } from './directives/scrollspy.directive';
import { SafeHtmlPipe } from './pipe/safe-html-pipe.component';
import { VndPipe } from './pipe/vnd-pipe.component';
@NgModule({
  declarations: [
    SafeHtmlPipe,
    BreadcrumbsComponent,
    CommonModalComponent,
    ScrollspyDirective,
    OnlyNumberDirective,
    CommonModalRejectComponent,
    NoSpaceDirective,
    NotDataShowComponent,
    VndPipe,
    CommonSyncModalComponent,
    OnlyNumberCurrencyDirective
  ],
  imports: [
    NgxEditorModule,
    CommonModule,
    NgbNavModule,
    NgbAccordionModule,
    NgbDropdownModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule,
    MatAutocompleteModule,
    FlatpickrModule,
    SimplebarAngularModule,
    NgxMaskModule.forRoot(),
    NgbModule,
    DragDropModule,
    CdkDrag,
    RouterModule
  ],
  exports: [
    BreadcrumbsComponent,
    ScrollspyDirective,
    CommonModalComponent,
    OnlyNumberDirective,
    CommonModalRejectComponent,
    NoSpaceDirective,
    NotDataShowComponent,
    VndPipe,
    OnlyNumberCurrencyDirective
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedModule {
  constructor() {
    defineElement(lottie.loadAnimation);
  }
}
