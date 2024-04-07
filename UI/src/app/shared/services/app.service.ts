import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private _state: string[] | undefined;

  // get isSuperUser() {
  //   if (this._state) {
  //     return this._state.includes('ROLE_ADMIN');
  //   }
  //   const data: UserAuth = JSON.parse(localStorage.getItem('userInfor') ?? '{}');
  //   this._state = data.roles;
  //   return this._state.includes('ROLE_ADMIN');
  // }

  // get lstRole() {
  //   if (this._state) {
  //     return this._state;
  //   }
  //   const data: UserAuth = JSON.parse(localStorage.getItem('userInfor') ?? '{}');
  //   this._state = data.roles;
  //   return this._state;
  // }

  public logout() {
    this._state = undefined;
  }
}
