using AutoMapper;
using Boilerplate.DomainLayer.Authors;
using Boilerplate.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Webservice.AppStarts.Mappings
{
    public class AuthorMapping : Profile
    {
        public AuthorMapping()
        {
            CreateMap<Author, AuthorDto>().ForMember(x => x.TotalBook, x => x.MapFrom((s, d) => s?.Books?.Count() ?? 0));
            CreateMap<CreateAuthorDto, Author>();
        }
    }
}
