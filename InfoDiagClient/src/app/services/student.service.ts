import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Student } from '../generic/models/student';

@Injectable({ providedIn: 'root' })
export class StudentService {

    constructor(private http: HttpClient) {
    }

    getStudents() : Observable<Student[]> {
        return this.http.get<Student[]>(`${environment.apiUrl}/api/client/all`)
        .pipe(first());
    }
}
