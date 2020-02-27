import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { first } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class TermService {
  constructor(private http: HttpClient) {}

  getTerms(): Observable<string[]> {
    return this.http
      .get<string[]>(`${environment.apiUrl}/api/term`)
      .pipe(first());
  }

  createCurrentTerm(): Observable<string[]> {
    return this.http
    .post<string[]>(`${environment.apiUrl}/api/term/current`, {})
    .pipe(first());
  }
}
