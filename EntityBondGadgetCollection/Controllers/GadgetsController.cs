using EntityBondGadgeCollectiont.Models;
using EntityBondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityBondGadgeCollectiont.Controllers
{
    public class GadgetsController : Controller
    {
        private ApplicationDbContext context;

        public GadgetsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Gadgets
        public ActionResult Index()
        {
            List<GadgetModel> gadgets = context.Gadgets.ToList();

            return View("Index", gadgets);
        }

        public ActionResult Details (int id)
        {
            GadgetModel gadget = context.Gadgets.SingleOrDefault(g => g.Id == id);
            return View("Details");
        }

        public ActionResult Create()
        {
            return View("GadgetForm", new GadgetModel());
        }

        public ActionResult Edit(int id)
        {
            GadgetModel gadget = context.Gadgets.SingleOrDefault(g => g.Id == id);

            return View("GadgetForm", gadget);
        }

        public ActionResult Delete(int id)
        {
            GadgetModel gadget = context.Gadgets.SingleOrDefault(g => g.Id == id);

            context.Entry(gadget).State = EntityState.Deleted;

            context.SaveChanges();
            return Redirect("/Gadgets");
        }
         


        [HttpPost]
        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            // save to DB
            GadgetModel gadget = context.Gadgets.SingleOrDefault(g => g.Id == gadgetModel.Id);

            //edit

            if (gadget != null)
            {
                gadget.Name = gadgetModel.Name;
                gadget.Description = gadgetModel.Description;
                gadget.AppearsIn = gadgetModel.AppearsIn;
                gadget.WithThisActor = gadgetModel.WithThisActor;

            }
            //Create new
            else
            {
                context.Gadgets.Add(gadgetModel);
            }
            context.SaveChanges();

            return View("GadgetForm", gadgetModel);

        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {
            //get a list of search results from the db.

            return View("index");
        }
        public ActionResult SearchForDescription(string searchPhrase)
        {
            var gadgets = from g in context.Gadgets where g.Name.Contains(searchPhrase) select g;

            return View("index", gadgets);
        }
    }
}