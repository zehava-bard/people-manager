import { Component } from "@angular/core";


@Component({
templateUrl:"app.component.html",
selector:"app-root"
})

export class AppComponent {
x:number=5;
title:string="hello My- App"

calc(){
    return 0;
}
/**
 *
 */
constructor() {

    
}
}