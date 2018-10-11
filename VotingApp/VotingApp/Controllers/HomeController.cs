using System.Web.Mvc;
using VotingApp.Models;
namespace VotingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View(HttpContext.Application["events"]);
        }
        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if(oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            }
            else
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["Color"] = color;
            return View(HttpContext.Application["events"]);
        }
    }
}