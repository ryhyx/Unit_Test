
namespace MobileReview.Tests
{
    public class MobilePhoneFactoryShould
    {
        [Fact]
        public void IsMidrange()
        {
            //we want to make sure if mobilephone is the type midrangemobilephone or not

            MobilePhoneFactory sut = new MobilePhoneFactory();
            MobilePhone mobilePhone = sut.Create("Ultra");
            Assert.IsType<MidRangeMobilePhone>(mobilePhone);

            //although we give to craete "ultra" this test got passed becouse by default the flagship is false
        }

        [Fact]
        public void IsFlagship()
        {
            // what happend if we make the flagship true?

            MobilePhoneFactory sut = new MobilePhoneFactory();
            MobilePhone mobilePhone = sut.Create("Ultra");
            Assert.IsType<MidRangeMobilePhone>(mobilePhone);


        }


    }





}
