import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ShopComponent } from './shop/shop.component';
import { AlertifyService } from './service/alertify.service';
import { SingleproductComponent } from './singleproduct/singleproduct.component';
// tslint:disable-next-line:import-spacing
import { NgxGalleryModule } from 'ngx-gallery';
import { Products } from './model/products';
import { CartbasketComponent } from './cartbasket/cartbasket.component';
// import { NpnSliderModule } from 'npn-slider';
import { ContactComponent } from './contact/contact.component';

import { Ng5SliderModule } from 'ng5-slider';
import { LoadingComponent } from './loading/loading.component';
// import {StarRatingModule} from 'angular-star-rating';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPayPalModule } from 'ngx-paypal';
import { CategoryComponent } from './category/category.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AdressesComponent } from './adresses/adresses.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatGridListModule } from '@angular/material/grid-list';

import { LoginComponent } from './login/login.component';
import { Ng2CarouselamosModule } from 'ng2-carouselamos';
import { BoxenterComponent } from './boxenter/boxenter.component';
import { CreateaccountComponent } from './createaccount/createaccount.component';
import { User } from './model/User';
import { MyorderComponent } from './myorder/myorder.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
const routes: Routes = [
  { path: 'cart', component: CartComponent },
  { path: 'main', component: MainComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'shop', component: ShopComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'adresses', component: AdressesComponent },
  { path: 'category/:categoryid', component: CategoryComponent },
  { path: 'singleproduct/:productid', component: SingleproductComponent },
  { path: 'login', component: LoginComponent },
  { path: 'boxenter', component: BoxenterComponent },
  { path: 'createaccount', component: CreateaccountComponent },
  { path: 'myorder', component: MyorderComponent },

  { path: '**', redirectTo: 'main', pathMatch: 'full' },
  { path: '', redirectTo: 'main', pathMatch: 'full' }

];

@NgModule({
   declarations: [
      AppComponent,
      MainComponent,
      CartComponent,
      CheckoutComponent,
      ShopComponent,
      SingleproductComponent,
      CartbasketComponent,
      ContactComponent,
      LoadingComponent,
      CategoryComponent,
      AdressesComponent,
      LoginComponent,
      BoxenterComponent,
      CreateaccountComponent,
      MyorderComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      RouterModule.forRoot(routes, { useHash: true }),
      NgxGalleryModule,
      Ng5SliderModule,
      // tslint:disable-next-line:max-line-length
      // n//NpnSliderModule\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\n//RangeSliderModule\\\\\\\\\\\\\\\\n//StarRatingModule.forRoot()\\\\\\\\\\\\\\\\nNgbModule.forRoot(),
      NgxPayPalModule,
      NgbModule,
      MDBBootstrapModule.forRoot(),
      FormsModule,
      ReactiveFormsModule,
      MatPaginatorModule,
      NoopAnimationsModule,
      MatGridListModule,
      Ng2CarouselamosModule,
      MatExpansionModule
   ],
   providers: [
      AlertifyService,
      Products,
      CartbasketComponent,
      User,
      {provide: LocationStrategy, useClass: HashLocationStrategy}
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {

  sum: number;



  //   ngOnInit() {
  //     this.carts = this.cartservice.carts;
  //     this.sum = this.cartservice.sumall();
  //   }



}
