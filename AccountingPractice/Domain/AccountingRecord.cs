using Domain;

public class AccountingRecord
{
    private List<Article> _articles;
    public DateTime TransactionDate { get; private set; }

    public AccountingRecord(DateTime transactionDate)
    {
        _articles = new List<Article>();
        TransactionDate = transactionDate;
    }

    public void AddArticle(Account account, TransactionType type, decimal amount)
    {
        var article = new Article(account, type, amount);
        _articles.Add(article);

        // Add the article to the relevant account using the account's method
        account.AddArticle(article);
    }

    public IReadOnlyList<Article> GetArticles()
    {
        return _articles.AsReadOnly();
    }
}
