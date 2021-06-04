/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MotherCategoryService } from './MotherCategory.service';

describe('Service: MotherCategory', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MotherCategoryService]
    });
  });

  it('should ...', inject([MotherCategoryService], (service: MotherCategoryService) => {
    expect(service).toBeTruthy();
  }));
});
