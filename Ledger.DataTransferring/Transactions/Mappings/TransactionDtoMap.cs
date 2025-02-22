using AutoMapper;
using Ledger.Entities.Transactions;

namespace Ledger.DataTransferring.Transactions.Mappings
{
    public class TransactionDtoMap : Profile
    {
        public TransactionDtoMap()
        {
            CreateMap<TransactionDto, Transaction>()
                .ReverseMap();
            CreateMap<TransactionReadDto, Transaction>()
                .ReverseMap();
            CreateMap<TransactionWriteDto, Transaction>()
                .ReverseMap();
        }
    }
}
