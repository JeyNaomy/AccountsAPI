namespace AccountAPI;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public double Balance { get; set; } 
    public DateTime CreatedAt { get; set; }

    public void UpdateBalance(double amount)
    {
        //to test if balance is sufficient
       
        if (amount < 0 && Balance < Math.Abs(amount))
        {
            throw new ArgumentException("Insufficient funds");
            
        }
        if (amount<0 && Status.ToLower()!= "yes")
        {
            throw new ArgumentException("Account is not active");
        }
        if (amount < 0 && amount %50 != 0)
        {
            throw new ArgumentException("Amount must be a multiple of 50");
        }
         Balance += amount;

    }
    public void UpdateStatus(string status)
    {
        if (status.ToLower() != "yes" && status.ToLower() != "no")
        {
            throw new ArgumentException("Invalid status");
        }
        Status = status;
    }

}

