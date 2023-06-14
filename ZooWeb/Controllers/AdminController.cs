using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZooDAL.Entities;
using ZooDAL.Services;
using ZooDAL.Services.Interfaces;

namespace ZooWeb.Controllers
{
    public class AdminController : Controller
    {
        ICategoryService _categoryService;
        IAnimalService _animalService;
        ICommentService _commentService;
        IImageService _imageService;
        public AdminController(ICategoryService categoryService,IAnimalService animalService, ICommentService commentService, IImageService imageService)
        {
            _categoryService = categoryService;
            _animalService = animalService;
            _commentService = commentService;
            _imageService = imageService;
        }
        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            var animals = await _animalService.GetAnimalsWithCategories();
            
            return View(animals);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            var categories = _categoryService.GetAllAsync().Result;
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Animal animal, IFormFile file)
        {
            // Check the way user uploads the image to the website
            string selectedOption = Request.Form["imageOption"];

            if (selectedOption == "upload")
            {
                ModelState.Remove("ImagePath");

                if (file == null || file.Length == 0)
                {
                    var categories = _categoryService.GetAllAsync().Result;
                    ViewBag.Categories = new SelectList(categories, "Id", "Name");
                    ModelState.AddModelError("file", "Please select an image file.");
                    return View(animal);
                }
            }
            else if (selectedOption == "url")
            {
                ModelState.Remove("file");

                if (!Uri.IsWellFormedUriString(animal.ImagePath, UriKind.Absolute))
                {
                    ModelState.AddModelError("ImagePath", "Invalid image URL.");
                    var categories = _categoryService.GetAllAsync().Result;
                    ViewBag.Categories = new SelectList(categories, "Id", "Name");
                    return View(animal);
                }
            }

            // Check the model state
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetAllAsync().Result;
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View(animal);
            }
            try
            {
                // Process the selected option
                if (selectedOption == "url")
                {
                    string result = await _imageService.CreateImageFromUrl(animal.ImagePath);
                    animal.ImagePath = result;
                }
                else if (selectedOption == "upload")
                {
                    string result = await _imageService.CreateImageFromLocal(file);
                    animal.ImagePath = result;
                }

                await _animalService.CreateAsync(animal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: AdminController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal == null)
            {
                return NotFound(); // Return a 404 Not Found status code if the animal is not found
            }
            var categories = _categoryService.GetAllAsync().Result;
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(animal);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest(); // Return a 400 Bad Request status code if the IDs don't match
            }

            if (!ModelState.IsValid)
            {
                return View(animal); // Return the same view with validation errors
            }

            try
            {
                if (Uri.IsWellFormedUriString(animal.ImagePath, UriKind.Absolute))
                {
                    string result = await _imageService.CreateImageFromUrl(animal.ImagePath);
                    animal.ImagePath = result;
                }

                await _animalService.UpdateAsync(id, animal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(animal); // Return the same view with an error message
            }
        }

        // GET: AdminController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var animal = await _animalService.GetAnimalWithCategory(id);
            
            if (animal == null)
            {
                return NotFound(); // Return a 404 Not Found status code if the animal is not found
            }

            return View(animal);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Animal animal)
        {
            try
            {
                await _imageService.DeleteImage(animal.ImagePath);
                await _commentService.DeleteCommentsForAnimal(animal);
                await _animalService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(); // Return the same view with an error message
            }
        }

    }
}
