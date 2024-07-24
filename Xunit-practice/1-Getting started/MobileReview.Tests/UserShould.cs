

namespace MobileReview.Tests
{
    public class UserShould
    {
        [Fact]
        public void GetBatteryChargetest()
        {
            //We want to check that get battery charge is within the range of 0 to 100
            //act :call the method from user.cs =>GetBatteryCharge
            User sut = new User();
            sut.InsertBattery();  //if we call this method . it will return defult int->(0)
            //assert :assert.true or InRange =>more accured
            Assert.InRange(sut.BatteryCharge, 2, 100);
        }
    }
}
