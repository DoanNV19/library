import { FormControl } from '@angular/forms';

export function lessThanZero(control: FormControl) {
  const isSpace = !control.value || control.value <= 0;
  return isSpace ? { lessThanZero: true } : null;
}
