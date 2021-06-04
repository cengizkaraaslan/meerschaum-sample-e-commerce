import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Service/Products.service';
import { Products } from '../model/products';
import { AlertifyService } from '../Service/alertify.service';
import { CartService } from '../Service/Cart.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  providers : [ProductsService]
})
export class MainComponent implements OnInit {

  mobile: boolean;
  products: Products[];
  productstopseller: Products[];
  productstopNew: Products[];
  productsrecentlyViewed: Products[];


  CartTotal: number;
  constructor( private productService: ProductsService, private alert: AlertifyService, private cartservice: CartService
    ) { }

  ngOnInit() {
    if (window.screen.width <= 500) { // 768px portrait
      this.mobile = true;
    }
    this.getproduct();
    this.topseller() ;
    this.topNew();
    this.recentlyViewed();
  }
  getproduct() {
    this.productService.getProduct().subscribe(res =>  {this.products = res;   });
  }
  topseller() {
    this.productService.topseller().subscribe(res =>  {this.productstopseller = res;   });
  }
  topNew() {
    this.productService.topNew().subscribe(res =>  {this.productstopNew = res;   });
  }
  recentlyViewed() {
    this.productService.recentlyViewed().subscribe(res =>  {this.productsrecentlyViewed = res;   });
  }
  cartadd(pro: Products) {

    this.CartTotal =  this.cartservice.cartadd(pro);
    console.log(this.CartTotal);
    // this.alert.success('Product Added ' + pro.title);
   // alertify.success('sadsd');
  }
}
