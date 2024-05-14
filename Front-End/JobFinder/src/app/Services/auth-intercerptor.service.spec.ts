import { TestBed } from '@angular/core/testing';

import { AuthIntercerptorService } from './auth-intercerptor.service';

describe('AuthIntercerptorService', () => {
  let service: AuthIntercerptorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthIntercerptorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
