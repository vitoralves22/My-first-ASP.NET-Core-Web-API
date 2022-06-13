import { Pipe, PipeTransform } from '@angular/core';
// import * as moment from 'moment';

@Pipe({
  name: 'localDateTime'
})
export class LocalDateTimePipe implements PipeTransform {

  transform(date: any): string {
    // let dateOut: moment.Moment = moment(date, "YYYY-MM-DDThh:mm:ss.nnnnnn");
    // return dateOut.format("DD-MM-YYYY hh:mm");
    return "alo"
  }

}
