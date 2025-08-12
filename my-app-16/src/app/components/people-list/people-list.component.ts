import { Component, OnInit } from '@angular/core';
import { PeopleService, Person } from 'src/app/services/people.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { AddPersonDialogComponent } from '../add-person-dialog/add-person-dialog.component';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.css']
})
export class PeopleListComponent implements OnInit {
  people: Person[] = [];
  newPerson: Person = { id: 0, idNumber: 0, name: '', phone: '', email: '' };

  constructor(private peopleService: PeopleService, private dialog: MatDialog) { }

  ngOnInit() {
    this.loadPeople();
  }

  loadPeople() {
    this.peopleService.getAll().subscribe(data => this.people = data);
  }

  openAddDialog() {
    const dialogRef = this.dialog.open(AddPersonDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.addPerson(result);
      }
    });
  }




  addPerson(newPerson: Person) {
    this.peopleService.add(newPerson).subscribe({
      next: () => {
        this.loadPeople();
        this.newPerson = { id: 0, idNumber: 0, name: '', phone: '', email: '' };
      },
      error: (err) => {
        alert(err.error?.message || 'An error occurred while adding the person.');
      }
    });
  }
  
  openDeleteAddDialog(id:number) {
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deletePerson(id);
      }
    });
  }
  deletePerson(id: number) {
    this.peopleService.delete(id).subscribe(() => this.loadPeople());
  }
}



