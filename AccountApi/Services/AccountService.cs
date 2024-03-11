using Microsoft.EntityFrameworkCore;

namespace AccountAPI;

public class AccountService
{
   /*-Dbcontext(property)(DI)
--Get Account(by Id)
--Get AccountList (by paged)
--Update Account
--Delete Account
--Insert*/
    private readonly AccountDbContext _context;
    public AccountService(AccountDbContext context)
    {
        _context = context;
    }
    public Account? GetAccount(int id)
    {
        return _context.Accounts.Find(id);
    }
    public async Task<List<Account>> GetAccountListAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task UpdateAccountAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
       

    }
    public void UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }
    public void DeleteAccount(int id)
    {
        var account = _context.Accounts.Find(id);
        _context.Accounts.Remove(account);
        _context.SaveChanges();
    }
    public void InsertAccount(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();

    }

    public async Task InsertAccountAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }
}
