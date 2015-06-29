using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class LeaderBoardController : Controller
    {
        private MyDbContext db = new MyDbContext();

        //
        // GET: /LeaderBoard/

        public ActionResult Index()
        {
            return View(db.PlayerGameInfoes.ToList());
        }

        //
        // GET: /LeaderBoard/Details/5

        public ActionResult Details(int id = 0)
        {
            PlayerGameInfo playergameinfo = db.PlayerGameInfoes.Find(id);
            if (playergameinfo == null)
            {
                return HttpNotFound();
            }
            return View(playergameinfo);
        }

        //
        // GET: /LeaderBoard/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LeaderBoard/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerGameInfo playergameinfo)
        {
            if (ModelState.IsValid)
            {
                db.PlayerGameInfoes.Add(playergameinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playergameinfo);
        }

        //
        // GET: /LeaderBoard/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlayerGameInfo playergameinfo = db.PlayerGameInfoes.Find(id);
            if (playergameinfo == null)
            {
                return HttpNotFound();
            }
            return View(playergameinfo);
        }

        //
        // POST: /LeaderBoard/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerGameInfo playergameinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playergameinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playergameinfo);
        }

        //
        // GET: /LeaderBoard/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlayerGameInfo playergameinfo = db.PlayerGameInfoes.Find(id);
            if (playergameinfo == null)
            {
                return HttpNotFound();
            }
            return View(playergameinfo);
        }

        //
        // POST: /LeaderBoard/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerGameInfo playergameinfo = db.PlayerGameInfoes.Find(id);
            db.PlayerGameInfoes.Remove(playergameinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}