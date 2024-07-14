import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  deleteAuthor(id: number) {
    throw new Error('Method not implemented.');
  }
  getAuthors: any;
  addAuthor: any;
  updateAuthor: any;

  constructor() { }
}
