import { Component, OnInit } from '@angular/core';
import { Products } from '../model/products';

import { AlertifyService } from '../Service/alertify.service';
import { CartService } from '../Service/Cart.service';
import { AuthService } from '../Service/Auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  constructor(
    private alert: AlertifyService,
    private prs: Products,
    private cartservice: CartService,
    private authservice: AuthService,
    private route: Router
  ) {}
  carts: Products[] = [];
  sum: number;

  ngOnInit() {
    this.carts = this.cartservice.carts;
    this.sum = this.cartservice.sumall();
  }
  removecart(pro: Products) {
    this.cartservice.cartremove(pro);
    this.sum = this.cartservice.sumall();
    this.carts = this.cartservice.carts;
  }
  continue() {
    if (this.authservice.loggedIn()) {
      this.route.navigateByUrl('/adresses');
    } else {
      this.route.navigateByUrl('/boxenter');
      window.scroll(0, 0);
    }
  }
}
