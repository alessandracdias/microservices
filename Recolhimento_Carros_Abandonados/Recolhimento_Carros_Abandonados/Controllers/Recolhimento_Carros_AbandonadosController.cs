using Recolhimento_Carros_Abandonados.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;


namespace Recolhimento_Carros_Abandonados.Controllers
{
    public class Recolhimento_Carros_AbandonadosController : ODataController
    {
        Recolhimento_Carros_AbandonadosContext db = new Recolhimento_Carros_AbandonadosContext();

        private bool CarrosExists(int key)
        {
            return db.Carros.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {

            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<RecolhimentoCarrosAbandonados> Get()
        {
            return db.Carros;
        }

        [EnableQuery]
        public SingleResult<RecolhimentoCarrosAbandonados> Get([FromODataUri] int key)
        {
            IQueryable<RecolhimentoCarrosAbandonados> result = db.Carros.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<RecolhimentoCarrosAbandonados> GetData([FromODataUri] int key)
        {
            IQueryable<RecolhimentoCarrosAbandonados> result = db.Carros.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(RecolhimentoCarrosAbandonados carros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Carros.Add(carros);
            await db.SaveChangesAsync();
            return Created(carros);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, RecolhimentoCarrosAbandonados update)
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
                if (!CarrosExists(key))
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
            var carros = await db.Carros.FindAsync(key);
            if (carros == null)
            {
                return NotFound();
            }
            db.Carros.Remove(carros);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
