namespace OnlineAtelier.Web.Models.BindingModels.Order
{
    using Infrastructure.Mapping;
    using OnlineAtelier.Models.Models;

    public class DesignOrderBm : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string FigureName { get; set; }
    }
}
