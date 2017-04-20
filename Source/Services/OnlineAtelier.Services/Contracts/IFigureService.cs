namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.BindingModels.Figures;

    public interface IFigureService : IDeletable
    {
        void AddFigure(FigureBm model);

        IEnumerable<string> GetAllFigures();
    }
}