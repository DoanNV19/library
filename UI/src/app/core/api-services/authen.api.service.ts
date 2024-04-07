import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserAuth } from 'src/app/shared/models/auth.model';
import { CommonResponse } from 'src/app/shared/models/common.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenApiService {
  constructor(private http: HttpClient) {}
  signIn(userInfor: { userName: string; password: string }): Observable<CommonResponse<UserAuth>> {
    userInfor = JSON.parse(JSON.stringify(userInfor).replace(/"\s+|\s+"/g, '"'));
    return this.http.post<CommonResponse<UserAuth>>(`/api/auth`, userInfor);
  }
}
