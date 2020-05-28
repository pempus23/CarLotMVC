using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Mvc;

namespace CarLotMVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryRepo _repo = new InventoryRepo();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Inventory
        [HttpPost]
        public ActionResult Index()
        {
            return View("Foo", _repo.GetAll());
        }
        // GET: Inventory/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }
        //GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Make, Color,PetName")] Inventory inventory) { return View(); }
    }
}