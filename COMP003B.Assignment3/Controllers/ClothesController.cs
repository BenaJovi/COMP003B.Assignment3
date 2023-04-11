using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
	public class ClothesController : Controller
	{
		private static List <Clothes> _clothes = new List <Clothes> ();
        [HttpGet]
        public IActionResult Index()
		
		{
			return View(_clothes);
		}
        [HttpGet]
        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Clothes clothes)
		{
			if (ModelState.IsValid)
			{
				if (!_clothes.Any(p=> p.Id ==clothes.Id))
				{
					_clothes.Add(clothes);
				}

				return RedirectToAction(nameof(Index));
			}
			return View();
		}
		[HttpGet]
        public IActionResult Edit(int? id) 
		{ 
			if(id == null)
			{
				return NotFound();
			}
			var clothes = _clothes.FirstOrDefault(p => p.Id == id);

			if (clothes == null)
			{
				return NotFound();
			}
			return View(clothes);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Clothes clothes) 
		{ 
			if (id != clothes.Id)
				{
					return NotFound();
				}
			if (ModelState.IsValid)
			{
				var existingClothes = _clothes.FirstOrDefault(p => p.Id == id);
				if(existingClothes!=null)
				{
					existingClothes.Type = clothes.Type;
					existingClothes.Price= clothes.Price;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(clothes);
		}
		[HttpGet]
		public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothes = _clothes.FirstOrDefault(p => p.Id == id);

            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
		{
			var clothes = _clothes.FirstOrDefault(p => p.Id == id);
			if(clothes != null)
			{
				_clothes.Remove(clothes);
			}
			return RedirectToAction(nameof(Index));
		}
    }

}
