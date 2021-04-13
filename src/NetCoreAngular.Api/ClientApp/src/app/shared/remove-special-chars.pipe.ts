import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'removeSpecialChars'
})
export class RemoveSpecialCharsPipe implements PipeTransform {

  transform(value: string, chars: string[]): any {
    chars.forEach(char => {
      value = value.replace(char, '');
    });
    return value;
  }

}
