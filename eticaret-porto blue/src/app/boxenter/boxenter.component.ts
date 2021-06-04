import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../Service/Auth.service';

@Component({
  selector: 'app-boxenter',
  templateUrl: './boxenter.component.html',
  styleUrls: ['./boxenter.component.css']
})
export class BoxenterComponent implements OnInit {

  mobile: boolean;
  constructor(private router: Router, private auth: AuthService) {
    if (window.screen.width <= 500) { // 768px portrait
      this.mobile = true;
    }
    if (auth.loggedIn()) {
      this.router.navigateByUrl('/adresses');
    }
  }

  ngOnInit() {
  }

}
