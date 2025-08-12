import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Person } from 'src/app/services/people.service';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent {

  constructor(public dialogRef: MatDialogRef<DeleteDialogComponent>) { }
  
  deleteY() {
    this.dialogRef.close(this);

  }

  cancel() {
    this.dialogRef.close(null);
  }


}
