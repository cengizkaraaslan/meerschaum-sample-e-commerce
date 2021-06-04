import { Injectable } from '@angular/core';
import { Loginuser } from '../model/Loginuser';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { JwtHelper, tokenNotExpired } from 'angular2-jwt';
import { Router } from '@angular/router';
import { AlertifyService } from './alertify.service';
import { RegisterUser } from '../model/RegisterUser';
import { Api } from '../model/api.enum';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(
    private http: HttpClient,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  path =  Api.Url + 'auth/';
  userToken: any;
  decodedToken: any;
  TOKEN_KEY = 'token';
  jwtHelper: JwtHelper = new JwtHelper();
  login(loginuser: Loginuser) {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');

    this.http
      .post(this.path + 'login', loginuser, { headers: headers })
      .subscribe(data => {
        this.saveToken(data);
        this.userToken = data;
        this.decodedToken = this.jwtHelper.decodeToken(data.toString());
        this.alertify.success('Login to the system successful');
        this.router.navigateByUrl('/main');
      },
      err => {
        this.alertify.error(err);
      });
  }
  saveToken(token) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }
  register(registerUser: RegisterUser) {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    this.http
      .post(this.path + 'register', registerUser, { headers: headers })
      .subscribe(data => {
       this.router.navigateByUrl('/login');
        this.alertify.success('User successfully created');
      });
  }

  logOut() {
    localStorage.removeItem(this.TOKEN_KEY);
    this.alertify.error('Sistemden çıkış yapıldı');
  }

  loggedIn() {
    return tokenNotExpired(this.TOKEN_KEY);
  }

  get token() {
    return localStorage.getItem(this.TOKEN_KEY);
  }
  getCurrentUsername() {
    return this.jwtHelper.decodeToken(this.token).unique_name;

  }
  getCurrentUserId() {
    return this.jwtHelper.decodeToken(this.token).nameid;
  }
}
