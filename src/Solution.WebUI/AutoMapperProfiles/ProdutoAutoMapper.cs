using AutoMapper;
using Solution.Domain.Entities;
using Solution.WebUI.ViewModels;

namespace Solution.WebUI.AutoMapperProfiles
{
    public class ProdutoAutoMapper : Profile
    {

        public ProdutoAutoMapper()
        {

            CreateMap<Produto, ProdutoViewModel>();

        } //ProdutoAutoMapper

    } //class

} //namespace
