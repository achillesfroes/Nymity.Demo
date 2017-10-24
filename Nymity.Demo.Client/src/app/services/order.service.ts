import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

@Injectable()
export class OrderService {

  urlBase:string="http://localhost:50173/";

  constructor(private http: Http) { }

  getAll(id:number) {
      let url = this.urlBase + `orders/all/${id}`;

      return this.http.get(url, this.jwt()).map((response: Response) => response.json());
      //return this.http.get(url).map((response: Response) => response.json());
  }

  getById(id: number) {
    return this.http.get(this.urlBase + `/orders/${id}/details`, this.jwt()).map((response: Response) => response.json());
    //return this.http.get(this.urlBase + `/orders/${id}/details`).map((response: Response) => response.json());
  }

  private jwt() {
    // create authorization header with jwt token
    let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.access_token) {
        let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.access_token });
        return new RequestOptions({ headers: headers });
    }
  }

}
