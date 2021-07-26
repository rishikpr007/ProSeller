using ProSeller.Models;
using ProSeller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProSeller.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AllProduct()
        {
            ProductRepository productRepository = new ProductRepository();
            ModelState.Clear();
            return View(productRepository.AllProduct());
        }

        // GET:AddProduct
        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: AddProduct
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductRepository productRepository = new ProductRepository();

                    if (productRepository.AddProduct(product)) 
                    {
                        ViewBag.Message = "Product details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET:EditProduct    
        public ActionResult UpdateProduct(int ProductID)
        {
            ProductRepository productRepository = new ProductRepository();



            return View(productRepository.AllProduct().Find(Product => Product.ProductID == ProductID));

        }

        // POST: Edit
        [HttpPost]

        public ActionResult UpdateProduct(int ProductID, Product obj)
        {
            try
            {
                ProductRepository productRepository = new ProductRepository();

                productRepository.UpdateProduct(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product    
        public ActionResult DeleteProduct(int ProductID)
        {
            try
            {
                ProductRepository productRepository = new ProductRepository();
                if (productRepository.DeleteProduct(ProductID))
                {
                    ViewBag.AlertMsg = "Product details deleted successfully";

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