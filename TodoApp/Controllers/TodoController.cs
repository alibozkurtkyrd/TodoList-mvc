using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Contexts;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoSampleContext _context;

        public TodoController(TodoSampleContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var todos = _context.Todos.ToList();
            
            return View(todos);
        }


        public IActionResult Create(Todo todo){
            
            // buraya ditetime i eklemelisin
            // Console.WriteLine($"status degerit ${todo.Status}");
            todo.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public PartialViewResult EditPartial(){

            return PartialView();
        }


       [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _context.Todos.Find(id);

            bool flag = false; // dorpdown list in selected degeri için yardımcı olacak
            // bool flag2; // deger 1 icin yardımcı olacak
            if (todo != null)
            {
                flag = todo.Status == 0 ? true : false; 
                // flag2 = !flag;

            }
 
            // Edit işlemini sadece "Do" kısmında yapabiliyoruz. "Do" kısmı için staus un 2 olma durumu yok
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Activate", Value = "0", Selected = flag });

            items.Add(new SelectListItem { Text = "Process", Value = "1", Selected = !flag });

            items.Add(new SelectListItem { Text = "Complated", Value = "2"});


             ViewBag.Status = items;

            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            
            var item = _context.Todos.Where(x => x.Id == todo.Id).FirstOrDefault();

            item.Title = todo.Title;
            item.Description = todo.Description;
            item.Status = todo.Status;

            _context.Todos.Update(item);
            _context.SaveChanges();

            // // tarih versini database'den aldım disabled olan degeri buraya gönderemedim
            // var id = todo.Id;
            // var Todo = _context.Todos.Find(id); // model comes from database
            // todo.CreatedDate = Todo.CreatedDate;

            // _context.Todos.Update(todo);
            // _context.SaveChanges();

            return RedirectToAction("Index");
        }


        
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Redirect(int id)
        {
            var todo = _context.Todos.Find(id);
            todo.Status = 1; // default olarak status durumunu 1 yapıyoruz.
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}