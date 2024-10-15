using Domain;

public class Corporation
{

    public Asset BankAccount { get; private set; }
    public Asset Building { get; private set; }
    public Asset Furniture { get; private set; }
    public Asset Equipment { get; private set; }
    public Asset AccountReceivable { get; private set; }
    public Liability AccountPayable { get; private set; }
    public Equity Capital { get; private set; }


    public Corporation()
    {

        BankAccount = new Asset("Bank Account");
        Building = new Asset("Apartment");
        Furniture = new Asset("Upholstery");
        Equipment = new Asset("Tools and Equipment");
        AccountReceivable = new Asset("Account Recievable");
        AccountPayable = new Liability("Creditors");
        Capital = new Equity("Mr. Adibi's Capital");
    }

    private void CheckSufficientFunds(decimal amount)
    {
        if (BankAccount.CalculateBalance() < amount)
        {
            throw new Exception($"Insufficient funds in BankAccount.");
        }
    }
    // Deposit money to the bank account
    public void DepositToBank(decimal amount, DateTime transactiondate)
    {
        var record = new AccountingRecord(transactiondate);
        record.AddArticle(BankAccount, TransactionType.Debit, amount);
        record.AddArticle(Capital, TransactionType.Credit, amount);
    }


    public void BuyBuilding(decimal amount, DateTime transactiondate)
    {

        CheckSufficientFunds(amount);
        var record = new AccountingRecord(transactiondate);
        record.AddArticle(Building, TransactionType.Debit, amount);

        record.AddArticle(BankAccount, TransactionType.Credit, amount);


    }

    public void BuyFurnitureOnCredit(decimal amount, DateTime transactiondate)
    {

        var record = new AccountingRecord(transactiondate);
        record.AddArticle(Furniture, TransactionType.Debit, amount);
        record.AddArticle(AccountPayable, TransactionType.Credit, amount);


    }


    public void SellFurnitureOnCredit(decimal amount, DateTime transactiondate)
    {

        var record = new AccountingRecord(transactiondate);
        record.AddArticle(AccountReceivable, TransactionType.Debit, amount);
        record.AddArticle(Furniture, TransactionType.Credit, amount);


    }


    public void BuyEquipmentOnCredit(decimal amount, DateTime transactiondate)
    {

        var record = new AccountingRecord(transactiondate);
        record.AddArticle(Equipment, TransactionType.Debit, amount);
        record.AddArticle(AccountPayable, TransactionType.Credit, amount);


    }


    public void PayDept(decimal amount, DateTime transactiondate)
    {

        CheckSufficientFunds(amount);
        var record = new AccountingRecord(transactiondate);
        record.AddArticle(BankAccount, TransactionType.Credit, amount);
        record.AddArticle(AccountPayable, TransactionType.Debit, amount);


    }
    public void RecivePaymentFromDeptor(decimal amount, DateTime transactiondate)
    {
        var record = new AccountingRecord(transactiondate);
        if (amount > AccountReceivable.CalculateBalance())
        {
            decimal OverPayment = amount - AccountReceivable.CalculateBalance();

            record.AddArticle(BankAccount, TransactionType.Debit, amount);
            record.AddArticle(AccountReceivable, TransactionType.Credit, AccountReceivable.CalculateBalance());
            record.AddArticle(AccountPayable, TransactionType.Credit, OverPayment);

        }
        else
        {
            record.AddArticle(BankAccount, TransactionType.Debit, amount);
            record.AddArticle(AccountReceivable, TransactionType.Credit, amount);
        }
    }


    public void PrintBalances()
    {
        Console.WriteLine("Bank Account Balance: " + BankAccount.CalculateBalance());
        Console.WriteLine("Building Balance: " + Building.CalculateBalance());
        Console.WriteLine("Furniture Balance: " + Furniture.CalculateBalance());
        Console.WriteLine("Account Recievable :" + AccountReceivable.CalculateBalance());
        Console.WriteLine("Equipment Balance: " + Equipment.CalculateBalance());
        Console.WriteLine("AccountPayable Balance: " + AccountPayable.CalculateBalance());
        Console.WriteLine("Equity Balance: " + Capital.CalculateBalance());
    }
}
