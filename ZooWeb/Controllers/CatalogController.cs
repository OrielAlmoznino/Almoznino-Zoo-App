using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using ZooDAL.Entities;
using ZooDAL.Services;
using ZooDAL.Services.Interfaces;

namespace ZooWeb.Controllers
{
    public class CatalogController : Controller
    {
        ICategoryService _categoryService;
        IAnimalService _animalService;
        ICommentService _commentService;

        public CatalogController(ICategoryService categoryService,IAnimalService animalService, ICommentService commentService)
        {
            _categoryService = categoryService;
            _animalService = animalService;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var animals = await _animalService.GetTopTwoAnimals();

            return View(animals);
        }

        [HttpGet]
        public async Task<IActionResult> ShowCatalog(Guid? categoryId)
        {
            IEnumerable<Animal> animals;

            if (categoryId.HasValue && categoryId != Guid.Empty)
            {
                animals = await _animalService.GetAnimalsByCategory(categoryId.Value);
            }
            else
            {
                animals = await _animalService.GetAnimalsWithCategories();
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", categoryId);

            return View(animals);
        }

        public IActionResult FilterByCategory(Guid categoryId)
        {
            if(categoryId != Guid.Empty)
            {
                return RedirectToAction(nameof(ShowCatalog), new { categoryID = categoryId });
            }
            else
            {
                return RedirectToAction(nameof(ShowCatalog));
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var animal = await _animalService.GetAnimalWithCategory(id);
            if (animal == null)
            {
                return NotFound(); // Return a 404 Not Found status code
            }
            animal.Comments = await _commentService.GetCommentsForAnimal(animal);

            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComment(Guid id, string commentContent)
        {
            var animal = await _animalService.GetAnimalWithCategory(id);
            if (animal == null)
            {
                return NotFound(); // Return a 404 Not Found status code
            }

            // Create a new comment using the provided content
            var newComment = new Comment
            {
                Content = commentContent,
                AnimalID = id,
                // Set other properties of the comment as needed
            };

            await _commentService.CreateAsync(newComment);

            // Redirect to the animal details page after adding the comment
            return RedirectToAction(nameof(Details), new { id });
        }

    }
}
