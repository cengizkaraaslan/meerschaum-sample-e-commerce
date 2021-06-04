import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { AlertifyService } from '../Service/alertify.service';
import { User } from '../model/User';
import { UserService } from '../Service/User.service';
import { AuthService } from '../Service/Auth.service';

@Component({
  selector: 'app-createaccount',
  templateUrl: './createaccount.component.html',
  styleUrls: ['./createaccount.component.css'],
  providers : [UserService, User]
})
export class CreateaccountComponent implements OnInit {
  // profileForm = new FormGroup({
  //   name: new FormControl(''),
  //   surname: new FormControl(''),
  //   email: new FormControl(''),
  //   telephone: new FormControl(''),
  //   fax: new FormControl(''),
  //   company: new FormControl(''),
  //   adress1: new FormControl(''),
  //   adress2: new FormControl(''),
  //   city: new FormControl(''),
  //   postcode: new FormControl(''),
  //   country: new FormControl(''),
  //   regionstate: new FormControl(''),
  //   password: new FormControl(''),
  //   password2: new FormControl('')
  // });


  registerForm: FormGroup;
    registerUser: any = {};


  constructor(
    private alertif: AlertifyService,
     private userservices: UserService, private formBuilder: FormBuilder, private authService: AuthService ) {}

  ngOnInit() {  this.createRegisterForm(); }



  createRegisterForm() {

    this.registerForm = this.formBuilder.group(
      {
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
         regionstate: ['', Validators.required],
        password: ['', [Validators.required,
        Validators.minLength(4),
        Validators.maxLength(8)]],
        confirmPassword: ['', Validators.required]
      },
      {validator: this.passwordMatchValidator}
    );
  }

   passwordMatchValidator(g: FormGroup) {
     return g.get('password').value ===
     g.get('confirmPassword').value ? null : {mismatch: true};
   }

   register() {
     // tslint:disable-next-line:no-debugger
     debugger;
     if (this.registerForm.valid) {
       this.registerUser = Object.assign({}, this.registerForm.value);
       this.authService.register(this.registerUser);
       
     }
   }

}
