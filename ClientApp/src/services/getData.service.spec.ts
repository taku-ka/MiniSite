
import { TestBed } from '@angular/core/testing';

import { GetDataService } from './getData.services';

describe('GetDataService', () => {
  let service: GetDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});