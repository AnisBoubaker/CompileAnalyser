import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../generic/models/user';
import { environment } from '../../environments/environment';
import { decode } from 'jsonwebtoken';
import { TokenContainer } from '../generic/models/tokenContainer';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<TokenContainer>;
    public currentUserToken: Observable<TokenContainer>;
    private currentUser = undefined;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<TokenContainer>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUserToken = this.currentUserSubject.asObservable();
        this.currentUserSubject.subscribe((x) => this.currentUser = undefined);
    }

    public get currentUserValue(): User {
        if (!this.currentUser) {
            if (this.currentUserSubject.value) {
                this.currentUser = decode(this.currentUserSubject.value.token) as any;
            } else {
                return null;
            }
        }
        return this.currentUser as User;
    }

    public get currentToken(): TokenContainer {
        return this.currentUserSubject.value;
    }

    public login(username, password) {
        return this.http.post<any>(`${environment.apiUrl}/api/login`, { email: username, password: password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    public logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
