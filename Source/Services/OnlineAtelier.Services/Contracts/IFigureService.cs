namespace OnlineAtelier.Services.Contracts
{
    using System.Collections.Generic;
    using Web.Models.BindingModels.Figures;

    public interface IFigureService
    {
        void AddFigure(FigureBm model);

        void Delete(int id);

        IEnumerable<string> GetAllFigures();
    }
}