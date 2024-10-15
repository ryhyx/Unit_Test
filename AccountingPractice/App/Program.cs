class Program
{
    static void Main(string[] args)
    {
        Corporation corporation = new Corporation();


        corporation.DepositToBank(950000, new DateTime(1373, 05, 01));

        corporation.BuyBuilding(650000, new DateTime(1373, 05, 02));

        corporation.BuyFurnitureOnCredit(250000, new DateTime(1373, 05, 02));

        corporation.SellFurnitureOnCredit(25000, new DateTime(1373, 05, 05));

        corporation.BuyEquipmentOnCredit(150000, new DateTime(1373, 05, 06));

        corporation.PayDept(150000, new DateTime(1373, 05, 15));

        corporation.PrintBalances();
        var BalanceSheet = new TwoColumnBalanceSheet(corporation);
        BalanceSheet.Print();
    }
}
