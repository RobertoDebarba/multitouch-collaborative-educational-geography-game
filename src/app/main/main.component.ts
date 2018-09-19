import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  public states = [
      {
          name: 'Acre',
          uf: 'ac',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'AC.png',
          x: 0,
          y: 0
      },
      {
          name: 'Alagoas',
          uf: 'al',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'AL.png',
          x: 0,
          y: 0
      },
      {
          name: 'Amazonas',
          uf: 'am',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'AM.png',
          x: 0,
          y: 0
      },
      {
          name: 'Amapá',
          uf: 'ap',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'AP.png',
          x: 0,
          y: 0
      },
      {
          name: 'Bahia',
          uf: 'ba',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'BA.png',
          x: 0,
          y: 0
      },
      {
          name: 'Ceará',
          uf: 'ce',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'CE.png',
          x: 0,
          y: 0
      },
      {
          name: 'Espírito Santo',
          uf: 'es',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'ES.png',
          x: 0,
          y: 0
      },
      {
          name: 'Goiás',
          uf: 'go',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'GO.png',
          x: 0,
          y: 0
      },
      {
          name: 'Maranhão',
          uf: 'ma',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'MA.png',
          x: 0,
          y: 0
      },
      {
          name: 'Minas Gerais',
          uf: 'mg',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'MG.png',
          x: 0,
          y: 0
      },
      {
          name: 'Mato Grosso do Sul',
          uf: 'ms',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'MS.png',
          x: 0,
          y: 0
      },
      {
          name: 'Mato Grosso',
          uf: 'mt',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'MT.png',
          x: 0,
          y: 0
      },
      {
          name: 'Pará',
          uf: 'pa',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'PA.png',
          x: 0,
          y: 0
      },
      {
          name: 'Paraíba',
          uf: 'pb',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'PB.png',
          x: 0,
          y: 0
      },
      {
          name: 'Pernambuco',
          uf: 'pe',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'PE.png',
          x: 0,
          y: 0
      },
      {
          name: 'Piauí',
          uf: 'pi',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'PI.png',
          x: 0,
          y: 0
      },
      {
          name: 'Paraná',
          uf: 'pr',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'PR.png',
          x: 0,
          y: 0
      },
      {
          name: 'Rio de Janeiro',
          uf: 'rj',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'RJ.png',
          x: 0,
          y: 0
      },
      {
          name: 'Rio Grande do Norte',
          uf: 'rn',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'RN.png',
          x: 0,
          y: 0
      },
      {
          name: 'Rondônia',
          uf: 'ro',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'RO.png',
          x: 0,
          y: 0
      },
      {
          name: 'Roraima',
          uf: 'rr',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'RR.png',
          x: 0,
          y: 0
      },
      {
          name: 'Rio Grande do Sul',
          uf: 'rs',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'RS.png',
          x: 0,
          y: 0
      },
      {
          name: 'Santa Catarina',
          uf: 'sc',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'SC.png',
          x: 0,
          y: 0
      },
      {
          name: 'Sergipe',
          uf: 'se',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'SE.png',
          x: 0,
          y: 0
      },
      {
          name: 'São Paulo',
          uf: 'sp',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'SP.png',
          x: 0,
          y: 0
      },
      {
          name: 'Tocantins',
          uf: 'to',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'TO.png',
          x: 0,
          y: 0
      },
  ];

  constructor() {
  }

  ngOnInit() {

  }

  getRandom(): number {
      return Math.random() * (80 - 20);
  }

  onDragBegin($event) {

  }

  onDragEnd($event) {

  }

  onMoving($event) {

  }

  onMoveEnd($event) {

  }

}
