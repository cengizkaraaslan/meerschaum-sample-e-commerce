import { Component, OnInit } from '@angular/core';
import { ProductorderService } from '../Service/productorder.service';
import { OrderSalesed } from '../model/OrderSalesed';

@Component({
  selector: 'app-myorder',
  templateUrl: './myorder.component.html',
  styleUrls: ['./myorder.component.css']
})
export class MyorderComponent implements OnInit {
  constructor(private orderservice: ProductorderService) {}
  orders: OrderSalesed[];
  ngOnInit() {
    this.getlist();
   }
  getlist() {
    this.orderservice.OrderProducts().subscribe(data => {
      this.orders = data;
    });
  }
  // tslint:disable-next-line:typedef-whitespace
  removecart(item) {

  //  const b =  this.orderservice.deleteproduct(item);


     this.orderservice.deleteproduct(item);




    for (let i = 0; i < this.orders.length; ++i) {
      if (this.orders[i].salesp_id === item.salesp_id) {
          this.orders.splice(i, 1);
      }

   }


    // this.getlist();

  }
}
