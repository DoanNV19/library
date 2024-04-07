import { Injectable, TemplateRef } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ToastService {
  toasts: any[] = [];

  show(textOrTpl: string | TemplateRef<any>, options: any = {}) {
    this.toasts.push({ textOrTpl, ...options });
  }

  showSuccess(data: string) {
    this.show(data, {
      classname: 'bg-success text-center text-white',
      delay: 5000
    });
  }
  showError(data: string) {
    this.show(data, {
      classname: 'bg-danger text-center text-white',
      delay: 5000
    });
  }

  showWarning(data: string) {
    this.show(data, {
      classname: 'bg-warning text-center text-white',
      delay: 5000
    });
  }

  remove(toast: any) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }

  checknullSave(value: any, type: string) {
    if (type == 'number') {
      if (value != null && value > 0) {
        return value;
      } else {
        return 0;
      }
    } else if (type == 'string') {
      if (value != null && value != undefined && value != '') {
        return value.trim();
      } else {
        return '';
      }
    }
  }

  checkNullData(value: any, type: string) {
    if (type == 'number') {
      if (value != null && value > 0) {
        return value;
      } else {
        return undefined;
      }
    } else if (type == 'string') {
      if (value != null && value != undefined && value != '' && value != 'null') {
        return value.trim();
      } else {
        return '';
      }
    }
  }
}
