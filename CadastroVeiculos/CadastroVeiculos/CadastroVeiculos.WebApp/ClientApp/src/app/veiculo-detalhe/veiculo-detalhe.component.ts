import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Veiculo } from "../../entities/veiculo";
import { Proprietario } from "../../entities/proprietario";
import { VeiculoFoto } from "../../entities/veiculo-foto";

import { VeiculoService } from "../../services/veiculo.service";

@Component({
    selector: 'veiculo-detalhe',
    templateUrl: './veiculo-detalhe.component.html'
})
export class VeiculoDetalheComponent implements OnInit {
  veiculo = new Veiculo();
  proprietario = new Proprietario();
  fotos: VeiculoFoto[];

  constructor(
    private veiculoService: VeiculoService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.obter(id);
  }

  salvar(v) {
    this.veiculo.proprietario = this.proprietario;
    this.veiculo.fotos = this.fotos;

    this.veiculoService.save(this.veiculo).subscribe(v => this.location.back());
  }

  obter(id) {
    let load = id != "0";

    if (load) {
      let v = this.veiculoService.get(id).subscribe(v => {
        this.veiculo = v
        this.proprietario = v.proprietario;
        this.fotos = v.fotos;
      });
    }
  }
}
