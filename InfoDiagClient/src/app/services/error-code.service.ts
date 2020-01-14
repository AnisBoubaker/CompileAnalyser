import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ErrorCode } from '../generic/models/errorCode';

@Injectable({ providedIn: 'root' })
export class ErrorCodeService {

    constructor(private http: HttpClient) {
    }

    getErrorCodes(): Observable<ErrorCode[]> {
        return this.http.get<ErrorCode[]>(`${environment.apiUrl}/api/errorcode/all`)
        .pipe(first());
    }

    seed(): Observable<void> {
        return this.http.post<void>(`${environment.apiUrl}/api/errorcode/seed`, {})
        .pipe(first());
    }
}
