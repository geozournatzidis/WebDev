using BondGadgetCollection.Data;
using BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BondGadgetCollection.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {
            //generate some fake data and send it to a view, testing
            List<GadgetModel> gadgets = new List<GadgetModel>();
            //gadgets.Add(new GadgetModel(0, "Gun", "A secret gun", "Moonraker", "Actor name"));
            //gadgets.Add(new GadgetModel(1, "Knife", "A secret knife", "Moonraker", "Actor name"));
            //gadgets.Add(new GadgetModel(2, "Rope", "A secret rope", "Moonraker", "Actor name"));
            //gadgets.Add(new GadgetModel(3, "Car", "A secret car", "Moonraker", "Actor name"));
            //gadgets.Add(new GadgetModel(4, "Grenade", "A secret grenade", "Moonraker", "Actor name"));

            GadgetDAO gadgetDAO = new GadgetDAO();

            gadgets = gadgetDAO.FechAll();

            return View("Index",gadgets);
        }

        public ActionResult Details (int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FechOne(id);
            return View("Details", gadget);
        }

        public ActionResult Create()
        {
            return View("GadgetForm", new GadgetModel());
        }

        public ActionResult Edit(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FechOne(id);
            return View("GadgetForm", gadget);
        }

        public ActionResult Delete(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Delete(id);

            List<GadgetModel> gadgets = gadgetDAO.FechAll();
            return View("Index", gadgets);
        }
         


        [HttpPost]
        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            // save to DB

            if (ModelState.IsValid)
            {
                GadgetDAO gadgetDAO = new GadgetDAO();
                gadgetDAO.CreateOrUpdate(gadgetModel);

                return View("Details", gadgetModel);
            }

            return View("GadgetForm", gadgetModel);

        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {
            //get a list of search results from the db.
            GadgetDAO gadgetDAO = new GadgetDAO();
            List<GadgetModel> searchResults = gadgetDAO.SearchForName(searchPhrase);

            return View("index", searchResults);
        }
        public ActionResult SearchForDescription(string searchPhrase)
        {
            //get a list of search results from the db.
            GadgetDAO gadgetDAO = new GadgetDAO();
            List<GadgetModel> searchResults = gadgetDAO.SearchForDescription(searchPhrase);

            return View("index", searchResults);
        }
    }
}