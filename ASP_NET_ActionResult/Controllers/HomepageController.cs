using ASP_NET_ActionResult.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_ActionResult.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Homepage()
        {
            return View();
        }

        public RedirectResult Homepage2()
        {
            return Redirect("/Homepage/Homepage");
        }

        public ActionResult Homepage3()
        {
            return View();
        }
        public JsonResult Homepage4()
        {
            Product urn = new Product();
            urn.ID = 5;
            urn.Name = "Laptop";
            urn.Price = 1913;
            urn.Description = "Deneme Ürünü.";
            /*
             [ ID:5,
            Name:"Laptop"
            Price=1913
            Description: "Deneme Ürünü."
            ]
             */
            return Json(urn,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Homepage4(int? deger)
        {
            return Json(null);
        }
        static List<string> Veriler = new List<string>();
        public ActionResult Homepage5()
        {
            ViewBag.liste = Veriler;
            return View();
        }
       
        [HttpPost]
        public ActionResult Homepage5(string ad, string soyad)
        {
            Veriler.Add(ad + " " + soyad);
            return new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(
                    new 
                    {
                        action="Homepage5",
                        controller="Homepage",
                        kod=Guid.NewGuid().ToString()
                    }));
        }


        public ActionResult Dosyalar()
        {
            return View();
        }
        public ActionResult PdfDosyaIndir()
        {
            string dosyaYolu = Server.MapPath("~/DosyalarPDF/DT_1.pdf");
            /* https://www.freeformatter.com/mime-types-list.html */
            return new FilePathResult(dosyaYolu,"application/pdf");
        }

        public FileStreamResult MetinDosyasiIndir()
        {
            string metin = "Deneme metni.";
            MemoryStream memo = new MemoryStream();
            byte[] bytes=System.Text.Encoding.UTF8.GetBytes(metin);

            memo.Write(bytes,0,bytes.Length);
            memo.Position = 0;

            FileStreamResult resultStream = new FileStreamResult(memo,"text/plain");
            resultStream.FileDownloadName = "deneme.txt";
            return resultStream;


        }


        public ActionResult Homepage6()
        {
            return View();
        }
        public PartialViewResult GetirKategoriPartial()
        {
            return PartialView("_KategorilerPartial");
        }
        public PartialViewResult GetirKategoriPartial2()
        {
            List<string> kategoriler2 = new List<string>()
            {
                "Sekiro",
                "Dark Souls 3",
                "Red Dead Redemption 2",
                "Ghost Of Tsushima",
                "Titanfall 2",
                "League Of Legends",
                "The Last of Us 2"
            };
            return PartialView("_KategorilerPartial2", kategoriler2);
        }


        public ActionResult Homepage7()
        {
            return View();
        }
        public JavaScriptResult Mesaj()
        {
            string js = "alert('Controller Mesaj- JavaScriptResult')";
            return JavaScript(js);
        }
        public JavaScriptResult JSButtonMesaj()
        {
            string js = "function button_click(){alert('Controller Mesaj-Button- JavaScriptResult')}";
            return JavaScript(js);
        }

    }
}