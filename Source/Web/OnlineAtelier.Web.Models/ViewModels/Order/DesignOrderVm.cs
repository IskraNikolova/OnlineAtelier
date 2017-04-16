namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DesignOrderVm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string FigureName { get; set; }

        public IEnumerable<SelectListItem> FiguresSelectList { get; set; }
    }
}