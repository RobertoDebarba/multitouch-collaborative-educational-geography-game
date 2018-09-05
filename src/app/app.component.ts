import {Component} from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    eventText = '';

    constructor() {
    }

    onPan(evt) {
        this.eventText += `(${evt.center.x}, ${evt.center.y})<br/>`;
    }
}
