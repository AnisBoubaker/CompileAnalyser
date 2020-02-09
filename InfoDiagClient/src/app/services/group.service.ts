import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Group } from '../generic/models/group';
import { User } from '../generic/models/user';

@Injectable({ providedIn: 'root' })
export class GroupService {

    constructor(private http: HttpClient) {
    }

    getGroups(): Observable<Group[]> {
        return this.http.get<Group[]>(`${environment.apiUrl}/api/courseGroup/all`)
        .pipe(first());
    }

    getGroup(id: string): Observable<Group> {
        return this.http.get<Group>(`${environment.apiUrl}/api/courseGroup`, {params: {groupId: id}})
        .pipe(first());
    }

    getPermitedUsers(courseGroupId: number): Observable<User[]> {
        return this.http.get<User[]>(`{${environment.apiUrl}/api/courseGroup/users}`, {params:{courseGroupId: '' + courseGroupId}})
        .pipe(first());
    }
}