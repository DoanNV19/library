import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appNoSpace]'
})
export class NoSpaceDirective {
  constructor(private el: ElementRef) {}

  @HostListener('input', ['$event']) onInput(event: InputEvent): void {
    let inputValue = this.el.nativeElement.value;
    inputValue = inputValue.trim();
    this.el.nativeElement.value = inputValue.replace(/ /g, '');
    event.preventDefault();
  }
}
