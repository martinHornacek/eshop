using eshop.Domain.Commands;
using eshop.Infrastructure;
using eshop.Infrastructure.Models;
using System;
using System.Web.Mvc;

namespace eshop.UI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private FakeBus _bus;
        private ReadModelFacade _readmodel;

        public HomeController()
        {
            _bus = ServiceLocator.Bus;
            _readmodel = new ReadModelFacade();
        }

        public ActionResult Index()
        {
            ViewData.Model = _readmodel.GetQuotes();
            return View();
        }

        public ActionResult Details(Guid id)
        {
            ViewData.Model = _readmodel.GetQuoteDetails(id);
            return View();
        }

        public ActionResult CreateQuote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuote(string name)
        {
            _bus.Send(new CreateQuote(Guid.NewGuid(), name));
            return RedirectToAction("Index");
        }

        public ActionResult RenameQuote(Guid id)
        {
            ViewData.Model = _readmodel.GetQuoteDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult RenameQuote(Guid id, string name, int version)
        {
            var command = new RenameQuote(id, name, version);
            _bus.Send(command);
            return RedirectToAction("Index");
        }

        public ActionResult ActivateQuote(Guid id)
        {
            ViewData.Model = _readmodel.GetQuoteDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult ActivateQuote(Guid id, int version)
        {
            _bus.Send(new ActivateQuote(id, version));
            return RedirectToAction("Index");
        }

        public ActionResult AddQuoteProductsToQuote(Guid id)
        {
            ViewData.Model = _readmodel.GetQuoteDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult AddQuoteProductsToQuote(Guid id, int number, int version)
        {
            _bus.Send(new AddQuoteProductsToQuote(id, number, version));
            return RedirectToAction("Index");
        }

        public ActionResult RemoveQuoteProductsFromQuote(Guid id)
        {
            ViewData.Model = _readmodel.GetQuoteDetails(id);
            return View();
        }

        [HttpPost]
        public ActionResult RemoveQuoteProductsFromQuote(Guid id, int number, int version)
        {
            _bus.Send(new RemoveQuoteProductsFromQuote(id, number, version));
            return RedirectToAction("Index");
        }
    }
}