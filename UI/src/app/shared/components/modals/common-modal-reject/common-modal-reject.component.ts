import { Component, Input } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { noWhitespaceValidator } from 'src/app/shared/utils/no-whitespace-validator';

@Component({
  selector: 'app-common-modal-reject',
  templateUrl: './common-modal-reject.component.html',
  styleUrls: ['./common-modal-reject.component.scss']
})
export class CommonModalRejectComponent {
  @Input() ActionFinish!: ((reason: string) => void) | undefined;
  @Input() ActionClose: (() => void) | undefined;
  @Input() HeaderIcon: string | undefined;
  @Input() TextContain!: string;
  @Input() TextButton = {
    Confirm: 'Đồng ý',
    Close: 'Hủy'
  };
  dataForm!: UntypedFormGroup;
  constructor(
    public modalService: NgbModal,
    private fb: UntypedFormBuilder
  ) {
    this.dataForm = this.fb.group({
      reason: ['', [Validators.required, Validators.maxLength(255), noWhitespaceValidator]]
    });
  }
  get imgUrl() {
    return '../../../../../assets/images/svg/' + (this.HeaderIcon ?? 'comfirm-icon.svg');
  }

  handleFinish() {
    this.dataForm.markAllAsTouched();
    if (this.dataForm.invalid) {
      return;
    }
    this.ActionFinish && this.ActionFinish(this.dataForm.value.reason);
  }
}
