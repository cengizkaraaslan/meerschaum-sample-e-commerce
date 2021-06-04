import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-cartbasket',
  templateUrl: './cartbasket.component.html',
  styleUrls: ['./cartbasket.component.css']
})
export class CartbasketComponent implements OnInit {
  @Input()  carttotal = 0;
  @Input()  cartamount = 0;
  constructor() {}

  ngOnInit() {}
  cartchanged(_carttotal, _cartamount) {

    this.cartamount = _cartamount;
    this.carttotal = _carttotal;
  }

}
