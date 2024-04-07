import { Pipe, PipeTransform } from '@angular/core';
import { SafeHtml } from '@angular/platform-browser';

@Pipe({
  name: 'safeHtml'
})
export class SafeHtmlPipe implements PipeTransform {
  transform(html: string): SafeHtml {
    const parser = new DOMParser();
    const parsedHtml = parser.parseFromString(html, 'text/html');
    if (parsedHtml.body.textContent == 'undefined') {
      parsedHtml.body.textContent = null;
    }
    return parsedHtml.body.textContent || '';
  }
}
