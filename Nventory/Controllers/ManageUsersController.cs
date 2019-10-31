using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nventory.Models;

namespace Nventory.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller
    {
        private IUsersRepository _usersRepository;

        public ManageUsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        // GET: ManageUsers
        public async Task<IActionResult> Index()
        {            
            return View(await _usersRepository.GetUsersAsync());
        }

        //// GET: ManageUsers/Create                
        public ActionResult Create()
        {
            return View();
        }

        //// POST: ManageUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffNumber,Name,Surname,Patronymic,Email,UserName,Password,IsAdmin")] UserViewModel user)
        {
            Result result = new Result(false);
            if (ModelState.IsValid)
            {
                result = await _usersRepository.CreateUserAsync(user).ConfigureAwait(false);
            }
            if(result.Succeeded)
                return RedirectToAction(nameof(Index));
            if(result.ErrorsList != null)
                ViewData["errors"] = result.ErrorsList;
            return View(user);
        }

        

        //// GET: ManageUsers/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ManageUsers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// GET: ManageUsers/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ManageUsers/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(IndexAsync));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ManageUsers/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ManageUsers/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(IndexAsync));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}