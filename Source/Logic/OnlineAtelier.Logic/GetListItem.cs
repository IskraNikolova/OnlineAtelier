namespace OnlineAtelier.Logic
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class GetListItem
    {
        public static IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}
