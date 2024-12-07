import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
   name: 'Shorten'
})
export class ShortenPipe implements PipeTransform{
  transform(txt: string){
    if(txt.length>30){
      return txt.substr(0, 30) + ' ...';
    }
    return txt;
  }
}
