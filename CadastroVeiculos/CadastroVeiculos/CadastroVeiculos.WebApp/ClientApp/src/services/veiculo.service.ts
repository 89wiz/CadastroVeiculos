import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

import { Veiculo } from '../entities/veiculo';
//import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class VeiculoService {

  private veiculosUrl = 'api/veiculos';  // URL to web api

  constructor(
    private http: HttpClient) { }

  /** GET heroes from the server */
  getList(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.veiculosUrl)
      .pipe(
      tap(heroes => this.log(`fetched heroes`)),
      catchError(this.handleError('getVeiculoes', []))
      );
  }

  /** GET hero by id. Will 404 if id not found */
  get(id: number): Observable<Veiculo> {
    const url = `${this.veiculosUrl}/${id}`;
    return this.http.get<Veiculo>(url).pipe(
      tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<Veiculo>(`getVeiculo id=${id}`))
    );
  }

  //////// Save methods //////////

  /** POST: add a new hero to the server */
  save(hero: Veiculo): Observable<Veiculo> {
    return this.http.post<Veiculo>(this.veiculosUrl, hero, httpOptions).pipe(
      tap((hero: Veiculo) => this.log(`added hero w/ id=${hero.id}`)),
      catchError(this.handleError<Veiculo>('addVeiculo'))
    );
  }

  /** DELETE: delete the hero from the server */
  delete(hero: Veiculo | number): Observable<Veiculo> {
    const id = typeof hero === 'number' ? hero : hero.id;
    const url = `${this.veiculosUrl}/${id}`;

    return this.http.delete<Veiculo>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted hero id=${id}`)),
      catchError(this.handleError<Veiculo>('deleteVeiculo'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a VeiculoService message with the MessageService */
  private log(message: string) {
    console.log('VeiculoService: ' + message);
  }
}
