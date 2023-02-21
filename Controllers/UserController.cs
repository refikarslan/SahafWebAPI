using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Mvc;
using SahafWebAPI.DataProvider;
using SahafWebAPI.Models;
using System.Xml.Linq;

namespace SahafWebAPI.Controllers
{
     [ApiController]
        [Route("[controller]")]
        public class UserController : ControllerBase
        {
            private readonly IUserDataProvider user;
            public UserController(IUserDataProvider user)
            {
                this.user = user;
            }

            [HttpGet]
            public List<Kullanici> Get()
            {
                return user.GetList();
            }

            [HttpGet("{id}")]
            public Kullanici Get(int id)
            {
                return user.Get(id);
            }

        [HttpPost]
        public void Post([FromBody] Kullanici kullanici)
        {

            user.Create(kullanici);


        }

            [HttpPut("{id}")]
            public void Put(Kullanici kullanici)
            {
                user.Update(kullanici);
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
              user.Delete(id);
            }
        }
    }

