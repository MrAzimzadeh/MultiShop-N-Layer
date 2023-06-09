﻿using Amazon.SecurityToken.Model;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Business.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.Category;

namespace MultiShop.WebUi.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var categories = _categoryServices.GetCategoriesByLanguage("Az");
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDTO categoryCreateDto)
        {
            _categoryServices.AddCategory(categoryCreateDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var delete = _categoryServices.GetRemoveCategoryById(id);
            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(string id, Category category)
        {
            _categoryServices.RemoveCategory(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
             var edit = _categoryServices.GetUpdatedCategoryById(id);
             return View(edit);

        }

        [HttpPost]
        public IActionResult Edit(string Id, CategoryUpdateDTO categoryCreateDto)
        {
            _categoryServices.UpdateCategory(Id,categoryCreateDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult  Detail(string id)
        {
           var detail =   _categoryServices.GetDetailById(id);
            return View(detail);
        }




    }
}
