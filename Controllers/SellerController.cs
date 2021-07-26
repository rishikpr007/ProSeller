using ProSeller.Models;
using ProSeller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProSeller.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            SellerRepository sellerRepository = new SellerRepository();
            ModelState.Clear();
            return View(sellerRepository.AllSeller());
        }

        // GET:AddSeller
        public ActionResult Create()
        {
            return View();
        }

        // POST:AddSeller
        [HttpPost]
        public ActionResult Create(Seller Seller)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SellerRepository sellerRepository = new SellerRepository();

                    if (sellerRepository.AddSeller(Seller))
                    {
                        ViewBag.Message = "Seller details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EditSeller    
        public ActionResult Edit(int SellerID)
        {
            SellerRepository sellerRepository = new SellerRepository();



            return View(sellerRepository.AllSeller().Find(Seller => Seller.SellerID == SellerID));

        }

        // POST:EditEmpDetails/5    
        [HttpPost]

        public ActionResult Edit(int SellerID, Seller obj)
        {
            try
            {
                SellerRepository sellerRepository = new SellerRepository();

                sellerRepository.UpdateSeller(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller    
        public ActionResult Delete(int SellerID)
        {
            try
            {
                SellerRepository sellerRepository = new SellerRepository();
                if (sellerRepository.DeleteSeller(SellerID))
                {
                    ViewBag.AlertMsg = "Seller details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }

    }
}