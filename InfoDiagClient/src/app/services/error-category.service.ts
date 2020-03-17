import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ErrorCategory } from '../generic/models/errorCategory';

@Injectable({ providedIn: 'root' })
export class ErrorCategoryService {

    constructor(private http: HttpClient) {
    }

    getAll(): Observable<ErrorCategory[]> {
        return this.http.get<ErrorCategory[]>(`${environment.apiUrl}/api/errorCategory/all`)
        .pipe(first());
    }

    assign(categoryId: number, errorCodeIds: string[]): Observable<void> {
        return this.http.post<void>(`${environment.apiUrl}/api/errorCategory/assign`,
        {categoryId, errorCodeIds}).pipe(first());
    }

    unassign(errorCodeIds: string[]): Observable<void> {
        return this.http.put<void>(`${environment.apiUrl}/api/errorCategory/unassign`,
        {value: errorCodeIds}).pipe(first());
    }

    add(name: string): Observable<ErrorCategory> {
        return this.http.post<ErrorCategory>(`${environment.apiUrl}/api/errorCategory`, {value: name})
        .pipe(first());
    }

    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${environment.apiUrl}/api/errorCategory/${id}`)
        .pipe(first());
    }
}
