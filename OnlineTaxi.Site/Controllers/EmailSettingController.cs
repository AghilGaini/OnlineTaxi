using Database.Domain.Interfaces;
using Database.Domain.ViewModels.EmailSetting;
using Microsoft.AspNetCore.Mvc;
using Database.Domain.Model;
using Database.Domain.Entities;

namespace OnlineTaxi.Site.Controllers
{
    public class EmailSettingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailSettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var res = _unitOfWork._emailSetting.GetAll();

            var emailInfo = new EmailSettingViewModel();

            foreach (var item in res)
            {
                emailInfo.EmailsInfo.Add(new EmailSettingInfoViewModel()
                {
                    Id = item.Id,
                    Address = item.Address,
                    SmtpPort = item.SmtpPort,
                    SmtpServer = item.SmtpServer,
                    UseSSL = item.UseSSL
                });
            }

            emailInfo.Actions.Add(new ActionItem { Controller = "EmailSetting", Action = "Edit", Title = "ویرایش" });
            emailInfo.Actions.Add(new ActionItem { Controller = "EmailSetting", Action = "Delete", Title = "حذف" });

            return View(emailInfo);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewEmailSettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork._emailSetting.IsDuplicateByAddress(model.Address, 0))
                    ModelState.AddModelError("", "ایمیل وارد شده تکراری است");
                else
                {
                    var newEmailSetting = new EmailSettingDomain()
                    {
                        Address = model.Address,
                        Password = model.Password,
                        SmtpPort = model.SmtpPort,
                        SmtpServer = model.SmtpServer,
                        UseSSL = model.UseSSL
                    };

                    _unitOfWork._emailSetting.Add(newEmailSetting);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            if (ModelState.IsValid)
            {
                var emailSetting = _unitOfWork._emailSetting.GetByID(Id);
                if (emailSetting == null)
                    ModelState.AddModelError("", "ایمیل پیدا نشد");
                else
                {
                    return View(new UpdateEmailSettingViewModel()
                    {
                        Id = emailSetting.Id,
                        Address = emailSetting.Address,
                        Password = emailSetting.Password,
                        SmtpPort = emailSetting.SmtpPort,
                        SmtpServer = emailSetting.SmtpServer,
                        UseSSL = emailSetting.UseSSL
                    });
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateEmailSettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldEmailSetting = _unitOfWork._emailSetting.GetByID(model.Id);
                if (oldEmailSetting == null)
                    ModelState.AddModelError("", "ایمیل پیدا نشد");
                else
                {
                    if (_unitOfWork._emailSetting.IsDuplicateByAddress(model.Address, model.Id))
                        ModelState.AddModelError("", "نام ایمیل تکراری میباشد");

                    oldEmailSetting.Address = model.Address;
                    oldEmailSetting.SmtpServer = model.SmtpServer;
                    oldEmailSetting.SmtpPort = model.SmtpPort;
                    oldEmailSetting.UseSSL = model.UseSSL;
                    oldEmailSetting.Password = model.Password;

                    _unitOfWork._emailSetting.Update(oldEmailSetting);
                    _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }

        #endregion

        #region Delete 

        public IActionResult Delete(long Id)
        {
            var emailSetting = _unitOfWork._emailSetting.GetByID(Id);
            if (emailSetting == null)
            {
                ModelState.AddModelError("", "ایمیل پیدا نشد");
                return RedirectToAction("Index");
            }

            _unitOfWork._emailSetting.Remove(emailSetting);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        #endregion

    }
}
