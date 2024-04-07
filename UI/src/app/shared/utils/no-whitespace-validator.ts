import { FormControl } from '@angular/forms';

export function noWhitespaceValidator(control: FormControl) {
  const isSpace = !control.value?.toString().trim().length;
  return isSpace && control.value?.toString().length ? { whitespace: true } : null;
}
