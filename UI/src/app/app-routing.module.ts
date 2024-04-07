import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './core/guards/auth.guard';
import { LayoutComponent } from './core/layouts/layout.component';

// Auth

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    loadChildren: () => import('./modules/pages.module').then(m => m.PagesModule)
  },
  { path: 'account', loadChildren: () => import('./modules/account/account.module').then(m => m.AccountModule) },
  {
    path: 'pages',
    loadChildren: () => import('./modules/extraspages/extraspages.module').then(m => m.ExtraspagesModule)
  },
  { path: '**', pathMatch: 'full', redirectTo: '/pages/page-404' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
