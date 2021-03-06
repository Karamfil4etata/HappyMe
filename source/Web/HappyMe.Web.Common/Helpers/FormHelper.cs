﻿namespace HappyMe.Web.Common.Helpers
{
    using System.Web;
    using System.Web.Mvc;

    using MoreDotNet.Wrappers;

    public static class FormHelper
    {
        private const string DefaultArea = "Administration";

        public static HtmlString DeleteForm(this HtmlHelper helper, string action, string controller, string id, string secondId = null, string area = DefaultArea)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, new { area });

            var form = new TagBuilder("form");
            form.Attributes.Add("action", url);
            form.Attributes.Add("method", "POST");
            form.AddCssClass("delete-form");

            var antiForgeryToken = helper.AntiForgeryToken();
            var hiddenId = new TagBuilder("input");
            hiddenId.Attributes.Add("type", "hidden");
            hiddenId.Attributes.Add("name", "id");
            hiddenId.Attributes.Add("value", id);

            var submitInput = new TagBuilder("input");
            submitInput.Attributes.Add("type", "submit");
            submitInput.Attributes.Add("value", "Изтрий");
            submitInput.Attributes.Add("class", "btn btn-warning");

            if (!secondId.IsNullOrWhiteSpace())
            {
                var secondHiddenId = new TagBuilder("input");
                secondHiddenId.Attributes.Add("type", "hidden");
                secondHiddenId.Attributes.Add("name", "secondId");
                secondHiddenId.Attributes.Add("value", secondId);
                form.InnerHtml += secondHiddenId;
            }

            form.InnerHtml += antiForgeryToken;
            form.InnerHtml += hiddenId;
            form.InnerHtml += submitInput;

            return new MvcHtmlString(form.ToString());
        }
    }
}
