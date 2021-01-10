import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Parcela } from '../models/Parcela';

@Injectable({
  providedIn: 'root'
})
export class ParcelasService {

  baseUrl = `${environment.baseUrl}/parcela`;

  constructor(private http: HttpClient) { }

  getByDividaId(id: number): Observable<Parcela[]> {
    return this.http.get<Parcela[]>(`${this.baseUrl}/${id}`);
  }

  post(parcela: Parcela): Observable<Parcela> {
    return this.http.post<Parcela>(`${this.baseUrl}`, parcela);
  }
  put(parcela: Parcela): Observable<Parcela> {
    return this.http.put<Parcela>(`${this.baseUrl}`, parcela);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
