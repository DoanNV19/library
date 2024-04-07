import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ComingSoonComponent } from './pages/coming-soon/coming-soon.component';
// Component Pages
import { MaintenanceComponent } from './pages/maintenance/maintenance.component';
import { Page403Component } from './pages/page403/page403.component';
import { Page404Component } from './pages/page404/page404.component';

const routes: Routes = [
  {
    path: 'maintenance',
    component: MaintenanceComponent
  },
  {
    path: 'coming-soon',
    component: ComingSoonComponent
  },
  {
    path: 'page-403',
    component: Page403Component
  },
  {
    path: 'page-404',
    component: Page404Component
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExtrapagesRoutingModule {}
