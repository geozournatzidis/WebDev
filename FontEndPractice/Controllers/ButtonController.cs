using FontEndPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FontEndPractice.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();

        // GET: Button
        public ActionResult Index()
        {
            if (!buttons.Any())
                FillList(buttons);
            else
                RandomizeList(buttons);

            return View("Index", buttons);
        }

        public ActionResult ButtonClick(string onOff)
        {
            int buttonNumber = Int32.Parse(onOff);
            buttons[buttonNumber].State = !buttons[buttonNumber].State;
            return View("Index", buttons);
        }

        private void FillList(List<ButtonModel> buttons)
        {
            Random random = new Random();

            for (int i = 0; i < 25; i++)
            {
                if (random.Next(10) > 5)
                    buttons.Add(new ButtonModel(true));
                else
                    buttons.Add(new ButtonModel(false));
            }
        }

        private void RandomizeList(List<ButtonModel> buttons)
        {
            Random random = new Random();

            for (int i = 0; i < 25; i++)
            {
                if (random.Next(10) > 5)
                    buttons[i].State = true;
                else
                    buttons[i].State = false;
            }
        }
    }
}