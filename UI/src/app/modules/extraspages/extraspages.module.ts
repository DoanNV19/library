import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NoPermissionComponent } from './components/components/no-permission/no-permission.component';
import { NotFoundComponent } from './components/components/not-found/not-found.component';
// Component pages
import { ExtrapagesRoutingModule } from './extraspages-routing.module';
import { ComingSoonComponent } from './pages/coming-soon/coming-soon.component';
import { MaintenanceComponent } from './pages/maintenance/maintenance.component';
import { Page403Component } from './pages/page403/page403.component';
import { Page404Component } from './pages/page404/page404.component';

@NgModule({
  declarations: [MaintenanceComponent, ComingSoonComponent, NoPermissionComponent, Page403Component, Page404Component, NotFoundComponent],
  imports: [CommonModule, ExtrapagesRoutingModule]
})
export class ExtraspagesModule {}
