import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Divida } from '../models/Divida';

@Injectable({
  providedIn: 'root'
})
export class DividasService {

  baseUrl = `${environment.baseUrl}/divida`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Divida[]> {
    return this.http.get<Divida[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Divida> {
    return this.http.get<Divida>(`${this.baseUrl}/${id}`);
  }

  post(divida: Divida) {
    return this.http.post(`${this.baseUrl}`, divida);
  }
  put(divida: Divida) {
    return this.http.put(`${this.baseUrl}`, divida);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
