import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

import { Veiculo } from '../entities/veiculo';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class VeiculoService {

    private veiculosUrl = 'api/veiculos';  // URL to web api

    constructor(private http: HttpClient) { }

    /** GET veiculos from the server */
    getVeiculos(): Observable<Veiculo[]> {
        return this.http.get<Veiculo[]>(this.veiculosUrl);
    }

    /** GET veiculo by id. Will 404 if id not found */
    getVeiculo(id: number): Observable<Veiculo> {
        const url = `${this.veiculosUrl}/${id}`;
        return this.http.get<Veiculo>(url);
    }

    /* GET veiculos whose name contains search term */
    searchVeiculos(term: string): Observable<Veiculo[]> {
        if (!term.trim()) {
            // if not search term, return empty veiculo array.
            return of([]);
        }
        return this.http.get<Veiculo[]>(`api/veiculos/?placa=${term}`);
    }

    //////// Save methods //////////

    /** POST: add a new veiculo to the server */
    addVeiculo(veiculo: Veiculo): Observable<Veiculo> {
        return this.http.post<Veiculo>(this.veiculosUrl, veiculo, httpOptions);
    }

    /** DELETE: delete the veiculo from the server */
    deleteVeiculo(veiculo: Veiculo | number): Observable<Veiculo> {
        const id = typeof veiculo === 'number' ? veiculo : veiculo.id;
        const url = `${this.veiculosUrl}/${id}`;

        return this.http.delete<Veiculo>(url, httpOptions);
    }

    /** PUT: update the veiculo on the server */
    updateVeiculo(veiculo: Veiculo): Observable<any> {
        return this.http.put(this.veiculosUrl, veiculo, httpOptions);
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
    }
}


/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/