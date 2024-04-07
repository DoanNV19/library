import { Component, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-common-modal',
  templateUrl: './common-modal.component.html',
  styleUrls: ['./common-modal.component.scss']
})
export class CommonModalComponent {
  @Input() ActionFinish!: (() => void) | undefined;
  @Input() ActionClose: (() => void) | undefined;
  @Input() HeaderIcon: string | undefined;
  @Input() TextContain!: string;
  @Input() TextDescription!: string;
  @Input() TextButton = {
    Confirm: 'Đồng ý',
    Close: 'Hủy'
  };
  KeyWord!: string;
  constructor(public modalService: NgbModal) {}
  get imgUrl() {
    return '../../../../../assets/images/svg/' + (this.HeaderIcon ?? 'comfirm-icon.svg');
  }
}
