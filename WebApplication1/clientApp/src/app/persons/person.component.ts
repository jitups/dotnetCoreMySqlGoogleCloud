import { Component, Inject } from '@angular/core';
//import { RequestOptions } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent {
  public persons: PersonViewModel[];

  constructor(http: HttpClient
  ) {
    // console.log('https://mvcwebapi-215708.appspot.com/' + 'api/SampleData/Persons');
    let baseUrl = 'https://mvcwebapi-215708.appspot.com/api/Person/';
    let encryptedHeader = this.make_base_auth("webappuser", "Jitu@123");
    let headers = new HttpHeaders({ 'Authorization' : encryptedHeader });
    console.log('fetching data from ' + baseUrl);
    //headers.set('Content-Type', 'application/json');
    //headers.set('Authorization', this.make_base_auth("webappuser", "Jitu@123"));
    //let options = new RequestOptions({ headers: headers });
    http.get<PersonViewModel[]>(baseUrl , { headers: headers }).subscribe(result => {
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
