
using Domain;

//Branch Dev
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {


            var corporation = new Corporation();

            // Perform accounting operations
            corporation.DepositToBank(5_000_000, new DateTime(2024, 09, 01));
            corporation.BuyBuilding(3_000_000, new DateTime(2024, 09, 05));
            corporation.BuyFurnitureOnCredit(800_000, new DateTime(2024, 09, 11));
            corporation.PayDebt(500_000, new DateTime(2024, 09, 20));
            corporation.SellFurnitureOnCredit(400_000, new DateTime(2024, 09, 25));
            corporation.ReceivePaymentFromDebtor(300_000, new DateTime(2024, 09, 30));

            // Output results
            Console.WriteLine($"Bank Account: {corporation.Bankaccount}");
            Console.WriteLine($"Building: {corporation.Building}");
            Console.WriteLine($"Furniture: {corporation.Furniture}");
            Console.WriteLine($"Accounts Receivable: {corporation.AccountReceivable}");
            Console.WriteLine($"Accounts Payable: {corporation.AccountPayable}");
            Console.WriteLine($"Capital: {corporation.Capital}");

            // Output transaction history
            foreach (var record in corporation.AccountingRecords)
            {
                Console.WriteLine(record.ToFormattedString());

            }
        }
    }

}
