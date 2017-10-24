import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {

  urlBase:string="http://localhost:50173/";

  constructor(private http: Http) { }

  login(username: string, password: string) {

    let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });  
    let options = new RequestOptions({ headers: headers }); 

    let params = this.encodeParams({ grant_type: 'password', username: username, password: password });

    return this.http.post(this.urlBase+'Token',params, options)
        .map((response: Response) => {
            // login successful if there's a jwt token in the response
            let user = response.json();

            console.log(user);

            if (user && user.access_token) {

                localStorage.setItem('currentUser', JSON.stringify(user));
            }

            return user;
        });
  }

  private encodeParams(params: any): string {  
    
        let body: string = "";  
        for (let key in params) {  
            if (body.length) {  
                body += "&";  
            }  
            body += key + "=";  
            body += encodeURIComponent(params[key]);  
        }  
  
        return body;  
    }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

}
