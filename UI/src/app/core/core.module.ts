import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbDropdownModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { TranslateModule } from '@ngx-translate/core';
import { SimplebarAngularModule } from 'simplebar-angular';

import { SharedModule } from '../shared/shared.module';
import { ChangePassUserComponent } from './layouts/change-pass-user/change-pass-user.component';
import { LayoutComponent } from './layouts/layout.component';
import { SidebarComponent } from './layouts/sidebar/sidebar.component';
import { TopbarComponent } from './layouts/topbar/topbar.component';
import { VerticalComponent } from './layouts/vertical/vertical.component';

@NgModule({
  declarations: [LayoutComponent, VerticalComponent, TopbarComponent, SidebarComponent, ChangePassUserComponent],
  imports: [
    CommonModule,
    RouterModule,
    NgbDropdownModule,
    NgbNavModule,
    SimplebarAngularModule,
    TranslateModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    SharedModule
  ],
  providers: []
})
export class CoreModule {}
