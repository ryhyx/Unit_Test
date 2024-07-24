
namespace MobileReview.Tests
{
    public class FlagshipMobilePhoneShould
    {
        [Fact]
        public void HaveCorrectPrice()
        {
            //step1:make an instance
            FlagshipMobilePhone sut = new FlagshipMobilePhone();

            //step2:assert.equal (manage the decimal in third parameter)
            //To round the numbers to a decimal digit, we set the third parameter to 1,
            //and in this case, the expectedValue number is rounded to the nearest number.
            Assert.Equal(550, sut.TotalPrice,1);
        }
    }
}
