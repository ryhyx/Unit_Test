public abstract class Account{    public string AccountName { get; private set; }    private List<Article> _articles;    public Account(string accountName)    {        AccountName = accountName;        _articles = new List<Article>();    }

    // Adds an article to the account's list of articles
    public void AddArticle(Article article)    {        _articles.Add(article);    }

    // Provides access to the articles (used for balance calculations)
    protected List<Article> GetArticles()    {        return _articles;    }    public abstract decimal CalculateBalance();}