import { Component, OnInit } from '@angular/core';
import { CartService } from '../Service/Cart.service';
import {
  PayPalConfig,
  PayPalEnvironment,
  PayPalIntegrationType
} from 'ngx-paypal';
import { Products } from '../model/products';
import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  FormBuilder,
  Validators
} from '@angular/forms';
import { ProductorderService } from '../Service/productorder.service';
import { AlertifyService } from '../Service/alertify.service';
import { Router } from '@angular/router';
import { Order } from '../model/Order';
import { AuthService } from '../Service/Auth.service';
import { UserService } from '../Service/User.service';
import { User } from '../model/User';
@Component({
  selector: 'app-adresses',
  templateUrl: './adresses.component.html',
  styleUrls: ['./adresses.component.css']
})
export class AdressesComponent implements OnInit {
  public payPalConfig?: PayPalConfig;
  // tslint:disable-next-line:max-line-length
  constructor(
    private cartservice: CartService,
    private productorder: ProductorderService,
    private alert: AlertifyService,
    private router: Router,
    private authservice: AuthService,
    private userservice: UserService,
    private formBuilder: FormBuilder
  ) {}
  carts: Products[] = [];
  sum: number;
  user: User;
  registerForm: FormGroup;
  registerUser: any = {};

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      name: [this.user.name, Validators.required],
      surname: [this.user.surname, Validators.required],
      email: [this.user.email, Validators.required],
      telephone: [this.user.telephone, Validators.required],
      fax: [this.user.fax, Validators.required],
      company: [this.user.company, Validators.required],
      adress1: [this.user.adress1, Validators.required],
      adress2: [this.user.adress2, Validators.required],
      city: [this.user.city, Validators.required],
      postcode: [this.user.postcode, Validators.required],
      country: [this.user.country, Validators.required],
      regionstate: [this.user.regionstate, Validators.required]
    });
  }
  createRegisterForm2() {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', Validators.required],
      telephone: ['', Validators.required],
      fax: ['', Validators.required],
      company: ['', Validators.required],
      adress1: ['', Validators.required],
      adress2: ['', Validators.required],
      city: ['', Validators.required],
      postcode: ['', Validators.required],
      country: ['', Validators.required],
      regionstate: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.initConfig();
    this.carts = this.cartservice.carts;
    this.sum = this.cartservice.sumall();
    if (this.authservice.loggedIn()) {
      this.userservice
        .getuserid(this.authservice.getCurrentUserId())
        .subscribe(res => {
          this.user = res;
          this.createRegisterForm();
        });
    } else {
      this.createRegisterForm2();
    }
  }
  convertandorder() {
    const o = new Order();
    o.name = this.registerForm.value.name;
    o.surname = this.registerForm.value.surname;
    o.adress1 = this.registerForm.value.adress1;
    o.email = this.registerForm.value.email;
    o.telephone = this.registerForm.value.telephone;
    o.adress2 = this.registerForm.value.adress2;
    o.city = this.registerForm.value.city;
    o.state = this.registerForm.value.regionstate;
    o.zip = this.registerForm.value.postcode;
    if (this.authservice.loggedIn()) {
      o.user_id = this.user.user_id;
    } else {
      o.user_id = 0;
    }

    // tslint:disable-next-line:no-unused-expression
    o.pro = this.cartservice.carts;

    this.productorder.Order(o);
  }
  // toggleButton(actions) {
  //   // if (this.profileForm.value.name !== '') {
  //   //   return actions.enable();
  //   // }
  //   return actions.disable();
  // }
  private initConfig(): void {
    this.payPalConfig = new PayPalConfig(
      PayPalIntegrationType.ClientSideREST,
      PayPalEnvironment.Sandbox,
      {
        commit: true,
        client: {
          sandbox:
            'ASsp-GopzZy652eVV_0fMVH8SZbg0cyOVjJG1EHYmvzYXhWu2GgjzLgbxX6qEvfTQc0sARHph0UW8PaZ'
        },
        button: {
          label: 'paypal',
          //  color: 'white',
          size: 'medium'
        },
        //   validate: function(actions) {
        //     this.toggleButton(actions);
        //   },
        //   onClick: function() {
        //     toggleButton();
        // },
        onPaymentComplete: (data, actions) => {
          console.log('OnPaymentComplete');
          this.convertandorder();
          this.alert.success('successful');
          this.router.navigateByUrl('/Main');
        },
        onCancel: (data, actions) => {
          this.convertandorder();
          console.log('OnCancel');
          this.alert.warning('Canceled');
        },
        onError: err => {
          console.log('OnError');
          this.alert.error('Error');
        },
        transactions: [
          {
            amount: {
              currency: 'USD',
              total: this.cartservice.sumall()
            }
          }
        ]
      }
    );
  }
}
