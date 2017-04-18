namespace OnlineAtelier.Web.Models.BindingModels.Order
{
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DesignOrderBm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string FiguresName { get; set; }
    }
}