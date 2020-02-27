import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CourseService {

    constructor(private http: HttpClient) {
    }

    getCourseAliases(): Observable<string[]> {
        return this.http.get<string[]>(`${environment.apiUrl}/api/course/alias`)
        .pipe(first());
    }
}
