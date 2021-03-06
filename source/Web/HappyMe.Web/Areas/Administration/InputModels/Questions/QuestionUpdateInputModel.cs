﻿namespace HappyMe.Web.Areas.Administration.InputModels.Questions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using HappyMe.Common.Mapping;
    using HappyMe.Data.Models;
    using HappyMe.Web.Areas.Administration.InputModels.Modules;

    public class QuestionUpdateInputModel : QuestionCreateInputModel, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<QuestionUpdateInputModel, Question>()
                .ForMember(m => m.AuthorId, opt => opt.Ignore());

            configuration.CreateMap<Question, QuestionUpdateInputModel>()
                .ForMember(m => m.ModulesIds, opt => opt.MapFrom(x => x.Modules.Select(y => y.Id)));
        }
    }
}