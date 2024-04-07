import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
// Auth Services

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (localStorage.getItem('token')) {
      const permission: string[] = route.data ? route.data['permission'] : null;
      if (!permission) {
        return true;
      }
      return true;
    }
    this.router.navigate(['/account/login'], {
      queryParams: { returnUrl: state.url }
    });
    return false;
  }
}
