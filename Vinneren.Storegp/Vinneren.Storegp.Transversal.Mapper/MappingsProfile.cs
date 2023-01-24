﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinneren.Storegp.Domain.Entity;

namespace Vinneren.Storegp.Transversal.Mapper
{
    //==================================================================================================================
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //                                              //Example
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }

    //==================================================================================================================
}
