import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

@Injectable()
export class OrderService {

  constructor(private http: Http) { }

  getAll(id:number) {
      //return this.http.get('/orders', this.jwt()).map((response: Response) => response.json());
      let url = `http://localhost:50173/orders/all/${id}`;

      console.log(url);

      return this.http.get(url).map((response: Response) => response.json());
  }

  getById(id: number) {
    //return this.http.get(`/orders/${id}/details`, this.jwt()).map((response: Response) => response.json());
    return this.http.get(`/orders/${id}/details`).map((response: Response) => response.json());
  }

  private jwt() {
    // create authorization header with jwt token
    let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.token) {
        let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
        return new RequestOptions({ headers: headers });
    }
  }

}
