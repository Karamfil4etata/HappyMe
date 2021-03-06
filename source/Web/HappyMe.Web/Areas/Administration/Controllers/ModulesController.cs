﻿namespace HappyMe.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using HappyMe.Data.Models;
    using HappyMe.Services.Administration.Contracts;
    using HappyMe.Services.Common.Mapping.Contracts;
    using HappyMe.Services.Data.Contracts;
    using HappyMe.Web.Areas.Administration.Controllers.Base;
    using HappyMe.Web.Areas.Administration.InputModels.Modules;
    using HappyMe.Web.Areas.Administration.ViewModels.Modules;
    using HappyMe.Web.Common.Extensions;

    using MoreDotNet.Extensions.Common;

    public class ModulesController :
        MvcGridAdministrationCrudController<Module, ModuleGridViewModel, ModuleCreateInputModel, ModuleUpdateInputModel>
    {
        private readonly IImagesAdministrationService imagesAdministrationService;

        public ModulesController(
            IUsersDataService userData,
            IModulesAdministrationService modulesAdministrationService,
            IMappingService mappingService,
            IImagesAdministrationService imagesAdministrationService)
            : base(userData, modulesAdministrationService, mappingService)
        {
            this.imagesAdministrationService = imagesAdministrationService;
        }

        public ActionResult Index()
        {
            IEnumerable<ModuleGridViewModel> modules;
            if (this.User.IsAdmin())
            {
                modules = this.GetData().OrderBy(x => x.Id);
            }
            else
            {
                modules =
                    this.MappingService.MapCollection<ModuleGridViewModel>(
                        this.AdministrationService.As<IModulesAdministrationService>()
                        ?.GetUserAndPublicModules(this.UserProfile.Id))
                        .OrderBy(m => m.Id);
            }

            return this.View(modules);
        }

        [HttpGet]
        public ActionResult Create() => this.View(new ModuleCreateInputModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModuleCreateInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.AuthorId = this.UserProfile.Id;

                if (model.ImageFile != null)
                {
                    var target = new MemoryStream();
                    model.ImageFile.InputStream.CopyTo(target);
                    var data = target.ToArray();
                    model.ImageId = this.imagesAdministrationService.Create(data, this.UserProfile.Id).Id;
                }

                var entity = this.BaseCreate(model);
                if (entity != null)
                {
                    this.TempData.AddSuccessMessage("Успешно създадохте модул");
                    return this.RedirectToAction(nameof(this.Index));
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (!id.HasValue)
            {
                return this.ItemNotFound("Няма такъв модул.");
            }

            var userHasRights = this.CheckIfUserHasRights(id.Value);

            if (userHasRights)
            {
                return this.View(this.GetEditModelData(id));
            }

            this.TempData.AddDangerMessage("Нямате права за да променяте този модул");
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ModuleUpdateInputModel model)
        {
            var userHasRights = this.CheckIfUserHasRights(model.Id);

            if (userHasRights)
            {
                if (this.ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        var target = new MemoryStream();
                        model.ImageFile.InputStream.CopyTo(target);
                        var data = target.ToArray();

                        model.ImageId = this.imagesAdministrationService.Update(
                            data,
                            model.ImageId,
                            this.UserProfile.Id,
                            this.User.IsAdmin()).Id;
                    }

                    var entity = this.BaseUpdate(model, model.Id);
                    if (entity != null)
                    {
                        this.TempData.AddSuccessMessage("Успешно редактирахте модул");
                        return this.RedirectToAction(nameof(this.Index));
                    }
                }

                return this.View(model);
            }

            this.TempData.AddDangerMessage("Нямате права за да променяте този модул");
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return this.ItemNotFound("Няма такъв модул.");
            }

            var userHasRights = this.CheckIfUserHasRights(id.Value);

            if (userHasRights)
            {
                this.BaseDestroy(id);

                this.TempData.AddSuccessMessage("Успешно изтрихте модул");
                return this.RedirectToAction(nameof(this.Index));
            }

            this.TempData.AddDangerMessage("Нямате права за да изтривате този модул");
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CheckIfUserHasRights(int moduleId)
        {
            return this.User.IsAdmin() ||
                (this.AdministrationService.As<IModulesAdministrationService>()
                    ?.CheckIfUserIsModuleAuthor(moduleId, this.UserProfile.Id) ?? false);
        }
    }
}