using Database.Domain.Interfaces;
using Database.Domain.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;
using Database.Domain.Model;
using System;
using Database.Domain.Entities;
using OnlineTaxi.Core.Generators;

namespace OnlineTaxi.Site.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var res = _unitOfWork._role.GetAll();

            var roleInfos = new RoleViewModel();

            foreach (var item in res)
            {
                roleInfos.RolesInfo.Add(new RoleInfoViewModel()
                {
                    Name = item.Name,
                    Title = item.Title,
                    Id = item.Id
                });
            }

            roleInfos.Actions.Add(new ActionItem() { Controller = "Role", Action = "Edit", Title = "ویرایش" });

            return View(roleInfos);
        }

        #region Edit

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var res = _unitOfWork._role.GetByID(Id);
            if (res == null)
            {
                ModelState.AddModelError("", "نقش پیدا نشد");
                return RedirectToAction("Index");
            }
            else
            {
                var roleInfo = new UpdateRoleViewModel()
                {
                    Id = res.Id,
                    Name = res.Name,
                    Title = res.Title
                };
                return View(roleInfo);
            }

        }

        [HttpPost]
        public IActionResult Edit(UpdateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldRole = _unitOfWork._role.GetByID(model.Id);
                if (oldRole == null)
                {
                    ModelState.AddModelError("", "نقش پیدا نشد");
                    return View(model);
                }
                else
                {
                    if (_unitOfWork._role.IsDuplicateByName(model.Name, model.Id))
                    {
                        ModelState.AddModelError("", "نام سیستمی نقش تکراری است");
                        return View(model);
                    }

                    oldRole.Title = model.Title;
                    oldRole.Name = model.Name;

                    _unitOfWork._role.Update(oldRole);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }

            }

            return View(model);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._role.IsDuplicateByName(model.Name, Guid.Empty))
                {
                    ModelState.AddModelError("", "نام نقش تکراری میباشد");
                    return View(model);
                }

                var newRole = new RoleDomain()
                {
                    Id = CodeGenerators.GetId(),
                    Name = model.Name,
                    Title = model.Title
                };

                _unitOfWork._role.Add(newRole);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        #endregion
    }
}
