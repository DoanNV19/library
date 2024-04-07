import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenApiService } from 'src/app/core/api-services/authen.api.service';
import { AuthenticationService } from 'src/app/shared/services/auth.service';
import { ToastService } from 'src/app/toast-service';
// Login Auth
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

/**
 * Login Component
 */
export class LoginComponent implements OnInit {
  // Login Form
  loginForm!: UntypedFormGroup;
  submitted = false;
  fieldTextType!: boolean;
  error = '';
  returnUrl!: string;
  year: number = new Date().getFullYear();
  showNavigationArrows: any;
  constructor(
    private formBuilder: UntypedFormBuilder,
    private router: Router,
    private authenApiService: AuthenApiService,
    private toastService: ToastService,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit(): void {
    /**
     * Form Validatyion
     */
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.loginForm.controls;
  }

  /**
   * Form submit
   */
  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    this.authenApiService.signIn(this.loginForm.value).subscribe(res => {
      if (!res.errorCode) {
        localStorage.setItem('userInfor', JSON.stringify(res.data));
        localStorage.setItem('token', res.data.token ?? '');
        this.authenticationService.setAccessToken(res.data.token ?? '');
        this.authenticationService.setRefreshAccessToken(res.data.refreshToken ?? '');
        this.router.navigate(['/home']);
      } else {
        this.toastService.showError(res.errorMessage);
        this.submitted = false;
      }
    });
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }
}
