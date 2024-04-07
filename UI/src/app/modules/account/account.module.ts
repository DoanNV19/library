import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbCarouselModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';

import { AccountRoutingModule } from './account-routing.module';
import { LoginComponent } from './components/login/login.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';

@NgModule({
  declarations: [LoginComponent, LoginPageComponent],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, AccountRoutingModule, NgbToastModule, NgbCarouselModule],
  exports: []
})
export class AccountModule {}
