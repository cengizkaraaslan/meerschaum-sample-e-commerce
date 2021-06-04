import { Injectable } from '@angular/core';
import { User } from '../model/User';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertifyService } from './alertify.service';
import { Api } from '../model/api.enum';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private user: User,
     private http: HttpClient,
     private router: Router,
     private alertif: AlertifyService
     ) {}
  api = Api.Url + 'user/';
  login(email: string, password: string) {
    return this.http.get<string>(this.api + email + '/' + password );
  }
   createingaccount(user: User) {
     this.http.post(this.api + 'createaccount/', user).subscribe();
    // this.router.navigateByUrl('/main');
    this.alertif.success('Login to the system successfulSucces fully');
  }
  getuserid(userid: number) {
    // tslint:disable-next-line:no-debugger

    return this.http.get<User>(this.api + userid  );
 }
}
