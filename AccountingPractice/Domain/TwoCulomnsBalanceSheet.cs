public class TwoColumnBalanceSheet
{
    private readonly Corporation _corporation;

    public TwoColumnBalanceSheet(Corporation corporation)
    {
        _corporation = corporation;
    }

    public void Print()
    {
        Console.WriteLine("{0,-20} | {1,-20} | {2,-20}", "Account Name", "Assets", "Liabilities & Equity");
        Console.WriteLine(new string('-', 60));

        // Assets accounts
        decimal totalAssets = 0;
        totalAssets += PrintAccountBalance(_corporation.BankAccount);
        totalAssets += PrintAccountBalance(_corporation.Building);
        totalAssets += PrintAccountBalance(_corporation.Furniture);
        totalAssets += PrintAccountBalance(_corporation.Equipment);
        totalAssets += PrintAccountBalance(_corporation.AccountReceivable);

        // Liabilities and Equity accounts
        decimal totalLiabilitiesEquity = 0;
        totalLiabilitiesEquity += PrintLiabilitiesAndEquityBalance(_corporation.AccountPayable);
        totalLiabilitiesEquity += PrintLiabilitiesAndEquityBalance(_corporation.Capital);

        // Print totals
        Console.WriteLine(new string('-', 60));
        Console.WriteLine("{0,-20} | {1,-20} | {2,-20}", "Total", totalAssets, totalLiabilitiesEquity);


        if (totalAssets == totalLiabilitiesEquity)
        {
            Console.WriteLine("The balance sheet is balanced.");
        }
        else
        {
            Console.WriteLine("The balance sheet is not balanced.");
        }
    }

    private decimal PrintAccountBalance(Account account)
    {
        decimal balance = account.CalculateBalance();
        Console.WriteLine("{0,-20} | {1,-20} | {2,-20}", account.AccountName, balance, "");
        return balance;
    }

    private decimal PrintLiabilitiesAndEquityBalance(Account account)
    {
        decimal balance = account.CalculateBalance();
        Console.WriteLine("{0,-20} | {1,-20} | {2,-20}", account.AccountName, "", balance);
        return balance;
    }
}
