import { TestBed } from '@angular/core/testing';
import { AuthGuard } from './auth.guard';
import { Router } from '@angular/router';
import { StorageService } from '../services/storage.service';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

describe('AuthGuard', () => {
  let authGuard: AuthGuard;
  let storageService: jasmine.SpyObj<StorageService>;
  let router: jasmine.SpyObj<Router>;

  beforeEach(() => {
    // Create a mock StorageService with a spy for getItem
    storageService = jasmine.createSpyObj('StorageService', ['getItem']);
    // Create a mock Router with a spy for navigate
    router = jasmine.createSpyObj('Router', ['navigate']);

    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: StorageService, useValue: storageService },
        { provide: Router, useValue: router }
      ]
    });

    authGuard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(authGuard).toBeTruthy();
  });

  it('should allow navigation if token exists', () => {
    // Mock getItem to return a token
    storageService.getItem.and.returnValue('token');
    
    // Create mock ActivatedRouteSnapshot and RouterStateSnapshot
    const routeSnapshot = {} as ActivatedRouteSnapshot;
    const stateSnapshot = {} as RouterStateSnapshot;

    // Call the canActivate method
    const result = authGuard.canActivate(routeSnapshot, stateSnapshot);
    expect(result).toBeTrue();
  });

  it('should prevent navigation if token does not exist', () => {
    // Mock getItem to return null (no token)
    storageService.getItem.and.returnValue(null);
    
    // Create mock ActivatedRouteSnapshot and RouterStateSnapshot
    const routeSnapshot = {} as ActivatedRouteSnapshot;
    const stateSnapshot = {} as RouterStateSnapshot;

    // Call the canActivate method
    const result = authGuard.canActivate(routeSnapshot, stateSnapshot);
    expect(result).toBeFalse();
    expect(router.navigate).toHaveBeenCalledWith(['/login']);
  });
});
