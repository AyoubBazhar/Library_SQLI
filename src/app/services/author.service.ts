import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Author } from '../models/author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private apiUrl = 'https://localhost:7238/api/authors';

  constructor(private http: HttpClient) { }

  getAuthors(includeBooks:boolean): Observable<Author[]> {
    if(!includeBooks){
      return this.http.get<Author[]>(this.apiUrl);
    }
    return this.http.get<Author[]>(this.apiUrl+"?includeBooks=true");

  }

  addAuthor(author: Author): Observable<Author> {
    return this.http.post<Author>(this.apiUrl, author, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    });
  }

  updateAuthor(id: number, author: Author): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<void>(url, author, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    });
  }

  deleteAuthor(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }
}
