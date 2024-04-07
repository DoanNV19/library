import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'vnd'
})
export class VndPipe implements PipeTransform {
  transform(html: number) {
    return html.toLocaleString('vi-VN') + ' VNĐ';
  }
}
