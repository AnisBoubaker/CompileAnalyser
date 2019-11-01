import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Group } from '../generic/models/group';

@Injectable({ providedIn: 'root' })
export class CourseService {

    constructor(private http: HttpClient) {
    }

    getCourses() : Observable<Group[]> {
        return this.http.get<Group[]>(`${environment.apiUrl}/api/course/all`)
        .pipe(first());
    }
}