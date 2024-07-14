using Library_Sqli_Api.Models;

namespace Library_Sqli_Api.Repository
{
    public interface IAuthorRepository
    {
        public void AddAuthor(Author a);
        void RemoveAuthor(Author author);
        void UpdateAuthor(Author author);

        public IList<Author> GetAuthorList();
        public Boolean Existe(Author a1);

        Author GetAuthorById(int id);
        Author GetAuthorWithBooks(int id);
    }
}
