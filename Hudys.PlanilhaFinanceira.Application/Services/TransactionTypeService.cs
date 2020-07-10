using System.Collections.Generic;
using System.Threading.Tasks;
using Hudys.PlanilhaFinanceira.Domain.Interfaces;
using Hudys.PlanilhaFinanceira.Domain.Model;
using Hudys.PlanilhaFinanceira.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Hudys.PlanilhaFinanceira.Application.Services
{
    public class TransactionTypeService : ServiceBase<TransactionType>, ITransactionTypeService
    {
        public TransactionTypeService(PlanilhaFinanceiraDbContext _service) : base(_service)
        {

        }
        public async Task DeteleTransactionTypeAsync(int id)
        {
            var transactionType = await Find(id).FirstOrDefaultAsync();

            if (transactionType != null)
            {
                await DeleteAsync(transactionType);
            }
        }

        public Task<TransactionType> GetTransactionTypeAsync(int id)
        {
            return Find(id).FirstOrDefaultAsync();
        }

        public Task<List<TransactionType>> GetListTransactionTypeAsync()
        {
            return GetAllAsync();
        }

        public Task<TransactionType> InsertTransactionType(TransactionType transactionType)
        {
            return AddAsync(transactionType);
        }

        public async Task<TransactionType> UpdateTransactionType(TransactionType transactionType)
        {
            await (UpdateAsync(transactionType));

            return transactionType;
        }
    }
}
