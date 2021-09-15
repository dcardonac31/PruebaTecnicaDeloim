import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AfiliadoData, AfiliadoResponse } from '../interfaces/afiliado.interface';

@Injectable({
  providedIn: 'root'
})
export class AfiliadoService {

  private apiUrl: string = 'https://localhost:5001/api';

  public afiliadoResponse: AfiliadoResponse[] = []
  public afiliadoData: AfiliadoResponse[] = []

  constructor( private http: HttpClient) {

   }

  getListAfiliado(page: number, limit: number) : Observable<AfiliadoResponse> {
    page = 1;
    limit=100;
    const url = `${ this.apiUrl}/Afiliados/${page}/${limit}`;

    return this.http.get<AfiliadoResponse>( url );
  }

  getAfiliadoById(id: number) : Observable<AfiliadoData> {
    const url = `${ this.apiUrl}/Afiliados/${id}`;

    return this.http.get<AfiliadoData>( url );
  }


  getListAfiliadoDapper(city: string, year: number) : Observable<AfiliadoResponse> {
    const url = `${ this.apiUrl}/DapperUtilities/GetListAfiliado/${city}/${year}`;

    return this.http.get<AfiliadoResponse>( url );
  }

  post(afiliadoData : any): Observable<AfiliadoResponse> {
    const url = `${ this.apiUrl}/Afiliados`
    return this.http.post<AfiliadoResponse>(url, afiliadoData);
  }

  put(id:number, afiliadoData: any): Observable<AfiliadoResponse> {
    const url = `${ this.apiUrl}/Afiliados`
    return this.http.put<AfiliadoResponse>(`${url}/${id}`, afiliadoData);
  }

  delete(id: number): Observable<AfiliadoResponse> {
    const url = `${ this.apiUrl}/Afiliados`
    return this.http.delete<AfiliadoResponse>(`${url}/${id}`);
  }

}
