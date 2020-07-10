using AutoMapper;
using Hudys.PlanilhaFinanceira.Domain.DataTransferObjects;
using Hudys.PlanilhaFinanceira.Domain.Model;

namespace Hudys.PlanilhaFinanceira.Application.Mapping.Profiles
{
    public class TransactionTypeProfile : Profile
    {
        public TransactionTypeProfile()
        {
            CreateMap<TransactionType, TransactionTypeDTO>();
            CreateMap<TransactionTypeDTO, TransactionType>();
        }
    }
}