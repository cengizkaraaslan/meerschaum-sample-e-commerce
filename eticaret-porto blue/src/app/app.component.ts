import { Component } from '@angular/core';
import { CartService } from './Service/Cart.service';
import { Products } from './model/products';
import { AuthService } from './Service/Auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'eticaret';
  helpman = false;
  loginUser: any = {};
  menuopenclose = 'block';
  mobile = false;
  constructor(private cartservice: CartService, private authservice: AuthService) {

    if (window.screen.width < 500) { // 768px portrait
      this.mobile = true;
    }
  }

   onActivate(event) {
     window.scroll(0, 30);
   }
 
  helpmanpage(event) {
    if (this.helpman === false) {
      this.helpman = true;
      const myDiv = document.getElementById('option-panel');
      myDiv.style.left = ' 0px';
    } else {
      this.helpman = false;
      const myDiv = document.getElementById('option-panel');
      myDiv.style.left = ' -275px';
    }
  }
  get isAuthenticated() {
     return this.authservice.loggedIn();
  }
  get getCurrentUsername() {

    return this.authservice.getCurrentUsername();
 }

}
