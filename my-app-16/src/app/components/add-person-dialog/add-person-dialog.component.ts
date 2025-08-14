import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Person } from 'src/app/services/people.service';

@Component({
  selector: 'app-add-person-dialog',
  templateUrl: './add-person-dialog.component.html',
  styleUrls: ['./add-person-dialog.component.css']
})
export class AddPersonDialogComponent {

  newPerson: Person = { id: 0, idNumber: 0, name: '', email: '', phone: '' };
  errors: { [key: string]: string } = {};

  constructor(public dialogRef: MatDialogRef<AddPersonDialogComponent>) {}

  validate(person: Person): { [key: string]: string } {
    const errors: { [key: string]: string } = {};
    
    if (!person.idNumber || !this.validateID(person.idNumber.toString())) {
      errors['idNumber'] = 'Invalid Israeli ID number.';
    }
    if (!person.name) {
      errors['name'] = 'Name is required.';
    }

   if ((person.email)&&!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(person.email)) {
      errors['email'] = 'Invalid email address. E.g. example@email.com';
    }


    if ((person.phone)&&!/^05?[0-9]-?[0-9]{7}$/i.test(person.phone)) {
      errors['phone'] = 'Invalid phone number';
    }

    if (!person.idNumber || person.idNumber <= 0) {
      errors['idNumber'] = 'Valid ID Number is required.';
    }

    return errors;
  }

  save() {
    this.errors = this.validate(this.newPerson);
    if (Object.keys(this.errors).length === 0) {
      this.dialogRef.close(this.newPerson);
    }
  }

  cancel() {
    this.dialogRef.close(null);
  }
  validateID(id: string): boolean {
    id = id.padStart(9, '0');
  
    if (!/^\d{9}$/.test(id)) return false; 
  
    let sum = 0;
    for (let i = 0; i < 9; i++) {
      let num = Number(id.charAt(i));
      let step = num * ((i % 2) + 1); 
  
      sum += step > 9 ? step - 9 : step;
    }
  
    return sum % 10 === 0;
  }
}

