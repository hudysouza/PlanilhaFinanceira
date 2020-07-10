using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hudys.PlanilhaFinanceira.Domain.DataTransferObjects;
using Hudys.PlanilhaFinanceira.Domain.Interfaces;
using Hudys.PlanilhaFinanceira.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hudys.PlanilhaFinanceira.Api.Controllers.V1
{
    [Route("api/v1/{controller}")]
    [Produces("application/json")]
    [ApiController]
    public class TransactionTypesController : ControllerBase
    {
        private readonly ITransactionTypeService _transactionTypeService;
        private readonly IMapper _mapper;

        public TransactionTypesController(ITransactionTypeService transactionTypeService, IMapper mapper)
        {
            _transactionTypeService = transactionTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TransactionTypeDTO>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get()
        {
            var ret = await _transactionTypeService.GetListTransactionTypeAsync();

            return Ok(_mapper.Map<List<TransactionTypeDTO>>(ret));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransactionTypeDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get(int id)
        {
            var ret = await _transactionTypeService.GetTransactionTypeAsync(id);

            return Ok(_mapper.Map<TransactionTypeDTO>(ret));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionTypeService.DeteleTransactionTypeAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TransactionTypeDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Put(int id, TransactionTypeDTO data)
        {
            var ret = await _transactionTypeService.GetTransactionTypeAsync(id);

            if (ret != null)
            {
                _mapper.Map(data, ret);
                return Ok(_mapper.Map<TransactionTypeDTO>(ret));
            }

            return BadRequest();
        }
        [HttpPost]
        [ProducesResponseType(typeof(TransactionTypeDTO), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Post(TransactionTypeDTO data)
        {
            var ret = _mapper.Map<TransactionType>(data);
            await _transactionTypeService.InsertTransactionType(ret);

            return Ok(_mapper.Map<TransactionTypeDTO>(ret));
        }
    }
}