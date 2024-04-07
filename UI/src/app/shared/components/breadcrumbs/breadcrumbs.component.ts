import { Location } from '@angular/common';
import { Component, Input } from '@angular/core';
@Component({
  selector: 'app-breadcrumbs',
  templateUrl: './breadcrumbs.component.html',
  styleUrls: ['./breadcrumbs.component.scss']
})

/**
 * Bread Crumbs Component
 */
export class BreadcrumbsComponent {
  @Input() titleBread: string | undefined;
  @Input() urlBack: string | undefined;
  @Input() isBack: boolean | undefined;
  @Input()
  breadcrumbItems!: Array<{
    active?: boolean;
    label?: string;
  }>;
  constructor(private location: Location) {}
  getBack() {
    this.location.back();
  }
}
