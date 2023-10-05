import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Quote } from '../models/quote';
import { QuoteRequest } from '../models/quote-request';

@Injectable({
  providedIn: 'root'
})

export class QuotesService {

  private baseUrl: string = "https://localhost:7294/";

  constructor(private http: HttpClient) {}

  getAll(): Observable<Quote[]> {
    return this.http.get<Quote[]>(this.baseUrl + "api/quotes");
  }

  create(quote: QuoteRequest): Observable<Quote> {
    return this.http.post<Quote>(this.baseUrl + "api/quotes", quote);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + `api/quotes/${id}`);
  }

  getById(id: number): Observable<Quote> {
    return this.http.get<Quote>(this.baseUrl + `api/quotes/${id}`);
  }

  update(quote: Quote): Observable<any> {
    return this.http.put<any>(this.baseUrl + `api/quotes`, quote);
  }

}

