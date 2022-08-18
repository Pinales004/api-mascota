using AngularBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularBackEnd.Controllers
{
    public class MascotaController : ApiController
    {
        // GET: api/Mascota
        public IEnumerable<Mascotas> Get()
        {
            GestrorMascotas gestror = new GestrorMascotas();

            gestror.GetMascotas();
            return gestror.GetMascotas();
        }

        // GET: api/Mascota/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mascota
        public bool Post([FromBody]Mascotas mascotas)
        {
            GestrorMascotas gestror = new GestrorMascotas();
            bool resp = gestror.AddMascotas(mascotas);
            return resp;
        }

        // PUT: api/Mascota/5
        public bool Put(int id, [FromBody]Mascotas mascotas)
        {
            GestrorMascotas gestror = new GestrorMascotas();
            bool resp = gestror.UpdateMascotas(id,mascotas);
            return resp;
        }

        // DELETE: api/Mascota/5
        public bool Delete(int id)
        {

            GestrorMascotas gestror = new GestrorMascotas();
            bool resp = gestror.deleteMascotas(id);
            return resp;
        }
    }
}
