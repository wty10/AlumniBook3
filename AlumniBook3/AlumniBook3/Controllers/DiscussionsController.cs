using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlumniBook3.DAL;
using AlumniBook3.Models;
using System.Data.Entity.Infrastructure;

namespace AlumniBook3.Controllers
{
    public class DiscussionsController : Controller
    {
        private AlumnibookContext db = new AlumnibookContext();

        // GET: Discussions
        public ActionResult Index()
        {
            var discussions = db.Discussions.Include(d => d.Category);
            return View(discussions.ToList());
        }

        // GET: Discussions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discussion discussion = db.Discussions.Find(id);

            if (discussion == null)
            {
                return HttpNotFound();
            }
           // ICollection<Discussion> replies = from d in db.Discussions
             //                                 where (d => d.ReplyID == id)
               //                               select d;    
            foreach (Discussion d in db.Discussions)
            {
                if(d.ReplyID==id){
                    discussion.Replies.Add(d);
                }
            }
            foreach (UserProfile u in db.UserProfiles)
            {
                if (u.Email.Equals(discussion.Email))
                {
                    discussion.User = u;
                }
                foreach (Discussion r in discussion.Replies)
                {
                    if (u.Email.Equals(r.Email))
                    {
                        r.User = u;
                    }
                }
            }
            
            return View(discussion);
        }


        private void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var categoriesQuery = from d in db.Categories
                                  orderby d.CategoryName
                                  select d;
            ViewBag.CategoryID = new SelectList(categoriesQuery, "CategoryID", "CategoryName", selectedCategory);
        }

        // GET: Discussions/Create
        public ActionResult Create()
        {
            PopulateCategoriesDropDownList();
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Discussions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscussionID,CategoryID,Title,Body,PostDate,ReplyID,Email")] Discussion discussion)
        {
            try
            {

            if (ModelState.IsValid)
            {
                discussion.PostDate=DateTime.Now;
                
                db.Discussions.Add(discussion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateCategoriesDropDownList(discussion.CategoryID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", discussion.CategoryID);
            return View(discussion);
        }

        // GET: Discussions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discussion discussion = db.Discussions.Find(id);
            if (discussion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", discussion.CategoryID);
            return View(discussion);
        }

        // POST: Discussions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscussionID,CategoryID,Title,Body,PostDate,ReplyID,Email")] Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                discussion.PostDate = DateTime.Now;
                db.Entry(discussion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", discussion.CategoryID);
            return View(discussion);
        }

        // GET: Discussions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discussion discussion = db.Discussions.Find(id);
            if (discussion == null)
            {
                return HttpNotFound();
            }
            return View(discussion);
        }

        // POST: Discussions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discussion discussion = db.Discussions.Find(id);
            db.Discussions.Remove(discussion);
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
