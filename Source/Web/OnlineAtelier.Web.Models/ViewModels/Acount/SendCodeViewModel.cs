﻿namespace OnlineAtelier.Web.Models.ViewModels.Acount
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
