import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppComponent} from './app.component';
import {AngularDraggableModule} from 'angular2-draggable';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule, AngularDraggableModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}
