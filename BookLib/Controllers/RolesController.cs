using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using BookLib.Models;
using Microsoft.AspNet.Identity;


namespace OnlineBookLibrary.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();

            return View(roles);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(role);
                }
                else
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                return View();
            }

            return RedirectToAction("Index", "Roles");
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            IdentityRole role = db.Roles.Where(x => x.Id == id.Value.ToString()).FirstOrDefault();

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Guid? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            IdentityRole role = db.Roles.Find(id.Value.ToString());

            if (role == null)
            {
                return HttpNotFound();
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }

        [HttpGet]
        public ActionResult ManageUserToRoles()
        {
            ViewBag.Roles = db.Roles.Select(x => new SelectListItem
            {
                Value = x.Name,
                Text = x.Name
            }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult ManageUserToRolesConfirm(string UserName, string RoleName)
        {
            try
            {
                ApplicationUser user = db.Users.Where(x => x.Email == UserName).FirstOrDefault();

                var _manageUser = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                _manageUser.AddToRole(user.Id.ToString(), RoleName);
            }
            catch (Exception)
            {
                return View();
            }

            return RedirectToAction("Index", "Roles");
        }


    }
}
