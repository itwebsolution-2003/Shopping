using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.DataAccess.Data;
using ShoppingOnline.Models;
using ShoppingOnline.DataAccess.Repository.IRepository;


namespace shoppingOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() //create index page
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();  //retreive product from database
            return View(objProductList);
        }

        //.............................................................this action method to create new product button
        public IActionResult Create() 
        {
            return View();

        }
        [HttpPost] 
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid) //that will check if model state we have product object is here if
                                    //that object is valid that means it goes to product.cs and
                                    //accept automadation if it is required....be pupulited if it is not it is not go to database (if statement is for)
            {

                _unitOfWork.Product.Add(obj); //what are to do the changes in the database
                _unitOfWork.Save(); //here to save the changes in the database
                TempData["success"] = "Product Created successfully"; //show a message at the top 
                return RedirectToAction("Index"); //(to write the different controller like index, product or more)

            }
            return View();

        }

        //...............................................................Create action Method to create edit button
        public IActionResult Edit(int? id) // if we want to build edit page and edit button
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            
            if (productFromDb == null)
            {
                return NotFound();

            }
            return View(productFromDb);
        }
        [HttpPost] // create buttons to post and to update  product in the database
        public IActionResult Edit(Product obj)
        {
           

            if (ModelState.IsValid) 
            {

                _unitOfWork.Product.Update(obj); //what are to do the changes in the database
                                                  //what are to update the changes in the database
                _unitOfWork.Save();  //here to save the changes in the database
                TempData["success"] = "Product Updated successfully";
                return RedirectToAction("Index"); //(to write the different controller like index, product or more)

            }
            return View();

        }

        //...............................................................Create action Method to create delete button
        public IActionResult Delete(int? id) // if we want to build edit page and edit button
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();

            }
            return View(productFromDb); //retreive product
        }
        [HttpPost, ActionName("Delete")]  // create buttons to post and to update  product in the database
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);  //to delete first to find the product
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");


        }
    }
}
