using Database.Domain.Interfaces;
using Database.Domain.ViewModels.AppSetting;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTaxi.Site.Controllers
{
    public class AppSettingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppSettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region TotalInformation

        [HttpGet]
        public IActionResult TotalInformation()
        {
            var appSetting = _unitOfWork._setting.GetByKey("ApplicationSetting");
            if (appSetting == null)
            {
                ModelState.AddModelError("", "تنظیمات برنامه پیدا نشد");
                return View();
            }

            var res = new TotalInformationViewModel()
            {
                KeyString = appSetting.KeyString,
                Description = appSetting.Description,
                Fax = appSetting.Fax,
                Name = appSetting.Name,
                Tel = appSetting.Tel
            };

            return View(res);
        }

        [HttpPost]
        public IActionResult TotalInformation(TotalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldInfo = _unitOfWork._setting.GetByKey(model.KeyString);
                if (oldInfo == null)
                {
                    ModelState.AddModelError("", "تنظیمات پیدا نشد");
                    return View("TotalInformation", model);
                }
                oldInfo.Fax = model.Fax;
                oldInfo.Name = model.Name;
                oldInfo.Tel = model.Tel;
                oldInfo.Description = model.Description;

                _unitOfWork._setting.Update(oldInfo);
                _unitOfWork.Complete();

                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }

        #endregion

        #region AboutUs

        [HttpGet]
        public IActionResult AboutUs()
        {
            var appSetting = _unitOfWork._setting.GetByKey("ApplicationSetting");
            if (appSetting == null)
            {
                ModelState.AddModelError("", "تنظیمات برنامه پیدا نشد");
                return View();
            }

            var res = new AboutUsViewModel()
            {
                AboutUS = appSetting.About,
                KeyString = appSetting.KeyString
            };

            return View(res);
        }

        [HttpPost]
        public IActionResult AboutUs(AboutUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldInfo = _unitOfWork._setting.GetByKey(model.KeyString);
                if (oldInfo == null)
                {
                    ModelState.AddModelError("", "تنظیمات پیدا نشد");
                    return View("AboutUs", model);
                }

                oldInfo.About = model.AboutUS;

                _unitOfWork._setting.Update(oldInfo);
                _unitOfWork.Complete();

                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }

        #endregion

        #region AboutUs

        [HttpGet]
        public IActionResult Terms()
        {
            var appSetting = _unitOfWork._setting.GetByKey("ApplicationSetting");
            if (appSetting == null)
            {
                ModelState.AddModelError("", "تنظیمات برنامه پیدا نشد");
                return View();
            }

            var res = new TermsViewModel()
            {
                KeyString = appSetting.KeyString,
                Terms = appSetting.Terms
            };

            return View(res);
        }

        [HttpPost]
        public IActionResult Terms(TermsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldInfo = _unitOfWork._setting.GetByKey(model.KeyString);
                if (oldInfo == null)
                {
                    ModelState.AddModelError("", "تنظیمات پیدا نشد");
                    return View("Terms", model);
                }

                oldInfo.Terms = model.Terms;

                _unitOfWork._setting.Update(oldInfo);
                _unitOfWork.Complete();

                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }

        #endregion


    }
}
