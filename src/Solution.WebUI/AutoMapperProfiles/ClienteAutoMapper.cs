using AutoMapper;
using Solution.Domain.Entities;
using Solution.WebUI.ViewModels;

namespace Solution.WebUI.AutoMapperProfiles
{
    public class ClienteAutoMapper : Profile
    {
        public ClienteAutoMapper()
        {
            CreateMap<Cliente, ClienteViewModel>();
            //CreateMap<ClienteViewModel, Cliente>();
        } //constructor

    } //class

} //namespace
