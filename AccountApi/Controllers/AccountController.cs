using Microsoft.AspNetCore.Mvc;

namespace AccountAPI;
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpGet("account/{id}")]
    public ActionResult<Account> GetAccount(int id)
    {
        var account = _accountService.GetAccount(id);
        if (account == null)
        {
            return NotFound();
        }
        return account;
    }
    //get account list
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        return await _accountService.GetAccountListAsync();

    }
    [HttpPost]
    public ActionResult<Account> InsertAccount([FromBody]Account account)
    {
        var newAccount = _accountService.InsertAccountAsync(account);
        return CreatedAtAction(nameof(GetAccount), new { id = newAccount.Id }, newAccount);
    }

    [HttpPatch("withdraw/{Id}")]
    public ActionResult<Account> Withdraw(int Id, [FromBody]double amount)

    {
        try
        {
            var account = _accountService.GetAccount(Id);
            account.UpdateBalance(0-amount);
            _accountService.UpdateAccount(account);
            return account;
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPatch("deposit/{id}")]
    public ActionResult<Account> Deposit(int Id, [FromBody]double amount)
    {
        try
        {
            var account = _accountService.GetAccount(Id);
            account.UpdateBalance(amount);
            _accountService.UpdateAccount(account);
            return account;
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }

    }




}
