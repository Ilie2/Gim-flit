﻿using GymFit.Models;
using Microsoft.AspNet.OData;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public async Task<IHttpActionResult> Put(int key, CourseSchedule course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != course.ID)
            {
                return BadRequest();
            }

            var existingCourse = await db.CourseSchedules.FindAsync(key);
            if (existingCourse == null)
            {
                return NotFound();
            }

            db.Entry(existingCourse).CurrentValues.SetValues(course);
            await db.SaveChangesAsync();

            return Updated(course);
        }

        public async Task<IHttpActionResult> Delete(int key)
        {
            var courseSchedule = await db.CourseSchedules.FindAsync(key);
            if (courseSchedule == null)
            {
                return NotFound();
            }

            db.CourseSchedules.Remove(courseSchedule);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
