using Microsoft.AspNetCore.Mvc;
using SahafWebAPI.DataProvider;
using SahafWebAPI.Models;

namespace SahafWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookStoreController:ControllerBase
    {
        protected readonly IBookStoreDataProvider bookStore;
        public BookStoreController(IBookStoreDataProvider bookStore)
        {
            this.bookStore = bookStore;
        }
        [HttpGet]
        public List<Kitapci> Get()
        {
            return bookStore.GetList();
        }
        [HttpGet ("{id}")]
        public Kitapci Get(int id)
        {
            return bookStore.Get(id);
        }
        [HttpPost]
        public void Post([FromBody]Kitapci kitapci) { 
            bookStore.Create(kitapci);
        }
        [HttpPut("{id}")]
        public void Put(Kitapci kitapci)
        {
            bookStore.Update(kitapci);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookStore.Delete(id);
        }
    }
}
