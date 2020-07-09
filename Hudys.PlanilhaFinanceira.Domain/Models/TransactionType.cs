using Hudys.PlanilhaFinanceira.Domain.Interfaces;

namespace Hudys.PlanilhaFinanceira.Domain.Model
{
    public class TransactionType : IBasisTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
