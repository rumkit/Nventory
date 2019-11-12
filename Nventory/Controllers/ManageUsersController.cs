using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nventory.Models;
using Nventory.ViewModels;

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
            return View((await _usersRepository.GetUsersAsync()).Select(x => new UserViewModel(x)));
        }

        //// GET: ManageUsers/Create                
        public ActionResult Create()
        {
            return View();
        }

        //// POST: ManageUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffNumber,Name,Surname,Patronymic,Email,UserName,Password")] UserViewModel user)
        {
            Result result = new Result(false);
            if (ModelState.IsValid)
            {
                result = await _usersRepository.CreateUserAsync(user, user.Password).ConfigureAwait(false);
            }
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            if (result.ErrorsList != null)
                ViewData["errors"] = result.ErrorsList;
            return View(user);
        }

        // POST: ManageUsers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {

            var result = await _usersRepository.DeleteUserAsync(id).ConfigureAwait(false);        
            
            if (result.Error && result.ErrorsList != null)
                ViewData["errors"] = result.ErrorsList;
            return RedirectToAction(nameof(Index));
            
        }

        // GET: ManageUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var vm = new UserViewModel(await _usersRepository.GetUserAsync(id));
            vm.AvailableRoles = (await _usersRepository.GetAvailableRolesAsync())
                .Select(r => new SelectListItem(){ Text = r.Name, Value = r.Name })
                .ToList();
            return View(vm);
        }

        // POST: ManageUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserViewModel userViewModel)
        {
            try
            {
                userViewModel.Id = id;
                var result = await _usersRepository.UpdateUserAsync(userViewModel, userViewModel.SelectedRoles ?? new List<string>());
                if(result.Succeeded)
                    return RedirectToAction(nameof(Index));
                if (result.ErrorsList != null)
                    ViewData["errors"] = result.ErrorsList;
                return View(userViewModel);
            }
            catch
            {
                return View(userViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _usersRepository.GetUserAsync(id);
            if(user == null)
                return new NotFoundResult();
            return PartialView(new UserViewModel(user));
        }    


    }
}