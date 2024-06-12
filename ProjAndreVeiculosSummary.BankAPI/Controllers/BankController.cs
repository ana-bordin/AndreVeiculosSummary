using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosSummary.BankAPI.Services;

namespace ProjAndreVeiculosSummary.BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bank>> GetBanks()
        {
            var banks = _bankService.GetBanks();
            return Ok(banks);
        }

        [HttpPost]
        public ActionResult<Bank> PostBank(Bank bank)
        {
            _bankService.Create(bank);
            return Ok(bank);
            //return CreatedAtAction("GetBank", new { id = bank.Id }, bank);
        }

        
    }
}
