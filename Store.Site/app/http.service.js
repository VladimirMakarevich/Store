"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
const http_2 = require("@angular/http");
const http_3 = require("@angular/http");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/debounceTime");
require("rxjs/add/operator/distinctUntilChanged");
require("rxjs/add/operator/map");
require("rxjs/add/operator/switchMap");
require("rxjs/add/operator/toPromise");
require("rxjs/add/observable/throw");
require("rxjs/Rx");
//import './rxjs-operators';
let HttpService = class HttpService {
    constructor(http) {
        this.http = http;
    }
    postData(obj) {
        let headers = new http_2.Headers({
            'Content-Type': 'application/json'
        });
        headers.append('Accept', 'application/json; charset=utf-8');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, DELETE, PUT');
        headers.append('Access-Control-Allow-Headers', "X-Requested-With, Content-Type, Origin, Authorization, Accept, Client-Security-Token, Accept-Encoding");
        console.log("headers1: value" + JSON.stringify(headers));
        let options = new http_3.RequestOptions({ method: 'POST', headers: headers });
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
    }
    ;
};
HttpService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], HttpService);
exports.HttpService = HttpService;
;
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
//# sourceMappingURL=http.service.js.map