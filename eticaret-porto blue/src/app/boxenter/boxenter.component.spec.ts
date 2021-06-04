/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BoxenterComponent } from './boxenter.component';

describe('BoxenterComponent', () => {
  let component: BoxenterComponent;
  let fixture: ComponentFixture<BoxenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoxenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoxenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
