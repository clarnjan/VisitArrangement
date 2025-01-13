import { TestBed } from '@angular/core/testing';

import { ArrangementApiService } from './arrangement-api.service';

describe('ArrangementApiService', () => {
  let service: ArrangementApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArrangementApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
