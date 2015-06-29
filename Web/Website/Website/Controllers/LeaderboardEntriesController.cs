using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class LeaderboardEntriesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: LeaderboardEntries
        public async Task<ActionResult> Index()
        {
            return View(await db.LeaderboardEntries.ToListAsync());
        }

        // GET: LeaderboardEntries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaderboardEntry leaderboardEntry = await db.LeaderboardEntries.FindAsync(id);
            if (leaderboardEntry == null)
            {
                return HttpNotFound();
            }
            return View(leaderboardEntry);
        }

        // GET: LeaderboardEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaderboardEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Score,Initials,LevelCompleteTime,Date")] LeaderboardEntry leaderboardEntry)
        {
            if (ModelState.IsValid)
            {
                db.LeaderboardEntries.Add ( leaderboardEntry );
                db.topScoresAllTime.Add (  leaderboardEntry.Cast1() );
                db.topTimesAllTime.Add ( leaderboardEntry.Cast3 () );
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(leaderboardEntry);
        }

        // GET: LeaderboardEntries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaderboardEntry leaderboardEntry = await db.LeaderboardEntries.FindAsync(id);
            if (leaderboardEntry == null)
            {
                return HttpNotFound();
            }
            return View(leaderboardEntry);
        }

        // POST: LeaderboardEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Score,Initials,LevelCompleteTime,Date")] LeaderboardEntry leaderboardEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaderboardEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(leaderboardEntry);
        }

        // GET: LeaderboardEntries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaderboardEntry leaderboardEntry = await db.LeaderboardEntries.FindAsync(id);
            if (leaderboardEntry == null)
            {
                return HttpNotFound();
            }
            return View(leaderboardEntry);
        }

        // POST: LeaderboardEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LeaderboardEntry leaderboardEntry = await db.LeaderboardEntries.FindAsync(id);
            db.LeaderboardEntries.Remove(leaderboardEntry);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
