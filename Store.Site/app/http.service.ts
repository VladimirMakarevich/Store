import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {Response, Headers} from '@angular/http';
import {RegistrationUser} from './registrationUser';
/*
import {Product} from './product';
*/
import {Observable} from 'rxjs';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/throw';
import 'rxjs/Rx';
import './rxjs-operators';


@Injectable()
export class HttpService {

    constructor(private http: Http) { }

    postData(obj: RegistrationUser) {

        let headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        let body = JSON.stringify({ obj });

        return this.http.post('http://localhost:51377/api/Account/PostRegister/', body, { headers: headers })
            .map((res: Response) => res.json())
            .subscribe();
    };
};


/*
@Injectable()
export class HttpProduct {

    constructor(private http: Http) { }
     
    getData(){
        return this.http.get('http://localhost:51377/api/Products/GetProducts/');
    }
}
*/