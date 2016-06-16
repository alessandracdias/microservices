using Poda_Arvore.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Poda_Arvore.Controllers
{
    public class Poda_ArvoreController : ODataController
    {
        Poda_ArvoreContext db = new Poda_ArvoreContext();

        private bool PodaArvoreExists(int key)
        {
            return db.Arvores.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<PodaArvore> Get()
        {
            return db.Arvores;
        }

        [EnableQuery]
        public SingleResult<Poda_Arvore> Get([FromODataUri] int key)
        {
            IQueryable<Poda_Arvore> result = db.Arvores.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<Poda_Arvore> GetData([FromODataUri] int key)
        {
            IQueryable<Poda_Arvore> result = db.Arvores.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Poda_Arvore arvores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Arvores.Add(arvores);
            await db.SaveChangesAsync();
            return Created(arvores);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Poda_Arvore update)
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
                if (!PodaArvoreExists(key))
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
            var arvores = await db.Arvores.FindAsync(key);
            if (arvores == null)
            {
                return NotFound();
            }
            db.Arvores.Remove(arvores);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
