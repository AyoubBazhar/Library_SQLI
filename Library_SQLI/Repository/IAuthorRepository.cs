using Library_SQLI.Models;

namespace Library_SQLI.Repository
{
    public interface IAuthorRepository
    {
        public void AddAuthor(Author a);
        void RemoveAuthor(Author author);
        void UpdateAuthor(Author author);

        public IList<Author> GetAuthorList();
        public Boolean Existe(Author a1);

        Author GetAuthorById(int id);

    }
}
