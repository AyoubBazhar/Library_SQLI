import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../services/author.service';
import { Author } from '../models/author.model';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss']
})
export class AuthorComponent implements OnInit {
  authors: Author[] = [];
  newAuthor: Author = { id: 0, name: '', books: [] };
  isEditing: boolean = false;
  editAuthorId: number | null = null;

  constructor(private authorService: AuthorService) { }

  ngOnInit(): void {
    this.getAuthors();
  }
  
  getAuthors(): void {
    this.authorService.getAuthors(true).subscribe(
      (data: Author[]) => {
        console.log('Received authors:', data); // Log received authors
        // Assurez-vous que chaque auteur a une liste de livres initialisée
        this.authors = data.map(author => ({
          ...author,
          books: author.books || [] // Initialisez la propriété books en tant que tableau vide si elle est indéfinie
        }));
      },
      (error) => {
        console.error('Error fetching authors:', error); // Log any errors
      }
    );
  }
  addAuthor(): void {
    if (this.newAuthor.name.trim()) {
      this.authorService.addAuthor(this.newAuthor).subscribe((author: Author) => {
        this.authors.push(author);
        this.newAuthor = { id: 0, name: '',books: [] };
      });
    }
  }

  editAuthor(author: Author): void {
    this.newAuthor = { ...author };
    this.isEditing = true;
    this.editAuthorId = author.id;
  }

  updateAuthor(): void {
    if (this.newAuthor.name.trim() && this.editAuthorId !== null) {
      this.authorService.updateAuthor(this.editAuthorId, this.newAuthor).subscribe(() => {
        const index = this.authors.findIndex(a => a.id === this.editAuthorId);
        this.authors[index] = { ...this.newAuthor };
        this.newAuthor = { id: 0, name: '' , books: [] };
        this.isEditing = false;
        this.editAuthorId = null;
      });
    }
  }

  deleteAuthor(id: number): void {
    this.authorService.deleteAuthor(id).subscribe(() => {
      this.authors = this.authors.filter(author => author.id !== id);
    });
  }

  cancelEdit(): void {
    this.newAuthor = { id: 0, name: '' , books: [] };
    this.isEditing = false;
    this.editAuthorId = null;
  }
}
