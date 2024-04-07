import { Component, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-common-sync-modal',
  templateUrl: './common-sync-modal.component.html',
  styleUrls: ['./common-sync-modal.component.scss']
})
export class CommonSyncModalComponent {
  @Input() ActionFinish!: (() => void) | undefined;
  @Input() ActionClose: (() => void) | undefined;
  @Input() HeaderIcon: string | undefined;
  @Input() TextContain!: string;
  @Input() TextDescription!: string;
  @Input() isLoadding!: boolean;
  @Input() TextButton = {
    Confirm: 'Đồng ý',
    Close: 'Hủy'
  };
  KeyWord!: string;
  constructor(public modalService: NgbModal) {}
  get imgUrl() {
    return '../../../../../assets/images/svg/accuracy-icon.svg';
  }
}
