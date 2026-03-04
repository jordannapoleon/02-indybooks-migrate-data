using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndyBooks.Models;
using IndyBooks.Services;
using IndyBooks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IndyBooks.Controllers
{
    public class AdminController : Controller
    {
        private Services.Repository _repo;
        private IndyBooksDataContext _db;
        public AdminController(Services.Repository repo, IndyBooksDataContext db) {
             _repo = repo; 
             _db = db;
        }
    
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchVM searchVM)
        {
            var searchResults = searchVM.HalfPriceSale ?
            new SearchResultsVM { 
                Books = _repo.SaleResults,
                isSale = true
            } : 
            new SearchResultsVM { 
                Books = _repo.searchResults(searchVM).ToList(),
                isSale = false
            }; 

            return View("SearchResults", searchResults);
        }

        //TODO: Add the CreateBook GET method

        [HttpGet]
        public IActionResult CreateBook()
        {
        


            return View();
        }
 
        [HttpPost]
        public IActionResult CreateBook(CreateBookVM bookVM)
        {
            //TODO: Add Model Validation
            if (!ModelState.IsValid)
            {
                return View(bookVM);
            }


            //TODO: Once you've added the Writers DbSet, create a Writer object using the view Model info
            Writer NewWriter = new Writer
            {
                Name = bookVM.Author.Name,
            };
    

            //TODO: Once you've added the Writers DbSet, modify the Book using your newly created author.
            Book NewBook = new Book
            {
                Title = bookVM.Title,
                SKU = bookVM.SKU,
                Price = bookVM.Price,
                Author = NewWriter
            };


            //TODO: Once you've added the Writers DbSet, add author to the dataset
             _db.Books.Add(NewBook);
            _db.SaveChanges();

            return RedirectToAction("Search");
        }
    }
}
