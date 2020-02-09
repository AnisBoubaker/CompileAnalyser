import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { first } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { Observable } from "rxjs";
import { Stats } from '../generic/models/stats';

@Injectable({ providedIn: "root" })
export class StatsService {
  constructor(private http: HttpClient) {}

  getStats(clientId: string = "", groupId: string = ""): Observable<Stats[]> {
    return this.http
      .get<Stats[]>(`${environment.apiUrl}/api/stats`, {params: {clientId: clientId, groupId: groupId}})
      .pipe(first());
  }
}
