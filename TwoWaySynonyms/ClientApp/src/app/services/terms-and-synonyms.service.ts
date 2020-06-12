import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TermsAndSynonymsService {

  constructor(private httpClient: HttpClient) { }

  public get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(url, {responseType: 'json'})
  }

  public post<TReq, TRes>(
    url: string,
    body: TReq,
  ): Observable<TRes> {
    return this.httpClient.post<TRes>(url, body, {responseType: 'json'})
  }
}
