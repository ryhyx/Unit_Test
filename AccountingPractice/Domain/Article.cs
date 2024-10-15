using Domain;

public class Article
{
    public Account Account { get; private set; }
    public TransactionType Type { get; private set; }
    public decimal Amount { get; private set; }

    public Article(Account account, TransactionType type, decimal amount)
    {
        Account = account;
        Type = type;
        Amount = amount;
    }
}