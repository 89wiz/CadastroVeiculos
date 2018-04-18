import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Veiculo } from "../../entities/veiculo";

import { VeiculoService } from "../../services/veiculo.service";

@Component({
    selector: 'veiculos',
    templateUrl: './veiculos.component.html'
})
export class VeiculosComponent implements OnInit {
  veiculos: Veiculo[];
  
  constructor(
    private veiculoService: VeiculoService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.listar();
  }

  listar() {
    this.veiculoService.getList().subscribe(v => this.veiculos = v);
  }

  excluir(id) {

    let exc = typeof id === 'number' ? id > 0 : false;

    if (exc) {
      let v = this.veiculoService.delete(id).subscribe(v => this.listar());
    }
  }
}
