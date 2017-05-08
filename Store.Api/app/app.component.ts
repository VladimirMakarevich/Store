//import { Component, OnInit} from '@angular/core';
//import { HttpService} from './http.service';
//import { RegistrationUser} from './registrationUser';

//@Component({
//    selector: 'registration-app',
//    template: `<div class="form-group">
//                    <label>Email</label>
//                    <input class="form-control" name="Email" [(ngModel)]="registrationUser.Email" />
//                </div>
//                <div class="form-group">
//                    <label>Password</label>
//                    <input class="form-control" name="Password" [(ngModel)]="registrationUser.Password" />
//                </div>
//                <div class="form-group">
//                    <label>Password</label>
//                    <input class="form-control" name="ConfirmPassword" [(ngModel)]="registrationUser.ConfirmPassword" />
//                </div>
//                <div class="form-group">
//                    <button class="btn btn-default" (click)="submit(registrationUser)">Отправить</button>
//                </div>
//                <div *ngIf="done">
//                    <div>Получено от сервера:</div>
//                    <div>{{receivedUser.message}}</div>
//                </div>`,
//    providers: [HttpService]
//})
//export class AppComponent {

//    registrationUser: RegistrationUser = new RegistrationUser(); // данные вводимого пользователя

//    receivedUser: RegistrationUser; // полученный пользователь
//    done: boolean = false;
//    constructor(private httpService: HttpService) { }
//    submit(registrationUser) {
//        this.httpService.postData(registrationUser)
//            .subscribe((data) => { this.receivedUser = data; this.done = true; });
//    }
//}