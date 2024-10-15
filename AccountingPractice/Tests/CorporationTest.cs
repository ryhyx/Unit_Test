public class CorporationTests
{
    [Fact]
    public void DepositToBank_ValidAmount_UpdatesBankAndCapital()
    {
        // Arrange
        var corporation = new Corporation();


        // Act
        corporation.DepositToBank(6500, DateTime.Now);

        // Assert
        Assert.Equal(6500, corporation.BankAccount.CalculateBalance());
        Assert.Equal(6500, corporation.Capital.CalculateBalance());

    }

    [Fact]
    public void BuyBuilding_ValidAmount_UpdatesBuildingAndBank()
    {
        // Arrange
        var corporation = new Corporation();
        corporation.DepositToBank(1000000, DateTime.Now);


        // Act
        corporation.BuyBuilding(650000, DateTime.Now);

        // Assert
        Assert.Equal(650000, corporation.Building.CalculateBalance());
        Assert.Equal(350000, corporation.BankAccount.CalculateBalance());
    }

    [Fact]
    public void BuyBuilding_InsufficientFunds_ThrowsException()
    {
        // Arrange
        var corporation = new Corporation();


        // Act & Assert
        Assert.Throws<Exception>(() => corporation.BuyBuilding(650000, DateTime.Now));
    }

    [Fact]
    public void PayDept_ValidAmount_UpdatesBankAndAccountPayable()
    {
        // Arrange
        var corporation = new Corporation();
        corporation.DepositToBank(1000000, DateTime.Now);
        corporation.BuyFurnitureOnCredit(250000, DateTime.Now);


        // Act
        corporation.PayDept(150000, DateTime.Now);

        // Assert
        Assert.Equal(850000, corporation.BankAccount.CalculateBalance());
        Assert.Equal(100000, corporation.AccountPayable.CalculateBalance());
    }

    [Fact]
    public void PayDept_InsufficientFunds_ThrowsException()
    {
        // Arrange
        var corporation = new Corporation();
        corporation.BuyFurnitureOnCredit(250000, DateTime.Now);


        // Act & Assert
        Assert.Throws<Exception>(() => corporation.PayDept(150000, DateTime.Now));
    }

    [Fact]
    public void RecievePaymentFromDebtor_ExactAmount_UpdatesBankAndAccountReceivable()
    {
        // Arrange
        var corporation = new Corporation();

        corporation.SellFurnitureOnCredit(300000, DateTime.Now);

        // Act
        corporation.RecivePaymentFromDeptor(300000, DateTime.Now);

        // Assert
        Assert.Equal(300000, corporation.BankAccount.CalculateBalance());
        Assert.Equal(0, corporation.AccountReceivable.CalculateBalance());
    }

    [Fact]
    public void RecievePaymentFromDebtor_Overpayment_UpdatesBankReceivableAndAccountPayable()
    {
        // Arrange
        var corporation = new Corporation();
        corporation.SellFurnitureOnCredit(300000, DateTime.Now);


        // Act
        corporation.RecivePaymentFromDeptor(350000, DateTime.Now);

        // Assert
        Assert.Equal(350000, corporation.BankAccount.CalculateBalance());
        Assert.Equal(0, corporation.AccountReceivable.CalculateBalance());
        Assert.Equal(50000, corporation.AccountPayable.CalculateBalance());
    }

    [Fact]
    public void BuyFurnitureOnCredit_ValidAmount_UpdatesFurnitureAndAccountPayable()
    {
        // Arrange
        var corporation = new Corporation();


        // Act
        corporation.BuyFurnitureOnCredit(250000, DateTime.Now);

        // Assert
        Assert.Equal(250000, corporation.Furniture.CalculateBalance());
        Assert.Equal(250000, corporation.AccountPayable.CalculateBalance());
    }

    [Fact]
    public void BuyEquipmentOnCredit_ValidAmount_UpdatesEquipmentAndAccountPayable()
    {
        // Arrange
        var corporation = new Corporation();


        // Act
        corporation.BuyEquipmentOnCredit(150000, DateTime.Now);

        // Assert
        Assert.Equal(150000, corporation.Equipment.CalculateBalance());
        Assert.Equal(150000, corporation.AccountPayable.CalculateBalance());
    }
}
