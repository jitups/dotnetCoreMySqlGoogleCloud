import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent {
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
