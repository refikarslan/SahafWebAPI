using SahafWebAPI.Models;

namespace SahafWebAPI.DataProvider
{
    public interface IReportDataProvider
    {
        string Create(Gunluk_Rapor rapor);
        List<Gunluk_Rapor> GetList();
        Gunluk_Rapor Get(int id);
        void Update(Gunluk_Rapor rapor);
        void Delete(int id);

    }
    public class ReportDataProvider : IReportDataProvider
    {
        protected readonly LibraryContext context;
        public ReportDataProvider(LibraryContext context)
        {
            this.context = context;
        }

        public string Create(Gunluk_Rapor rapor)
        {
            context.Gunluk_Rapor.Add(rapor);
            context.SaveChanges();
            return "Tarih Aralığı Başarıyla Eklendi";
        }

        public void Delete(int id)
        {
            var rapor = context.Gunluk_Rapor.FirstOrDefault(d => d.Id == id);
            if (rapor != null)
            {
                context.Gunluk_Rapor.Remove(rapor);
                context.SaveChanges();
            }
        }

        public Gunluk_Rapor Get(int id)
        {
            var rapor = context.Gunluk_Rapor.FirstOrDefault(x => x.Id == id);
            if (rapor != null)
            {
                return rapor;
            }
            else
            {
                return new Gunluk_Rapor();
            }
        }

        public List<Gunluk_Rapor> GetList()
        {
            var rapor = context.Gunluk_Rapor.ToList();
            if (rapor != null)
            {
                return rapor;
            }
            else
            {
                return new List<Gunluk_Rapor>();
            }
        }

        public void Update(Gunluk_Rapor rapor)
        {
            context.Gunluk_Rapor.Update(rapor);
            context.SaveChanges();

        }
    }
}
