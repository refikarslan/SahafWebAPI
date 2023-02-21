using SahafWebAPI.Models;

namespace SahafWebAPI.DataProvider
{

    public interface IBookStoreDataProvider
    {
        string Create(Kitapci kitapci);
        List<Kitapci> GetList();
        Kitapci Get(int id);
        void Update(Kitapci kitapci);
        void Delete(int id);

    }
    public class BookStoreDataProvider : IBookStoreDataProvider
    {
        protected readonly LibraryContext context;
        public BookStoreDataProvider(LibraryContext context)
        {
            this.context = context;
        }

        public string Create(Kitapci kitapci)
        {
            context.Kitapci.Add(kitapci);
            context.SaveChanges();
            return "Kitapçı Başarıyla Eklendi";
        }

        public void Delete(int id)
        {
            var kitapci = context.Kitapci.FirstOrDefault(d => d.Id == id);
            if (kitapci != null)
            {
                context.Kitapci.Remove(kitapci);
                context.SaveChanges();
            }
        }

        public Kitapci Get(int id)
        {
            var kitapci = context.Kitapci.FirstOrDefault(f => f.Id == id);
            if (kitapci != null)
            {
                return kitapci;
            }
            else
            {
                return new Kitapci();
            }
        }

        public List<Kitapci> GetList()
        {
            var kitapci = context.Kitapci.ToList();
            if (kitapci != null)
            {
                return kitapci;
            }
            else
            {
                return new List<Kitapci>();
            }
        }

        public void Update(Kitapci kitapci)
        {
            context.Kitapci.Update(kitapci);
            context.SaveChanges();
        }
    }
}
