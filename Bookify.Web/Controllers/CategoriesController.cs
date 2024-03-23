using AutoMapper;
using Bookify.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Web.Controllers
{
	public class CategoriesController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
		{
			//TODO: Use ViewModel

			var categories = _context.Categories.ToList();
			return View(categories);
		}

		public IActionResult Create()
		{
			return View("Form");
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormViewModel model)
        {
            if(!ModelState.IsValid)
                return View("Form", model);

            //var category = new Category
            //{
            //    Name = model.Name,
            //};

            var category = _mapper.Map<Category>(model);
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);

            if (category is null)
                return NotFound();

            var viewModel = new CategoryFormViewModel
            {
                Id = id,
                Name = category.Name,
            };
            return View("Form", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", model);

            var category = _context.Categories.Find(model.Id);

            if (category is null)
                return NotFound();

            category.Name = model.Name;
            category.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
