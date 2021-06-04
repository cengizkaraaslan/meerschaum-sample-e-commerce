/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UnderCategoryService } from './UnderCategory.service';

describe('Service: UnderCategory', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UnderCategoryService]
    });
  });

  it('should ...', inject([UnderCategoryService], (service: UnderCategoryService) => {
    expect(service).toBeTruthy();
  }));
});
