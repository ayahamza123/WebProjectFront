using finalmawjoud_nlh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace finalmawjoud_nlh.Controllers
{
    public class AdminController : Controller

    {
        ApplicationDbContext context=new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public AdminController()
        {
        }


        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        //private DbProduct dbproduct = new DbProduct();
        // GET: Admin

        public ActionResult Index()
        {
            

            return View();
        }




        //CategoryField
        public ActionResult Categories()
        {
            return View(context.Categories.ToList());
        }
        // GET: Admin/DetailsCategory/5
        public ActionResult DetailsCategories(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }

        // GET: Admin/CreateCategory
        public ActionResult CreateCategory()
        {
            return View();
        }

        // POST: Admin/CreateCategory
        [HttpPost]
      
        public ActionResult CreateCategory(Category category)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return RedirectToAction("Categories");
                }
            }
            catch (DataException /* dex */)
            {
                          ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(category);
        }

        // GET: /Employee/Edit/5
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Employee/Delete/5
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            Category category = context.Categories.Find(id);
           context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Categories");
        }
        //CategoryField
        public ActionResult Images()
        {
            return View(context.Images.ToList());
        }
        // GET: Admin/DetailsCategory/5
        public ActionResult DetailsImages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images image = context.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);

        }

        // GET: Admin/CreateCategory
        public ActionResult CreateImage()
        {
            return View();
        }

        // POST: Admin/CreateCategory
        [HttpPost]

        public ActionResult CreateImage(Images image)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    context.Images.Add(image);
                    context.SaveChanges();
                    return RedirectToAction("Images");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(image);
        }

        // GET: /Employee/Edit/5
        public ActionResult EditImages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images image = context.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImages(Images image, HttpPostedFileBase file)
        {
            string fileName = null;
            if (file != null)
            {
                // var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
                string photo = image.SlideImage;
                string fullPath = Request.MapPath("~/SlideImg/" + image.SlideImage);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };

                fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  

                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  

                    var mappedPath = HttpContext.Server.MapPath("~/SlideImg/");



                    file.SaveAs(Path.Combine(mappedPath, fileName));

                    image.SlideImage = file != null ? fileName : image.SlideImage;

                }
                else
                {
                    ViewBag.message = "Please choose only Image file";
                    return View();
                }
            }
            context.Entry(image).State = EntityState.Modified;
            context.SaveChanges();


            return RedirectToAction("Images");
           
        }

        // GET: /Employee/Delete/5
        public ActionResult DeleteImages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images image = context.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: /Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImages(int id)
        {
            Images image = context.Images.Find(id);
            context.Images.Remove(image);
            context.SaveChanges();
            return RedirectToAction("Images");
        }









        //ProductField
        public ActionResult Products()
        {
            return View(context.Products.ToList());
        }
        // GET: Admin/DetailsCategory/5
        public ActionResult DetailProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }

        // GET: Admin/CreateCategory
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: Admin/CreateCategory
        [HttpPost]

        public ActionResult CreateProduct(Product product)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("Products");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }

        // GET: /Employee/Edit/5
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }

        // GET: /Employee/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            Product product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Products");
        }
        //UsersField 
        public ActionResult Users()
        {
            
            return View(context.Users.ToList());
        }


        // GET: Admin/Details/5
        public ActionResult DetailsUser(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         
            var user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        // GET: Admin/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Admin/Create
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Users");
                }
                AddErrors(result);



            }



            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            throw new NotImplementedException();
        }



        // GET: Admin/Edit/5
        public ActionResult EditUser(string id)
        {
           
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditUser(ApplicationUser appuser, HttpPostedFileBase file)
        {
            string fileName = null;
            if (file != null)
            {
                // var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
                string photo = appuser.MemberPhoto;
                string fullPath = Request.MapPath("~/UserImg/" + appuser.MemberPhoto);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };

                fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  

                if (allowedExtensions.Contains(ext)) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  

                    var mappedPath = HttpContext.Server.MapPath("~/UserImg/");



                  file.SaveAs(Path.Combine(mappedPath, fileName));

                    appuser.MemberPhoto = file != null ? fileName : appuser.MemberPhoto;

                }
                else
                {
                    ViewBag.message = "Please choose only Image file";
                    return View();
                }
            }
            context.Entry(appuser).State = EntityState.Modified;
            context.SaveChanges();


            return RedirectToAction("index");
           
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteUser(string id)
        {
          
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(ApplicationUser appuser)
        {
            try
            {

                var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
                context.Users.Remove(user);
                context.SaveChanges();
                //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
    }
}
