System.register(["@angular/core", "@angular/common/http", "rxjs/observable/of"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, http_1, of_1, httpOptions, VeiculoService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (of_1_1) {
                of_1 = of_1_1;
            }
        ],
        execute: function () {
            httpOptions = {
                headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' })
            };
            VeiculoService = class VeiculoService {
                constructor(http) {
                    this.http = http;
                    this.veiculosUrl = 'api/veiculos'; // URL to web api
                }
                /** GET veiculos from the server */
                getVeiculos() {
                    return this.http.get(this.veiculosUrl);
                }
                /** GET veiculo by id. Will 404 if id not found */
                getVeiculo(id) {
                    const url = `${this.veiculosUrl}/${id}`;
                    return this.http.get(url);
                }
                /* GET veiculos whose name contains search term */
                searchVeiculos(term) {
                    if (!term.trim()) {
                        // if not search term, return empty veiculo array.
                        return of_1.of([]);
                    }
                    return this.http.get(`api/veiculos/?placa=${term}`);
                }
                //////// Save methods //////////
                /** POST: add a new veiculo to the server */
                addVeiculo(veiculo) {
                    return this.http.post(this.veiculosUrl, veiculo, httpOptions);
                }
                /** DELETE: delete the veiculo from the server */
                deleteVeiculo(veiculo) {
                    const id = typeof veiculo === 'number' ? veiculo : veiculo.id;
                    const url = `${this.veiculosUrl}/${id}`;
                    return this.http.delete(url, httpOptions);
                }
                /** PUT: update the veiculo on the server */
                updateVeiculo(veiculo) {
                    return this.http.put(this.veiculosUrl, veiculo, httpOptions);
                }
                /**
                 * Handle Http operation that failed.
                 * Let the app continue.
                 * @param operation - name of the operation that failed
                 * @param result - optional value to return as the observable result
                 */
                handleError(operation = 'operation', result) {
                    return (error) => {
                        // TODO: send the error to remote logging infrastructure
                        console.error(error); // log to console instead
                        // TODO: better job of transforming error for user consumption
                        this.log(`${operation} failed: ${error.message}`);
                        // Let the app keep running by returning an empty result.
                        return of_1.of(result);
                    };
                }
                /** Log a VeiculoService message with the MessageService */
                log(message) {
                }
            };
            VeiculoService = __decorate([
                core_1.Injectable()
            ], VeiculoService);
            exports_1("VeiculoService", VeiculoService);
            /*
            Copyright 2017-2018 Google Inc. All Rights Reserved.
            Use of this source code is governed by an MIT-style license that
            can be found in the LICENSE file at http://angular.io/license
            */ 
        }
    };
});
