import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../Environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
	providedIn: 'root'
})
export class ApiService {
  public httpHeaders: HttpHeaders = new HttpHeaders({
  	'Content-Type': 'application/json',
  	'Accept': 'application/json'});

  public constructor(private http: HttpClient) {
  }

  public get<T>(url: string, params: HttpParams = new HttpParams()): Observable<T> {
  	return this.http.get<T>(`${environment.baseUrl}/api/${url}`, { headers: this.httpHeaders, params });
  }

  public post<T>(url: string, data: Object = { }): Observable<T> {
  	return this.http.post<T>(`${environment.baseUrl}/api/${url}`, JSON.stringify(data), { headers: this.httpHeaders });
  }

  public put<T>(url: string, data: Object = { }): Observable<T> {
  	return this.http.put<T>(`${environment.baseUrl}/api/${url}`, JSON.stringify(data), { headers: this.httpHeaders  });
  }

  public delete<T>(url: string): Observable<T> {
  	return this.http.delete<T>(`${environment.baseUrl}/api/${url}`, { headers: this.httpHeaders });
  }
}
