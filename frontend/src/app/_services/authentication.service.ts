import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { User } from '../_models/user';
import { LoginResult } from '../_models/login_result';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private isLoggedIn: BehaviorSubject<boolean>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.isLoggedIn = new BehaviorSubject<boolean>(!!localStorage.getItem('token'));
    }

    public get $isLoggedIn(): boolean {
        return this.isLoggedIn.value;
    }

    public get token(): string {
        return localStorage.getItem('token') || '';
    }

    public get user(): any {
        const userData = localStorage.getItem('user');
        let user = null;

        try {
            user = JSON.parse(userData || '');
        } catch (err) {
            console.log(err);
        }

        return user;
    }

    login(email: string, password: string) {
        
        //LINK WITH BE    
        return this.http.post<any>(`${environment.apiUrl}/api/Authentication/login`, { email, password })
            .pipe(map((result: LoginResult) => {
                // store user details and basic auth credentials in local storage to keep user logged in between page refreshes

                if (!result ?.token) {
                    this.isLoggedIn.next(false);
                    return;
                }

                localStorage.setItem('user', JSON.stringify(result.user));
                localStorage.setItem('token', result.token);
                this.isLoggedIn.next(true);
                return result;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('token');
        localStorage.removeItem('user');

        this.isLoggedIn.next(false);
        this.router.navigate(['/login']);
    }

    register(email: string, password: string) {
        return this.http.post(`${environment.apiUrl}/api/Authentication/register`, {
            email,
            password,
            roleId: 'Student',
        }).pipe(map(() => {
            this.router.navigate(['/login']);
        }));
    }
}