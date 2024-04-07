import { Directive, ElementRef, forwardRef, HostListener, Input, Renderer2 } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Directive({
  selector: '[appOnlyNumberCurrency]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => OnlyNumberCurrencyDirective),
      multi: true
    }
  ]
})
export class OnlyNumberCurrencyDirective implements ControlValueAccessor {
  @Input() initialValue?: string;

  private onChange: ((val: any) => void) | undefined;
  private onTouched: (() => void) | undefined;
  private value: string | undefined;

  constructor(
    private elementRef: ElementRef,
    private renderer: Renderer2
  ) {}

  @HostListener('click') onClick(): void {
    this.renderer.setProperty(this.elementRef.nativeElement, 'value', this.elementRef.nativeElement.value.replace(/[^0-9]+/g, ''));
  }

  @HostListener('input', ['$event.target.value'])
  onInputChange(value: string) {
    if (value == '') return;
    const filteredValue: string = filterValue(value);
    this.updateTextInput(filteredValue, this.value !== filteredValue);
  }

  @HostListener('blur', ['$event.target.value'])
  onBlur() {
    this.renderer.setProperty(
      this.elementRef.nativeElement,
      'value',
      Number.parseFloat(this.elementRef.nativeElement.value.replace(/[^0-9]*/g, '')).toLocaleString('vi-VN')
    );
    this.onTouched && this.onTouched();
  }

  private updateTextInput(value: string, propagateChange: boolean) {
    this.renderer.setProperty(this.elementRef.nativeElement, 'value', value);
    if (propagateChange) {
      this.onChange && this.onChange(value);
    }
    this.value = value;
  }

  // ControlValueAccessor Interface
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.renderer.setProperty(this.elementRef.nativeElement, 'disabled', isDisabled);
  }

  writeValue(value: any): void {
    value = value ? String(value) : '';
    this.updateTextInput(value, false);
  }
}

function filterValue(value: any): string {
  if (value == '') {
    return '0';
  }
  const number = parseFloat(value.replace(/[^0-9]*/g, ''));
  return isNaN(number) ? '0' : number.toString();
}
