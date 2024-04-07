import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppService } from 'src/app/shared/services/app.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionGuard implements CanActivate {
  constructor(
    private appService: AppService,
    private router: Router
  ) {}
  public canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | boolean {
    const permission: string[] | null = route.data ? route.data['permission'] : null;
    if (!permission) {
      return true;
    }

    if (!permission.some(element => this.appService.lstRole.indexOf(element) !== -1)) {
      this.router.navigate(['/pages/page-403']);
      return false;
    }

    return true;
  }
}
