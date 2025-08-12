import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { PeopleListComponent } from './components/people-list/people-list.component';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from "@angular/common/http";
import { AddPersonDialogComponent } from "./components/add-person-dialog/add-person-dialog.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';

@NgModule({
    declarations:[
        AppComponent,     
        PeopleListComponent, 
        AddPersonDialogComponent, DeleteDialogComponent
    ],
    imports:[
        BrowserModule,
        FormsModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatDialogModule
    ],
    bootstrap:[AppComponent]
})

export class AppModule{

}