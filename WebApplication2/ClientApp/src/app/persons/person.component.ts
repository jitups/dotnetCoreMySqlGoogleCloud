import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-persons',
  templateUrl: './person.component.html'
})
export class Persos {
  public persons: PersonViewModel[];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PersonViewModel[]>(baseUrl + 'api/SampleData/Persons').subscribe(result => {
      this.persons = result;
    }, error => console.error(error));

  }

}

interface PersonViewModel {
  personId: number;
  firstName: string;
  lastName: string;
  dOB: Date;
  note: string;
}
