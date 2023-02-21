using Microsoft.AspNetCore.Mvc;
using SahafWebAPI.DataProvider;
using SahafWebAPI.Models;

namespace SahafWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookDataProvider dataProvider;
        public BookController(IBookDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        [HttpGet ]
        public List<Kitap> Get()
        {
            return dataProvider.GetList();
        }
        [HttpGet("{id}")]
        public Kitap Get(int id)
        {
            return dataProvider.Get(id);
        }
        [HttpPost]
        public void Post([FromBody]Kitap kitap)
        {
            dataProvider.Create(kitap);
        }
        [HttpPut ("{id}")]
        public void Put(Kitap kitap)
        {
            dataProvider.Update(kitap);
        }
        [HttpDelete ("{id}")]
        public void Delete(int id)
        {
            dataProvider.Delete(id);
        }
    }
}
