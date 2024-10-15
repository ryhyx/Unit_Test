using Domain;

public class Liability : Account
{
    public Liability(string accountName) : base(accountName) { }

    public override decimal CalculateBalance()
    {

        decimal totalDebit = GetArticles().Where(article => article.Type == TransactionType.Debit)
                                     .Sum(article => article.Amount);

        decimal totalCredit = GetArticles().Where(article => article.Type == TransactionType.Credit)
                                      .Sum(article => article.Amount);
        decimal AccountBalance = totalCredit - totalDebit;
        return AccountBalance;
    }
}
