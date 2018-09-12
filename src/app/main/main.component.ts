import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  public states = [
      {
          name: 'Santa Catarina',
          uf: 'sc',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'SC.png',
          x: 150,
          y: 150
      },
      {
          name: 'Santa Catarina',
          uf: 'sc',
          position: {top: this.getRandom(), left: this.getRandom()},
          file: 'SC.png',
          x: 150,
          y: 150
      }
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
