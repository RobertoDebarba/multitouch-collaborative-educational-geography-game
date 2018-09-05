import {
    trigger,
    state,
    style,
    animate,
    transition,
} from '@angular/animations';

export class Indicator {
    public gestureIndicators = [];

    public hide(gestureIndicator) {
        const self = this;
        setTimeout(() => {
            if (gestureIndicator) {
                gestureIndicator.state = 'hidden';
                setTimeout(() => {
                    if (gestureIndicator) {
                        for (let i = 0; i < self.gestureIndicators.length; i++) {
                            const indicator = self.gestureIndicators[i];
                            if (
                                indicator.x === gestureIndicator.x &&
                                indicator.y === gestureIndicator.y
                            ) {
                                self.gestureIndicators.splice(i, 1);
                                break;
                            }
                        }
                    }
                }, 250);
            }
        }, 500);
    }

    public display(x: number, y: number, size: number) {
        if (x > 0 && y > 0) {
            const gestureIndicator = {
                x: x,
                y: y,
                size: size,
                state: 'hidden',
            };

            this.gestureIndicators.push(gestureIndicator);
            const self = this;
            setTimeout(() => {
                gestureIndicator.state = 'visible';
            }, 100);
            return gestureIndicator;
        }
        return null;
    }
}

export const IndicatorAnimations = [
    trigger('indicatorState', [
        state(
            'hidden',
            style({
                transform: 'scale(0, 0)',
            }),
        ),
        state(
            'visible',
            style({
                transform: 'scale(1, 1)',
            }),
        ),
        transition('hidden => visible', animate('150ms ease-in')),
        transition('visible => hidden', animate('150ms ease-out')),
    ]),
];
