import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../_services/authentication.service';

@Injectable({
    providedIn: "root"
})
export class CheckGuard implements CanActivate {
    constructor(private router: Router, private authenticationService: AuthenticationService) { }
    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const isLoggedIn = this.authenticationService.$isLoggedIn;
        if (isLoggedIn) {
            this.router.navigate(['/dashboard']); //if it's already logged
            return false;
        }
        return true;
    }
}