import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { User } from '../generic/models/user';

@Injectable({ providedIn: 'root' })
export class UserService {

    constructor(private http: HttpClient) {
    }

    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(`${environment.apiUrl}/api/user/all`)
        .pipe(first());
    }
}
