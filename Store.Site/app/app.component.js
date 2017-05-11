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
const http_service_1 = require("./http.service");
const registrationUser_1 = require("./registrationUser");
let AppComponent = class AppComponent {
    constructor(httpService) {
        this.httpService = httpService;
        this.registrationUser = new registrationUser_1.RegistrationUser(); // данные пользователя
        this.done = false;
    }
    submit(registrationUser) {
        this.httpService.postData(registrationUser)
            .subscribe((data) => { this.receivedUser = data; this.done = true; });
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'registration-app',
        template: `<div class="form-group">
                    <label>Email</label>
                    <input class="form-control" name="Email" [(ngModel)]="registrationUser.Email" />
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <input class="form-control" name="Password" [(ngModel)]="registrationUser.Password" />
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <input class="form-control" name="ConfirmPassword" [(ngModel)]="registrationUser.ConfirmPassword" />
                </div>
                <div class="form-group">
                    <button class="btn btn-default" (click)="submit(registrationUser)">Отправить</button>
                </div>
                <div *ngIf="done">
                    <div>Получено от сервера:</div>
                    <div>{{receivedUser.message}}</div>
                </div>
<product-list>Wiating...</product-list>
`,
        providers: [http_service_1.HttpService]
    }),
    __metadata("design:paramtypes", [http_service_1.HttpService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map