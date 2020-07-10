using System.Collections.Generic;
using System.Threading.Tasks;
using Hudys.PlanilhaFinanceira.Domain.Model;

namespace Hudys.PlanilhaFinanceira.Domain.Interfaces
{
    public interface ITransactionTypeService
    {
        Task<List<TransactionType>> GetListTransactionTypeAsync();
        Task<TransactionType> GetTransactionTypeAsync(int id);
        Task<TransactionType> InsertTransactionType(TransactionType transactionType);
        Task<TransactionType> UpdateTransactionType(TransactionType transactionType);
        Task DeteleTransactionTypeAsync(int id);
    }
}