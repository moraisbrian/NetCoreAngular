import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'textSubstring'
})
export class TextSubstringPipe implements PipeTransform {

  transform(value: string, tamanho: number): string {
    if (value.length > tamanho) {
      return value.substr(0, tamanho - 3) + '...';
    } else {
      return value;
    }
  }
}
