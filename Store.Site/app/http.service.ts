import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {Response, Headers} from '@angular/http';
import {RegistrationUser} from './registrationUser';
import {Observable} from 'rxjs';
import {RequestOptions, Request, RequestMethod} from '@angular/http'

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/throw';
import 'rxjs/Rx';
//import './rxjs-operators';


@Injectable()
export class HttpService {

    constructor(protected http: Http) { }

    postData(obj: RegistrationUser) {

        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        headers.append('Accept', 'application/json; charset=utf-8');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, DELETE, PUT');
        headers.append('Access-Control-Allow-Headers', "X-Requested-With, Content-Type, Origin, Authorization, Accept, Client-Security-Token, Accept-Encoding");
        console.log("headers1: value" + JSON.stringify(headers));
        let options = new RequestOptions({ method: 'POST', headers: headers });

        let body = JSON.stringify(obj);

        //postJson(url: string, data: any): Observable < Response > {
        //    return this.http.post(
        //        url,
        //        JSON.stringify(data),
        //        { headers: this.headers }
        //    )
        //};

        let url = "http://localhost:51377/api/Account/PostRegister/";
        return this.http.post(url, body, options);

        //return this.http.post('http://localhost:51377/api/Account/PostRegister/', headers, body).subscribe(data => {
        //console.log(data);
            //.map((resp: Response) => resp.json()).subscribe();
        //.catch((error: any) => { return Observable.throw(error); });
    };
};

//constructor(protected http: Http) {}

//headers = new Headers({
//    'Content-Type': 'application/json'
//});

//postJson(url: string, data: any): Observable < Response > {
//    return this.http.post(
//        url,
//        JSON.stringify(data),
//        { headers: this.headers }
//    )
//}