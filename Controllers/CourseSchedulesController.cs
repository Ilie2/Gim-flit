using GymFit.Models;
using Microsoft.AspNet.OData;
using System.Web.Http;

namespace GymFit.Controllers
{
    public class CourseSchedulesController : ODataController
    {
        GymFitContext db = new GymFitContext();
        public CourseSchedulesController() { }

        [EnableQuery]
        public IQueryable<CourseSchedule> Get()
        {
            return db.CourseSchedules;
        }

        public async Task<IHttpActionResult> Post(CourseSchedule course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.CourseSchedules.Add(course);
            await db.SaveChangesAsync();
            return Created(course);
        }
    }
}
