using IPTU.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace IPTU.Controllers
{
    public class IPTUController : ODataController
    {
        IPTUContext db = new IPTUContext();

        private bool IPTUExists(int key)
        {
            return db.IPTU.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<IPTU> Get()
        {
            return db.IPTU;
        }

        [EnableQuery]
        public SingleResult<IPTU> Get([FromODataUri] int key)
        {
            IQueryable<IPTU> result = db.IPTU.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<IPTU> GetData([FromODataUri] int numero)
        {
            IQueryable<IPTU> result = db.IPTU.Where(p => p.Numero == numero);
            return SingleResult.Create(result);
        }
    }
}
