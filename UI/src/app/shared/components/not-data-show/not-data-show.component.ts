import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-not-data-show',
  templateUrl: './not-data-show.component.html',
  styleUrls: ['./not-data-show.component.scss']
})
export class NotDataShowComponent {
  @Input() isDetail = false;
}
