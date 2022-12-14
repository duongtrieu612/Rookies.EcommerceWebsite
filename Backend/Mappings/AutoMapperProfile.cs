 using AutoMapper;
using Backend.Models;
using Shared;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<RatingViewModel, Rating>();
        }
    }
}

