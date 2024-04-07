import { Component, ContentChild, OnInit, TemplateRef } from '@angular/core';
import { Observable } from 'rxjs';

import { LAYOUT_VERTICAL } from './layout.model';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  layoutType!: string;
  dataObs!: Observable<any>;
  data!: any;

  @ContentChild(TemplateRef) template: TemplateRef<unknown> | undefined;

  ngOnInit(): void {
    this.layoutType = LAYOUT_VERTICAL;
    document.body.setAttribute('layout', this.layoutType);
  }
}
