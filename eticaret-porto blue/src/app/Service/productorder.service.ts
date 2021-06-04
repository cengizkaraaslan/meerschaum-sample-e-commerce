import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CartService } from './Cart.service';
import { Order } from '../model/Order';
import { Observable, observable } from 'rxjs';
import { AuthService } from './Auth.service';
import { OrderSalesed } from '../model/OrderSalesed';
import { Api } from '../model/api.enum';

@Injectable({
  providedIn: 'root'
})
export class ProductorderService {
  constructor(
    private http: HttpClient,
    private cartservice: CartService,
    private authservice: AuthService
  ) {}
  path = Api.Url + 'salesed/';

  Order(order: Order) {
    this.http.post(this.path + 'add/', order).subscribe();
  }
  OrderProducts(): Observable<OrderSalesed[]> {
    return this.http.get<OrderSalesed[]>(
      this.path + '/' + this.authservice.getCurrentUserId()
    );
  }
  public deleteproduct(ordersales): any  {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };



    this.http
      .delete(this.path + ordersales.salesp_id, httpOptions)
      .subscribe(
        res => {

          console.log(true);
          return true;
          // this.deletestatus = true;


        },
        err => {
            console.log(false);
          // this.deletestatus = false;
          return false;

        }
      );

      // return  this.deletestatus  ;
  }
}
