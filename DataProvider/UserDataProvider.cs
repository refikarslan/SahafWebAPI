using SahafWebAPI.Models;
using System.Data;

namespace SahafWebAPI.DataProvider
{

        public interface IUserDataProvider
        {
            string Create(Kullanici kullanici);
            List<Kullanici> GetList();
            Kullanici Get(int id);
            void Update(Kullanici kullanici);
            void Delete(int id);

        }

        public class UserDataProvider : IUserDataProvider
        {
        protected readonly LibraryContext context;
        public UserDataProvider(LibraryContext context)
        {
            this.context = context;
        }
            public string Create(Kullanici kullanici)

            {

                context.Kullanici.Add(kullanici);
                context.SaveChanges();
                return "Kullanıcı Başarıyla Eklendi";
            }

            public void Delete(int id)
            {
                var kullanici = context.Kullanici.FirstOrDefault(k => k.Id == id);
                if (kullanici != null)
                  {
                   context.Remove(kullanici);
                   context.SaveChanges();
                  } 
            }

            public Kullanici Get(int id)
            {
                var kullanici = context.Kullanici.FirstOrDefault(k => k.Id == id);
            
                if (kullanici != null )
                 {
                   return kullanici;
                 }
            else
            {
                return new Kullanici();
            }
            }

            public List<Kullanici> GetList()
            {
            var kullanici = context.Kullanici.ToList();
            if (kullanici != null)
            {
                return kullanici;
            }
            else
            {
                return new List<Kullanici>();
            }
            }

           public void Update(Kullanici kullanici)
           {
            
       
            context.Kullanici.Update(kullanici);
            context.SaveChanges();
           }
    }

}
