import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/shared/services/auth.service';
import { ToastService } from 'src/app/toast-service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private authenticationService: AuthenticationService,
    private toastService: ToastService
  ) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError(err => {
        const error = err.error?.message ?? err.statusText;

        if (err.status === 401) {
          if (this.authenticationService.getAccessToken() == null) {
            this.authenticationService.logout();
            return throwError(error);
          } else {
            return this.handle401Error(request, next);
          }
        }

        if (err.status === 404) {
          this.toastService.show('Không kết nối được đến máy chủ', { classname: 'bg-danger text-center text-white', delay: 10000 });
        }

        if (err.status === 403) {
          this.toastService.showError('Truy cập bị từ chối');
        }

        return throwError(error);
      })
    );
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const refreshToken = this.authenticationService.getRefreshAccessToken();
    if (refreshToken == null) {
      this.authenticationService.logout();
      return throwError(Error);
    }
    return this.authenticationService.refreshToken(refreshToken).pipe(
      switchMap(user => {
        return next.handle(this.addToken(request, user.data.token ?? ''));
      }),
      catchError(error => {
        // Xử lý lỗi refresh token, ví dụ: đăng xuất người dùng
        this.authenticationService.logout();
        return throwError(error);
      })
    );
  }

  private addToken(request: HttpRequest<any>, token: string): HttpRequest<any> {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }
}
