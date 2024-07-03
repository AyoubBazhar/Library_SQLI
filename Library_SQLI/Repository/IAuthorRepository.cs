using Library_SQLI.Models;

namespace Library_SQLI.Repository
{
    public interface IAuthorRepository
    {
        public void AddAuthor(Author a);
        public void RemoveAuthor(Author a);
        public void UpdateAuthor();

        public IList<Author> GetAuthorList();
        public Boolean Existe(Author a1);

    }
}
