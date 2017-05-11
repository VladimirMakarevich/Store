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
const product_service_1 = require("./product.service");
let ProductListComponent = class ProductListComponent {
    constructor(productService) {
        this.productService = productService;
    }
    ngOnInit() {
        this.productService.getProducts()
            .then(products => { this.listProducts = products; });
    }
};
ProductListComponent = __decorate([
    core_1.Component({
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
        providers: [product_service_1.ProductService]
    }),
    __metadata("design:paramtypes", [product_service_1.ProductService])
], ProductListComponent);
exports.ProductListComponent = ProductListComponent;
//# sourceMappingURL=product.component.js.map