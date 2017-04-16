namespace OnlineAtelier.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Contracts;
    using Data.Common.Repository;
    using OnlineAtelier.Models.Models;
    using Web.Models.BindingModels.Figures;

    public class FigureService : IFigureService
    {
        private readonly IRepository<Figure> figures;

        public FigureService(IRepository<Figure> figures)
        {
            this.figures = figures;
        }

        public void AddFigure(FigureBm model)
        {
            var entityFigure = Mapper.Map<FigureBm, Figure>(model);
            this.figures.Add(entityFigure);
            this.figures.SaveChanges();
        }

        public void Delete(int id)
        {
             var entity = this.figures.GetById(id);
            this.figures.Delete(entity);
            this.figures.SaveChanges();
        }

        public IEnumerable<string> GetAllFigures()
        {
            var figures = this.figures
                .All()
                .Select(f => f.Name).ToList();
            return figures;
        }
    }
}
