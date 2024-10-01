namespace Domain
{
    public class AccountingRecord
    {
        public DateTime DateOfTransaction { get; set; }
        public TrasactionType TrasactionType { get; set; }

        public decimal Amount { get; set; } //the amount of each Record
        public AccountingRecord(DateTime dateOfTransaction, TrasactionType trasactionType, decimal amount)
        {
            DateOfTransaction = dateOfTransaction;
            TrasactionType = trasactionType;
            Amount = amount;
        }
        public static decimal UpdateAccount(decimal currentValue, decimal amountToUpdate)
        {
            return currentValue + amountToUpdate;
        }

        public string ToFormattedString()
        {
            return $"{DateOfTransaction.ToShortDateString()}-{TrasactionType}-{Amount}";
        }


    }
}