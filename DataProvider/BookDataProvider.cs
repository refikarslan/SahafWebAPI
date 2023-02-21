using SahafWebAPI.Models;

namespace SahafWebAPI.DataProvider
{
    public interface IBookDataProvider
    {
        string Create(Kitap kitap);
        List<Kitap> GetList();
        Kitap Get(int id);
        void Update (Kitap kitap);
        void Delete(int id);

    }
    public class BookDataProvider : IBookDataProvider
    {
        protected readonly LibraryContext context;
        public BookDataProvider(LibraryContext context)
        {
            this.context = context;
        }
        public string Create(Kitap kitap)
        {   
            context.Kitap.Add(kitap);
            context.SaveChanges();
            
            return "Kitap Başarıyla Eklendi";
        }

        public void Delete(int id)
        {
            var kitap = context.Kitap.FirstOrDefault(d => d.Id == id);
            if(kitap != null)
            {
             context.Kitap.Remove(kitap);
             context.SaveChanges();
            }
            
        }

        public Kitap Get(int id)
        {
            var kitap = context.Kitap.FirstOrDefault(f => f.Id == id);
            if (kitap != null)
            {
                return kitap;
            }
            else
            {
                return new Kitap();
            }
        }

        public List<Kitap> GetList()
        {
            var kitap = context.Kitap.ToList();
            if (kitap != null)
            {
                return kitap;
            }
            else
            {
                return new List<Kitap>();
            }
      
        }

        public void Update(Kitap kitap)
        {
                context.Kitap.Update(kitap);
                context.SaveChanges();
        }
    }
}
