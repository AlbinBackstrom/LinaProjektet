using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LINAprojektet;

namespace LINAprojektet.Controllers
{
    [Authorize]
    public class ProjektController : Controller
    {
        private LINAsDatabasEntities db = new LINAsDatabasEntities();
        bool isAdmin;
        //en variabel som sparar den aktuella inloggade användarens användarnamn/email
        //Används bla. för att söka ut dens projekt.
        string username = System.Web.HttpContext.Current.User.Identity.Name;

        //public CheckIfAdmin()
        //{
        //    bool isAdmin = User.IsInRole("Admin");
        //    ViewBag.seeIfAdmin = isAdmin;
        //    return ;
            
        //}

        

        // GET: Projekt
        //Är admin inloggad hämtas alla projekt som finns lagrade för alla användare.
        //Är det en användare som är är inloggad så hämtas enbart den inloggade användarens projekt.
        public ActionResult Index()
        {
            isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;

            if (isAdmin)
                return View(db.Projekt.ToList());
            else
            {
                var projekt = (from p in db.Projekt
                               where p.TillagdAv == username
                               select p).ToList();
                
                return View(projekt);
            }
        }


        [Authorize]
        //Controller för alla projekt som ej är påbörjade/godkända
        public ActionResult NotStarted()
        {
            isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;

            if (isAdmin)
            {
                var projectAdmin = (from p in db.Projekt
                               where p.Projektstatus == 1
                               select p).ToList();

                return View(projectAdmin);
            }

            else
            {
                var project = (from p in db.Projekt
                               where p.TillagdAv == username
                               && p.Projektstatus == 1
                               select p).ToList();

                return View(project);
            }
        }
        
        
        //Controller för alla projekt som är påbörjade
        [Authorize]       
        public ActionResult Started()
        {
            isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;

            if (isAdmin)
            {
                var projectAdmin = (from p in db.Projekt
                                    where p.Projektstatus == 2
                                    select p).ToList();

                return View(projectAdmin);
            }

            else
            {
                var project = (from p in db.Projekt
                               where p.TillagdAv == username
                               && p.Projektstatus == 2
                               select p).ToList();

                return View(project);
            }
        }



        [Authorize]
        //Controller för alla projekt som är avslutade
        public ActionResult Finished()
        {
            isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;

            if (isAdmin)
            {
                var projectAdmin = (from p in db.Projekt
                                    where p.Projektstatus == 3
                                    select p).ToList();

                return View(projectAdmin);
            }

            else
            {
                var project = (from p in db.Projekt
                               where p.TillagdAv == username
                               && p.Projektstatus == 3
                               select p).ToList();

                return View(project);
            }
        }

       


        // GET: Projekt/Details/5
        public ActionResult Details(int? id)
        {
            // Denna funktion gör så att användare inte kan komma åt andra användares projekt "bakvägen"
            if (!User.IsInRole("Admin"))
                if(db.Projekt.Where(p => p.ID == id).FirstOrDefault().TillagdAv != username) // Denna rad jämför den inloggade epostadressen med eposten för den som skapade projektet
                    return RedirectToAction("Index", "Projekt");

            //if (username != db.Projekt.Where(p => p.TillagdAv == username).Select(u => u.TillagdAv).ToString())
            //return RedirectToAction("Index", "Projekt");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = db.Projekt.Find(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;
            return View(projekt);
        }

        // GET: Projekt/Create
        public ActionResult Create()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;
            return View();
        }

        // POST: Projekt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Projektnamn,Beskrivning,Starttid,Sluttid,Huvudansvarig,Diarienummer,SoktBelopp,Huvudfinansiar,Projekttyp,Projektstatus,Beviljat,HVSomHuvudansvarig,Kommuniceringsstatus,TillagdAv")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                //Hämtar den aktuella inloggade användarens användarnamn som är en 
                //e-mailadress för att sedan sparas som ett attribut på det nya projektet
                //som skapats.
                string username = System.Web.HttpContext.Current.User.Identity.Name;

                db.Projekt.Add(projekt);
                projekt.TillagdAv = username;
          
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;
            return View(projekt);
        }

        // GET: Projekt/Edit/5
        public ActionResult Edit(int? id)
        {
            // Denna funktion gör så att användare inte kan komma åt andra användares projekt "bakvägen"
            if (!User.IsInRole("Admin"))
                if (db.Projekt.Where(p => p.ID == id).FirstOrDefault().TillagdAv != username) // Denna rad jämför den inloggade epostadressen med eposten för den som skapade projektet
                    return RedirectToAction("Index", "Projekt");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = db.Projekt.Find(id);
            string tillagtav = projekt.TillagdAv;
            TempData["TillagdAv"] = tillagtav;
            if (projekt == null)
            {
                return HttpNotFound();
            }
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;
            return View(projekt);
        }

        // POST: Projekt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Projektnamn,Beskrivning,Starttid,Sluttid,Huvudansvarig,Diarienummer,SoktBelopp,Huvudfinansiar,Projekttyp,Projektstatus,Beviljat,HVSomHuvudansvarig,Kommuniceringsstatus,TillagdAv")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projekt).State = EntityState.Modified;
                var tillagdAv = TempData["TillagdAv"];
                projekt.TillagdAv = tillagdAv.ToString();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.seeIfAdmin = isAdmin;
            return View(projekt);
        }

        [Authorize(Roles = "Admin")]
        // GET: Projekt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = db.Projekt.Find(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            return View(projekt);
        }

        [Authorize(Roles = "Admin")]
        // POST: Projekt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projekt projekt = db.Projekt.Find(id);
            db.Projekt.Remove(projekt);
            db.SaveChanges();
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
