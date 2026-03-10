using BBookWeb.DataAccess.Repository.IRepository;
using BBookWeb.DataAcess;
using BookUserWeb.Data.Repository.IRepository;


using BookUserWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookUserWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly BBookWeb.DataAccess.Repository.IRepository.IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _UnitOfWork. Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        

            [HttpPost]
            public IActionResult Create(Category obj)
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "The DisplayOrder cannot match the Name.");
                }

                if (obj.Name!=null && obj.Name?.ToLower() == "test") // Thêm dấu ? để tránh lỗi nếu Name bị null
                {
                    ModelState.AddModelError("name", "The Name cannot be 'test'.");
                }

                if (ModelState.IsValid)
                {
                   _UnitOfWork.Category.Add(obj);
                    _UnitOfWork.Save();

                        
                    return RedirectToAction("Index");
                }

                // QUAN TRỌNG: Nếu dữ liệu sai, phải trả về View để người dùng sửa lại
                return View(obj);
            }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == id );
            //Category? categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDbSingle = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot match the Name.");
            }

            if (obj.Name != null && obj.Name?.ToLower() == "test") // Thêm dấu ? để tránh lỗi nếu Name bị null
            {
                ModelState.AddModelError("name", "The Name cannot be 'test'.");
            }

            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }

            // QUAN TRỌNG: Nếu dữ liệu sai, phải trả về View để người dùng sửa lại
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _UnitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDbSingle = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _UnitOfWork.Category.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _UnitOfWork.Category.Remove(obj);
            _UnitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}

