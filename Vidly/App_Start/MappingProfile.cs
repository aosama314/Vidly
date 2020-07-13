using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //// Customer Mapping
            //Mapper.CreateMap<Customer, CustomerDto>()
            //    .ForMember(c => c.ID, opt => opt.Ignore());
            //Mapper.CreateMap<CustomerDto, Customer>()
            //    .ForMember(c => c.ID, opt => opt.Ignore());

            //// Movie Mapping
            //Mapper.CreateMap<Movie, MovieDto>()
            //    .ForMember(m => m.ID, opt => opt.Ignore());
            //Mapper.CreateMap<MovieDto, Movie>()
            //    .ForMember(m => m.ID, opt => opt.Ignore());

            // Customer Mapping
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            // Movie Mapping
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            // MembershipType Mapping
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            // Genre Mapping
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();

        }
    }
}