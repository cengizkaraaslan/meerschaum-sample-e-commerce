/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductorderService } from './productorder.service';

describe('Service: Productorder', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductorderService]
    });
  });

  it('should ...', inject([ProductorderService], (service: ProductorderService) => {
    expect(service).toBeTruthy();
  }));
});
