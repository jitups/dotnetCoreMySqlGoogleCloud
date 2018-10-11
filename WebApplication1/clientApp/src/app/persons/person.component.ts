import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent {
  public persons: PersonViewModel[];

  constructor(http: HttpClient
  //  , @Inject('BASE_URL') baseUrl: string
  ) {
    // console.log('https://mvcwebapi-215708.appspot.com/' + 'api/SampleData/Persons');
    let headers = new HttpHeaders();
    headers.append('Authorization', this.make_base_auth("webappuser", "Jitu@123"));
    http.get<PersonViewModel[]>('https://mvcwebapi-215708.appspot.com/api/Person', { headers: headers }).subscribe(result => {
      this.persons = result;
    }, error => console.error(error));

  }

  make_base_auth(user, password) {
    var tok = user + ':' + password;
    var hash = btoa(tok);
    return "Basic " + hash;
  }

}

interface PersonViewModel {
  personId: number;
  firstName: string;
  lastName: string;
  dOB: Date;
  note: string;
}
