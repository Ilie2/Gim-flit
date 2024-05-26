using GymFit.Models;
using Microsoft.AspNet.OData;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace GymFit.Controllers
{
    public class SubscriptionsController : ODataController
    {
        GymFitContext db = new GymFitContext();

        public SubscriptionsController() { }

        [EnableQuery]
        public IQueryable<Subscription> Get()
        {
            return db.Subscriptions;
        }

        public async Task<IHttpActionResult> Post(Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Subscriptions.Add(subscription);
            await db.SaveChangesAsync();
            return Created(subscription);
        }

        public async Task<IHttpActionResult> Put(int key, Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != subscription.ID)
            {
                return BadRequest();
            }

            var existingSubscription = await db.Subscriptions.FindAsync(key);
            if (existingSubscription == null)
            {
                return NotFound();
            }

            db.Entry(existingSubscription).CurrentValues.SetValues(subscription);
            await db.SaveChangesAsync();

            return Updated(subscription);
        }

        public async Task<IHttpActionResult> Delete(int key)
        {
            var subscription = await db.Subscriptions.FindAsync(key);
            if (subscription == null)
            {
                return NotFound();
            }

            db.Subscriptions.Remove(subscription);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
