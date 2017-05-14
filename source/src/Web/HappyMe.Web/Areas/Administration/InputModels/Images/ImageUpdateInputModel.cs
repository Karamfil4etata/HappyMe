﻿namespace HappyMe.Web.Areas.Administration.InputModels.Images
{
    using Microsoft.AspNetCore.Mvc;

    public class ImageUpdateInputModel : ImageCreateInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}