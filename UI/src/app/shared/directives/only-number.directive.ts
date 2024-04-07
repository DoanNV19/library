import { Directive, ElementRef, forwardRef, HostListener, Renderer2 } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Directive({
  selector: '[appOnlyNumber]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => OnlyNumberDirective),
      multi: true
    }
  ]
})
export class OnlyNumberDirective implements ControlValueAccessor {
  private onChange: ((val: any) => void) | undefined;
  private onTouched: (() => void) | undefined;
  private value: number | undefined;

  constructor(
    private elementRef: ElementRef,
    private renderer: Renderer2
  ) {}

  @HostListener('input', ['$event.target.value'])
  onInputChange(value: string) {
    if (value == '') return;
    const filteredValue: number = filterValue(value);
    this.updateTextInput(filteredValue, this.value !== filteredValue);
  }

  @HostListener('blur')
  onBlur() {
    this.onTouched && this.onTouched();
  }

  private updateTextInput(value: number, propagateChange: boolean) {
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

function filterValue(value: any): number {
  if (value == '') {
    return 0;
  }
  const outPut = parseInt(value.replace(/[^0-9]*/g, ''));
  return isNaN(outPut) ? 0 : outPut;
}
