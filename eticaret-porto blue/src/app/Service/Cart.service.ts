import { Injectable } from '@angular/core';
import { Products } from '../model/products';
import { CartAmount } from '../model/CartAmount';

import { AlertifyService } from '../Service/alertify.service';
import { CartbasketComponent } from '../cartbasket/cartbasket.component';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  constructor(
    private alert: AlertifyService,
    private prs: Products,
    private cartbasket: CartbasketComponent
  ) {}
  carts: Products[] = [];
    cartsum;
  cartadd(pro: Products) {
    for (let index = 0; index < this.carts.length; index++) {
      // tslint:disable-next-line:triple-equals
      if (this.carts[index].product_ID == pro.product_ID) {
        this.alert.warning('Already Product Added ' + pro.title);
        return this.sumall();
      }
    }
    this.alert.success('Product Added ' + pro.title);
    this.carts.push(pro);
    this.cartbasket.carttotal = 58855;
    this.cartbasket.cartchanged(3, 5996);
    this.cartsum = this.sumall();
    return this.cartsum;
  }
  cartremove(pro: Products) {
    for (let index = 0; index < this.carts.length; index++) {
      // tslint:disable-next-line:triple-equals
      if (this.carts[index].product_ID == pro.product_ID) {
        this.carts.splice(index, 1);
      }
    }
    this.cartsum = this.sumall();
    return this.cartsum;
  }
  sumall() {
    return this.carts.reduce(function(accumulator, pro) {
      return accumulator + pro.price;
    }, 0);
  }
}
