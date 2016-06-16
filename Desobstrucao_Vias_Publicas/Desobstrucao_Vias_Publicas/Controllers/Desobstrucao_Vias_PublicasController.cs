using Desobstrucao_Vias_Publicas.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Desobstrucao_Vias_Publicas.Controllers
{
    public class Desobstrucao_Vias_PublicasController : ODataController
    {
        Desobstrucao_Vias_PublicasContext db = new Desobstrucao_Vias_PublicasContext();

        private bool ViasPublicasExists(int key)
        {
            return db.Vias.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<DesobstrucaoViasPublicas> Get()
        {
            return db.Vias;
        }

        [EnableQuery]
        public SingleResult<DesobstrucaoViasPublicas> Get([FromODataUri] int key)
        {
            IQueryable<DesobstrucaoViasPublicas> result = db.Vias.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<DesobstrucaoViasPublicas> GetData([FromODataUri] int key)
        {
            IQueryable<DesobstrucaoViasPublicas> result = db.Vias.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(DesobstrucaoViasPublicas vias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Vias.Add(vias);
            await db.SaveChangesAsync();
            return Created(vias);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, DesobstrucaoViasPublicas update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViasPublicasExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var vias = await db.Vias.FindAsync(key);
            if (vias == null)
            {
                return NotFound();
            }
            db.Vias.Remove(vias);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
