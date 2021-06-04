/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CartbasketComponent } from './cartbasket.component';


describe('CartbasketComponent', () => {
  let component: CartbasketComponent;
  let fixture: ComponentFixture<CartbasketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CartbasketComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartbasketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
