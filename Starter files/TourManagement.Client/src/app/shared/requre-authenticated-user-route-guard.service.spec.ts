import { TestBed, inject } from '@angular/core/testing';

import { RequreAuthenticatedUserRouteGuardService } from './requre-authenticated-user-route-guard.service';

describe('RequreAuthenticatedUserRouteGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RequreAuthenticatedUserRouteGuardService]
    });
  });

  it('should be created', inject([RequreAuthenticatedUserRouteGuardService], (service: RequreAuthenticatedUserRouteGuardService) => {
    expect(service).toBeTruthy();
  }));
});
