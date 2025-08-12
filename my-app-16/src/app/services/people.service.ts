import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Person {
  id :number;
  idNumber: number;
  name: string;
  email: string;
  phone: string;
}
@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  private apiUrl = 'https://localhost:7146/Person';  

  constructor(private http: HttpClient) {}

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.apiUrl}/GetAll`);
  }

  add(person: Person): Observable<any> {
    return this.http.post(`${this.apiUrl}/AddPerson`, person);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
