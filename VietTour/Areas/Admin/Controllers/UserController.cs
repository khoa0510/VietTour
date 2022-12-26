using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VietTour.Data.Repositories;
using VietTour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "Employee")]
    public class UserController : Controller
	{
		private readonly MainRepository _mainRepository;
		private readonly IMapper _mapper;

		public UserController(MainRepository mainRepository, IMapper mapper)
		{
			_mainRepository = mainRepository;
			_mapper = mapper;
		}

        //GetAllUser
        [HttpGet]
		public ActionResult Index(int? page, string sortBy, string search)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12;
            UserViewModel userViewModel = new()
            {
                UserList = _mainRepository.UserRepository.GetAll(pageNumber, pageSize, sortBy, search)
            };
            return View(userViewModel);
        }

		[HttpGet]
		public ActionResult Edit(int id)
		{
			EditUserViewModel editUserViewModel = _mainRepository.UserRepository.GetUserDetail(id);
			return View(editUserViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, EditUserViewModel editUserViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(editUserViewModel);
			}
			else
			{
				_mainRepository.UserRepository.EditUser(id, editUserViewModel);
				return RedirectToAction(nameof(Index));
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			_mainRepository.UserRepository.DeleteUser(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
