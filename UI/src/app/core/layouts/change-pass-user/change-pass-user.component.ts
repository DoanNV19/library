import { Component, Input, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { noWhitespaceValidator } from 'src/app/shared/utils/no-whitespace-validator';
import { passwordRegex } from 'src/app/shared/utils/regex';
import { ToastService } from 'src/app/toast-service';

@Component({
  selector: 'app-change-pass-user',
  templateUrl: './change-pass-user.component.html',
  styleUrls: ['./change-pass-user.component.scss']
})
export class ChangePassUserComponent implements OnInit {
  @Input() ActionFinish!: ((data: any) => void) | undefined;
  @Input() ActionClose: (() => void) | undefined;
  @Input() HeaderIcon: string | undefined;
  @Input() TextContain!: string;
  @Input() TextButton = {
    Confirm: 'Đồng ý',
    Close: 'Hủy'
  };
  checkShowInput = {
    currentPass: false,
    newPass: false,
    comfirmPassword: false
  };
  dataForm!: UntypedFormGroup;
  constructor(
    public modalService: NgbModal,
    private fb: UntypedFormBuilder,
    private toastService: ToastService
  ) {}
  ngOnInit(): void {
    this.dataForm = this.fb.group({
      currentPass: [
        '',
        [Validators.compose([Validators.required, Validators.maxLength(50), Validators.minLength(8)]), noWhitespaceValidator]
      ],
      newPass: [
        '',
        [
          Validators.compose([Validators.required, Validators.maxLength(50), Validators.minLength(8), , Validators.pattern(passwordRegex)]),
          noWhitespaceValidator
        ]
      ],
      comfirmPassword: [
        '',
        [Validators.compose([Validators.required, Validators.maxLength(50), Validators.minLength(8)]), noWhitespaceValidator]
      ]
    });
  }

  submitData() {
    this.dataForm.markAllAsTouched();
    if (this.dataForm.invalid) return;
    if (this.dataForm.get('newPass')?.value != this.dataForm.get('comfirmPassword')?.value) {
      this.toastService.showError('Mật khẩu nhập lại không khớp');
      return;
    }
    this.ActionFinish && this.ActionFinish(this.dataForm.value);
  }

  toggleFieldTextType(inputName: 'currentPass' | 'newPass' | 'comfirmPassword') {
    this.checkShowInput[inputName] = !this.checkShowInput[inputName];
  }
  get imgUrl() {
    return '../../../../../assets/images/svg/' + (this.HeaderIcon ?? 'comfirm-icon.svg');
  }
}
