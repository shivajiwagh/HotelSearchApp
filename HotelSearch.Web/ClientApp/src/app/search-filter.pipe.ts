import { ReturnStatement } from '@angular/compiler';
import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { Hotel } from './hotel-model';

@Pipe({
  name: 'searchFilter'
})
@Injectable()
export class SearchFilterPipe implements PipeTransform {

  transform(Hotels: Hotel[], searchValue: string): Hotel[] {
    if(!Hotels || !searchValue){
      return Hotels;
    }
    return Hotels.filter(hotel => 
      hotel.name.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase()) ||
      hotel.description.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase()) ||
      hotel.location.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase()) ||
      hotel.rating == Number.parseInt(searchValue)
      );
  }

}
