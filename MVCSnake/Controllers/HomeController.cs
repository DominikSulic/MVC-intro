using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.DataAccess;

namespace MVCSnake.Controllers
{
    public class HomeController : Controller
    {
        SQLDataAccess db = new SQLDataAccess();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Play()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Play")]
        public ActionResult PlayPost(int highscore)
        {
            db.updateHighscore(highscore);
            int currentHighscore = db.LoadHighscore();
            return View(currentHighscore);
        }
    }
}