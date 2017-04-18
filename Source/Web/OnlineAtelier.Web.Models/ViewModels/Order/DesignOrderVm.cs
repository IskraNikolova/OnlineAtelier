namespace OnlineAtelier.Web.Models.ViewModels.Order
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DesignOrderVm : IMapFrom<Order>
    {
        public DesignOrderVm()
        {
            this.Fn = new List<string>();
        }
        public int Id { get; set; }

        public string FiguresName { get; set; }

        public Appearance Appearance { get; set; }

        public int CountOfCookie { get; set; }

        public bool IsBox { get; set; }

        public IEnumerable<SelectListItem> FiguresSelectList { get; set; }

        public IEnumerable<string> Fn { get; set; }
    }
}