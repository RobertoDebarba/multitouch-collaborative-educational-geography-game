import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppComponent} from './app.component';
import {AngularDraggableModule} from 'angular2-draggable';
import { MainComponent } from './main/main.component';
import { RouterModule, Routes } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { StartComponent } from './start/start.component';

const appRoutes: Routes = [
    { path: '', component: StartComponent},
    { path: 'game', component: MainComponent}
  ];

@NgModule({
    declarations: [
        AppComponent,
        MainComponent,
        StartComponent
    ],
    imports: [
        BrowserModule,
        AngularDraggableModule,
        RouterModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [{provide: APP_BASE_HREF, useValue : '/' }],
    bootstrap: [AppComponent]
})
export class AppModule {
}
