using Microsoft.AspNetCore.Mvc;
using Models.DataAccessLayer;
using Models.Models;
using Models.ViewModel;

namespace WebApplicationMVC.Controllers
{
    public class UserController : Controller
    {
        static string URL = "http://localhost:51756/api/Osoba/";
        static string URLFirma = "http://localhost:51756/api/Firma/";
        //OsobaDAL dal = new OsobaDAL(URL);
        //OsobaDAL dal = new OsobaDAL();
        OsobaDAL dal = new OsobaDAL(URL, -1);
        FirmaDAL firmaDAL = new FirmaDAL(URLFirma);
        public async Task<IActionResult> Index()
        {
            List<Osoba> osobeCustom = await dal.GetAllCustomAsync();

            List<Osoba> osobe = await dal.GetAllAsync();

            string JMBG = TempData["jmbg"] as string;
            if (JMBG != null)
            {
                osobe = osobe.Where(x => x.JMBG == JMBG).ToList();
            }

            ViewData["Osobe"] = osobe;
            return View();
        }
        public async Task<IActionResult> Novi()
        {
            List<Firma> firme = await firmaDAL.GetAllAsync();
            ViewData["firme"] = firme;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registracija(OsobaViewModel osobaViewModel)
        {
            if (osobaViewModel.Id > 0)
                dal.UpdateAsync(new Osoba() { Id = osobaViewModel.Id, Ime = osobaViewModel.Ime, Prezime = osobaViewModel.Prezime, JMBG = osobaViewModel.JMBG, URLSlika = osobaViewModel.URLSlika, FirmaId = osobaViewModel.FirmaId });
            else
                await dal.InsertAsync(new Osoba() { Ime = osobaViewModel.Ime, Prezime = osobaViewModel.Prezime, JMBG = osobaViewModel.JMBG, URLSlika = osobaViewModel.URLSlika, FirmaId = osobaViewModel.FirmaId });

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(OsobaViewModel osobaViewModel)
        {
            dal.UpdateAsync(new Osoba() { Id = osobaViewModel.Id, Ime = osobaViewModel.Ime, Prezime = osobaViewModel.Prezime, JMBG = osobaViewModel.JMBG, URLSlika = osobaViewModel.URLSlika, FirmaId = osobaViewModel.FirmaId });

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Izbrisi(int id)
        {
            await dal.DeleteAsync(id);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Osoba osoba = await dal.GetByIdAsync(id);
            OsobaViewModel osobaViewModel = new OsobaViewModel() { Id = osoba.Id, Ime = osoba.Ime, Prezime = osoba.Prezime, JMBG = osoba.JMBG, URLSlika = osoba.URLSlika, FirmaId= (int)osoba.FirmaId };
            
            List<Firma> firme = await firmaDAL.GetAllAsync();
            ViewData["firme"] = firme;

            //ViewData["Osoba"] = osoba;
            return View(osobaViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Filter(OsobaViewModel osobaViewModel)
        {
            TempData["jmbg"] = osobaViewModel.JMBG;

            return RedirectToAction("Index");
        }
    }
}
