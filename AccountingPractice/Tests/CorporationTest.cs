using Domain;

namespace Tests
{
    public class CorporationTest
    {
        [Fact]
        public void DepositToBank_WithValidAmount_IncreaseBankAccountAndCapital()
        {
            //Arrange 
            var corporation = new Corporation();
            //Act 
            corporation.DepositToBank(1000, DateTime.Now);
            //Assert 
            Assert.Equal(1000, corporation.Bankaccount);
            Assert.Equal(1000, corporation.Capital);
        }


        [Fact]
        public void InnsufficientException_amountBiggerThanBankAccount_FundsException()
        {
            var corporation = new Corporation();
            corporation.DepositToBank(500, DateTime.Now);
            //Act & Assert 
            Assert.Throws<Exception>(() => corporation.BuyBuilding(1000, DateTime.Now));
        }

        [Theory]
        [InlineData(1000, 200, 100, 900, 100)]
        [InlineData(1500, 500, 300, 1200, 200)]
        public void PayDebt_WhenBuyFurniture_ReduceBankAccountAndAccountPayable(decimal depositAmount, decimal creditAmount, decimal debtPayment, decimal expectedBank, decimal expectedPayable)
        {
            // Arrange
            var corporation = new Corporation();
            corporation.DepositToBank(depositAmount, DateTime.Now);
            corporation.BuyFurnitureOnCredit(creditAmount, DateTime.Now);

            // Act
            corporation.PayDebt(debtPayment, DateTime.Now);

            // Assert
            Assert.Equal(expectedBank, corporation.Bankaccount);
            Assert.Equal(expectedPayable, corporation.AccountPayable);
        }
        [Theory]
        [InlineData(750, 350, 400, -750, 0)]  //if amount <= AccountReceivable
        [InlineData(750, 800, 0, -750, 50)]   //if amount > AccountReceivable (over payment)
        public void ReceivePaymentFromDebtor_WhenSellFurnitureOnCredit_ReduceAccountReceivable(decimal sellOnCredit, decimal recievePayment, decimal expectedAccountReceivable, decimal expectedFurniture, decimal expectedAccountPayable)
        {

            //Arrange
            var corporation = new Corporation();
            corporation.SellFurnitureOnCredit(sellOnCredit, DateTime.Now);
            //Act
            corporation.ReceivePaymentFromDebtor(recievePayment, DateTime.Now);
            //Asset
            Assert.Equal(expectedAccountReceivable, corporation.AccountReceivable);
            Assert.Equal(expectedFurniture, corporation.Furniture);
            Assert.Equal(expectedAccountPayable, corporation.AccountPayable);
        }



    }
}
