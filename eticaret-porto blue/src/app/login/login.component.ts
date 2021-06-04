import { Component, OnInit } from '@angular/core';
import { UserService } from '../Service/User.service';
import { User } from '../model/User';
import { AuthService } from '../Service/Auth.service';
import { Loginuser } from '../model/Loginuser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService, User]
})
export class LoginComponent implements OnInit {
  constructor(private userservice: UserService, private auth: AuthService, private authservice: AuthService) {}

  loginUser: any = {};
  ngOnInit() {}
  login() {

    this.authservice.login(this.loginUser);
  }

  logOut() {
    this.authservice.logOut();
  }

  get isAuthenticated() {
     return this.authservice.loggedIn();
  }

}
