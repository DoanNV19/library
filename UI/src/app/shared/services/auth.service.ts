import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';

import { User, UserAuth } from '../models/auth.model';
import { CommonResponse } from '../models/common.model';
import { AppService } from './app.service';

@Injectable({ providedIn: 'root' })

/**
 * Auth-service Component
 */
export class AuthenticationService {
  user!: User;
  currentUserValue: any;
  private currentUserSubject: BehaviorSubject<User>;
  private refreshTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);
  constructor(
    private http: HttpClient,
    private appService: AppService
  ) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')!));
  }

  refreshToken(refreshToken: string): Observable<CommonResponse<UserAuth>> {
    const refreshTokenEndpoint = `${environment.webApi_kong}/api/auth/refresh`;

    return this.http.post<CommonResponse<UserAuth>>(refreshTokenEndpoint, { token: refreshToken }).pipe(
      tap((res: CommonResponse<UserAuth>) => {
        if (res.errorCode != 0) {
          this.logout();
          return;
        }
        this.setAccessToken(res.data.token ?? '');
        this.setRefreshAccessToken(res.data.refreshToken ?? '');
      })
    );
  }

  setAccessToken(token: string): void {
    // Lưu access token vào local storage hoặc nơi khác
    localStorage.setItem('token', token);
  }

  getAccessToken(): string | null {
    // Lấy access token từ local storage hoặc nơi khác
    return localStorage.getItem('token');
  }

  setRefreshAccessToken(token: string): void {
    // Lưu access token vào local storage hoặc nơi khác
    localStorage.setItem('refresh_token', token);
  }

  getRefreshAccessToken(): string | null {
    // Lấy access token từ local storage hoặc nơi khác
    return localStorage.getItem('refresh_token');
  }

  setRefreshTokenSubject(refreshToken: string): void {
    this.refreshTokenSubject.next(refreshToken);
  }

  getRefreshTokenSubject(): Observable<string | null> {
    return this.refreshTokenSubject.asObservable();
  }
  /**
   * Logout the user
   */
  logout() {
    localStorage.clear();
    this.appService.logout();
    this.currentUserSubject.next(null!);
    location.reload();
  }
}
