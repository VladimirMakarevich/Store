import { Component, OnInit } from '@angular/core';
import { Product } from './product-type';
import { ProductService } from './product.service';

@Component({
    selector: 'product-list',
    /*templateUrl: './product-list.component.html',*/
    template: `<h1>Products</h1>

            <div class="panel panel-default panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Products in the stock</h3>
                </div>
                <div class="panel-body" *ngFor="let product of listProducts">
                    <p>{{product.Id}}</p>
                    <p>{{product.Name}}</p>
                    <p>{{product.Description}}</p>
                    <p>{{product.Price}}</p>
                </div>
            </div>`,
    providers: [ProductService]

})
export class ProductListComponent implements OnInit {

    listProducts: Product[];

    constructor(private productService: ProductService) {
    }

    ngOnInit() {
        this.productService.getProducts()
                .then(products => { this.listProducts = products });
    }
}