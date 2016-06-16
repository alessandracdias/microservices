using ColetaLixo.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace ColetaLixo.Controllers
{
    public class Coleta_LixoController : ODataController
    {
        ColetaLixoContext db = new ColetaLixoContext();

        private bool Coleta_LixoExists(int key)
        {
            return db.Coletas.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<ColetaLixo> Get()
        {
            return db.Coletas;
        }

        [EnableQuery]
        public SingleResult<ColetaLixo> Get([FromODataUri] int key)
        {
            IQueryable<ColetaLixo> result = db.Coletas.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<ColetaLixo> GetData([FromODataUri] string endereco)
        {
            IQueryable<ColetaLixo> result = db.Coletas.Where(p => p.Endereco == endereco);
            return SingleResult.Create(result);
        }

    }
}
