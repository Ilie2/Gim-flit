using GymFit.Models;
using Microsoft.AspNet.OData;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace GymFit.Controllers
{
    public class TrainersController : ODataController
    {
        private readonly GymFitContext _db;

        // Use constructor injection for dependency management
        public TrainersController(GymFitContext context)
        {
            _db = context;
        }

        // Ensure proper disposal of the DbContext
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        [EnableQuery(PageSize = 50)]  // Enable pagination with a page size of 50
        public IQueryable<Trainer> Get()
        {
            return _db.Trainers;
        }

        [EnableQuery]
        public async Task<SingleResult<Trainer>> Get([FromODataUri] int key)
        {
            var result = _db.Trainers.Where(t => t.id == key);
            return SingleResult.Create(result);
        }

       public async Task<IHttpActionResult> Post(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _db.Trainers.Add(trainer);
                await _db.SaveChangesAsync();
                return Created(trainer);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Trainer> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainer = await _db.Trainers.FindAsync(key);
            if (trainer == null)
            {
                return NotFound();
            }

            patch.Patch(trainer);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                System.Diagnostics.Trace.TraceError(ex.ToString());
                return InternalServerError(ex);
            }

            return Updated(trainer);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var trainer = await _db.Trainers.FindAsync(key);
            if (trainer == null)
            {
                return NotFound();
            }

            _db.Trainers.Remove(trainer);
            await _db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
