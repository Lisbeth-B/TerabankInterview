using Application.DTOs.Loan;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class LoanMappingProfile : Profile
    {
        public LoanMappingProfile()
        {
            CreateMap<Loan, GetLoanDto>();
            CreateMap<GetLoanDto, Loan>();

            CreateMap<Loan, AddLoanDto>();
            CreateMap<AddLoanDto, Loan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Loan, UpdateLoanDto>();
            CreateMap<UpdateLoanDto, Loan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}