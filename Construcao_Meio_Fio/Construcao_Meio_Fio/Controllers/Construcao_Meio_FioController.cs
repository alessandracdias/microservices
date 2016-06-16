using Construcao_Meio_Fio.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Construcao_Meio_Fio.Controllers
{
    public class Construcao_Meio_FioController : ODataController
    {
        Construcao_Meio_FioContext db = new Construcao_Meio_FioContext();

        private bool MeioFioExists(int key)
        {
            return db.Construcoes.Any(p => p.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<ConstrucaoMeioFio> Get()
        {
            return db.Construcoes;
        }

        [EnableQuery]
        public SingleResult<ConstrucaoMeioFio> Get([FromODataUri] int key)
        {
            IQueryable<ConstrucaoMeioFio> result = db.Construcoes.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<ConstrucaoMeioFio> GetData([FromODataUri] int key)
        {
            IQueryable<ConstrucaoMeioFio> result = db.Construcoes.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(ConstrucaoMeioFio construcao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Construcoes.Add(construcao);
            await db.SaveChangesAsync();
            return Created(construcao);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, ConstrucaoMeioFio update)
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
                if (!MeioFioExists(key))
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
            var construcao = await db.Construcoes.FindAsync(key);
            if (construcao == null)
            {
                return NotFound();
            }
            db.Construcoes.Remove(construcao);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
