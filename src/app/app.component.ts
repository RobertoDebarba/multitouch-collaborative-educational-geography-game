import {Component} from '@angular/core';
import {Indicator, IndicatorAnimations} from './indicator';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    animations: IndicatorAnimations
})
export class AppComponent {
    eventText = '';
    indicators;

    constructor() {
        this.indicators = new Indicator();
    }

    onPan(evt) {
        this.eventText += `(${evt.center.x}, ${evt.center.y})<br/>`;
        const indicator = this.indicators.display(
            evt.center.x,
            evt.center.y,
            50
        );
        this.indicators.hide(indicator);
    }
}
