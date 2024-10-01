namespace Domain
{
    public class Corporation
    {
        public decimal Bankaccount { get; set; }
        public decimal Capital { get; set; }
        public decimal Furniture { get; set; }
        public decimal AccountPayable { get; set; }
        public decimal AccountReceivable { get; set; }
        public decimal Building { get; set; }

        private readonly List<AccountingRecord> _accountingRecords = new List<AccountingRecord>();
        public IEnumerable<AccountingRecord> AccountingRecords => _accountingRecords;
        public Corporation()
        {
            //we dont need initialize!
        }
        public void InnsufficientException(decimal amount)
        {
            if (Bankaccount < amount)
            {
                throw new Exception("Insufficient funds in the bank account to buy the building.");
            }
        }
        private void RecordTransaction(TrasactionType transactionType, DateTime transactionDate, decimal amount)
        {
            var record = new AccountingRecord(transactionDate, transactionType, amount);
            _accountingRecords.Add(record);
        }
        public void DepositToBank(decimal amount, DateTime transactionDate)
        {
            Bankaccount = AccountingRecord.UpdateAccount(Bankaccount, amount);
            Capital = AccountingRecord.UpdateAccount(Capital, amount);


            RecordTransaction(TrasactionType.DepositToBank, transactionDate, amount);
        }

        public void ReceivePaymentFromDebtor(decimal amount, DateTime transactionDate)
        {
            if (amount > AccountReceivable)
            {
                decimal AmountDiffrence = amount - AccountReceivable;
                Bankaccount = AccountingRecord.UpdateAccount(Bankaccount, amount);
                AccountReceivable = AccountingRecord.UpdateAccount(AccountReceivable, -AccountReceivable);
                AccountPayable = AccountingRecord.UpdateAccount(AccountPayable, AmountDiffrence);
                RecordTransaction(TrasactionType.RecievePaymentfromDepter, transactionDate, amount);
                RecordTransaction(TrasactionType.Overpayment, transactionDate, AmountDiffrence);

            }
            else
            {
                Bankaccount = AccountingRecord.UpdateAccount(Bankaccount, amount);
                AccountReceivable = AccountingRecord.UpdateAccount(AccountReceivable, -amount);
                RecordTransaction(TrasactionType.RecievePaymentfromDepter, transactionDate, amount);
            }



        }


        public void BuyBuilding(decimal amount, DateTime transactionDate) //on cash
        {
            InnsufficientException(amount);
            Bankaccount = AccountingRecord.UpdateAccount(Bankaccount, -amount);
            Building = AccountingRecord.UpdateAccount(Building, amount);

            RecordTransaction(TrasactionType.Buybuilding, transactionDate, amount);
        }


        public void BuyFurnitureOnCredit(decimal amount, DateTime transactionDate)
        {
            Furniture = AccountingRecord.UpdateAccount(Furniture, amount);
            AccountPayable = AccountingRecord.UpdateAccount(AccountPayable, amount);


            RecordTransaction(TrasactionType.BuyFurnitureOnCredit, transactionDate, amount);
        }


        public void PayDebt(decimal amount, DateTime transactionDate)
        {

            InnsufficientException(amount);
            Bankaccount = AccountingRecord.UpdateAccount(Bankaccount, -amount);
            AccountPayable = AccountingRecord.UpdateAccount(AccountPayable, -amount);


            RecordTransaction(TrasactionType.PayingDept, transactionDate, amount);
        }


        public void SellFurnitureOnCredit(decimal amount, DateTime transactionDate)
        {
            Furniture = AccountingRecord.UpdateAccount(Furniture, -amount);
            AccountReceivable = AccountingRecord.UpdateAccount(AccountReceivable, amount);


            RecordTransaction(TrasactionType.SellFurnitureOnCredit, transactionDate, amount);
        }
    }
}
