import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from 'src/models/Cliente';
import {take} from 'rxjs/operators'

@Injectable()
export class ClienteService {
  baseURL = 'https://localhost:7264/api/cliente';

constructor(private http: HttpClient) { }

  public getClientes(): Observable<Cliente[]>
  {
    return this.http.get<Cliente[]>(this.baseURL).pipe(take(1));
  }

  public getClienteById(id: number): Observable<Cliente>
  {
    return this.http.get<Cliente>(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public post(cliente: Cliente): Observable<Cliente>
  {
    return this.http.post<Cliente>(this.baseURL, cliente).pipe(take(1));
  }

  public put(cliente: Cliente): Observable<Cliente>
  {
    return this.http.put<Cliente>(`${this.baseURL}/${cliente.idCliente}`, cliente).pipe(take(1));
  }

  public delete(id: number): Observable<Cliente>
  {
    return this.http.delete<Cliente>(`${this.baseURL}/${id}`).pipe(take(1))
  }
}
