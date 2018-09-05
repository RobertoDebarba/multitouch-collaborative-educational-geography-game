import {Component} from '@angular/core';

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {

    public eventText = '';
    public isDragging = false;

    private lastPosX = 0;
    private lastPosY = 0;

    constructor() {
    }

    onPan(evt) {
        this.eventText += `(${evt.center.x}, ${evt.center.y})<br/>`;

        let elem = evt.target;

        console.log(this.lastPosX);
        console.log(this.lastPosY);

        if (!this.isDragging) {
            this.isDragging = true;
            this.lastPosX = elem.offsetLeft;
            this.lastPosY = elem.offsetTop;
        }

        let posX = evt.deltaX + this.lastPosX;
        let posY = evt.deltaY + this.lastPosY;

        elem.style.left = posX + 'px';
        elem.style.top = posY + 'px';

        if (evt.isFinal) {
            this.isDragging = false;
        }
    }
}
