﻿namespace HappyMe.Services.Administration
{
    using System.Linq;

    using HappyMe.Data.Contracts.Repositories;
    using HappyMe.Data.Models;
    using HappyMe.Services.Administration.Base;
    using HappyMe.Services.Administration.Contracts;

    public class ModulesAdministrationService : AdministrationService<Module>, IModulesAdministrationService
    {
        public ModulesAdministrationService(IRepository<Module> entities) 
            : base(entities)
        {
        }

        public IQueryable<Module> GetAllOrderedModules() => this.Read().OrderBy(m => m.CreatedOn);

        public IQueryable<Module> GetUserModules(string userId) => this.Read().Where(m => m.AuthorId == userId);

        public IQueryable<Module> GetUserAndPublicModules(string userId) => 
            this.Read().Where(m => m.AuthorId == userId || m.IsPublic);
    }
}