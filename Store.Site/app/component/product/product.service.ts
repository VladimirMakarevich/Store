import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';

import { Product } from './product-type';

@Injectable()
export class ProductService {
    constructor(private http: Http) {

    }

    getProducts() {
        return this.http.get('http://localhost:51377/api/Products/GetProducts')
            .map(response => response.json() as Product[])
            .toPromise();
//.subscribe((data: Response) => this.user=data.json())
    }
}