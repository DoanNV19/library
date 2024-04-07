import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/shared/services/app.service';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  breadCrumbItems!: Array<object>;
  constructor(private appService: AppService) {}
  ngOnInit(): void {
    this.breadCrumbItems = [];
  }
}
