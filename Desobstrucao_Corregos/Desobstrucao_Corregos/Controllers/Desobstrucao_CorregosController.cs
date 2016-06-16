using Desobstrucao_Corregos.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Desobstrucao_Corregos.Controllers
{
    public class Desobstrucao_CorregosController : ODataController
    {
        Desobstrucao_CorregosContext db = new Desobstrucao_CorregosContext();

        private bool CorregosExists(int key)
        {
            return db.Corrregos.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Desobstrucao_Corregos> Get()
        {
            return db.Corrregos;
        }

        [EnableQuery]
        public SingleResult<Desobstrucao_Corregos> Get([FromODataUri] int key)
        {
            IQueryable<Desobstrucao_Corregos> result = db.Corrregos.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<Desobstrucao_Corregos> GetData([FromODataUri] int key)
        {
            IQueryable<Desobstrucao_Corregos> result = db.Corrregos.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Desobstrucao_Corregos corregos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Corrregos.Add(corregos);
            await db.SaveChangesAsync();
            return Created(corregos);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Desobstrucao_Corregos update)
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
                if (!CorregosExists(key))
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
            var corregos = await db.Corrregos.FindAsync(key);
            if (corregos == null)
            {
                return NotFound();
            }
            db.Corrregos.Remove(corregos);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
