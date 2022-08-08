using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameApplication.DAL;
using GameApplication.Models;
namespace GameApplication.Controllers
{
    public class GameController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Game
        public ActionResult Index()
        {
            var games = unitOfWork.GameRepository.Get();
            return View(games.ToList());
        }
        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = unitOfWork.GameRepository.GetByID(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }
        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GameRepository.Insert(game);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(game);
        }
        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = unitOfWork.GameRepository.GetByID(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }
        // POST: Game/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GameRepository.Update(game);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(game);
        }
        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = unitOfWork.GameRepository.GetByID(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }
        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = unitOfWork.GameRepository.GetByID(id);
            unitOfWork.GameRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}