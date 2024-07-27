
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
        //.Same() and .NotSame() are used to compare object references rather than their values.

        //Testing whether exception error works correctly or not :assert.throws(generic...name of field..lambda exp)
        [Fact]
        public void ErrorworkCorrectly()
        {
            MobilePhoneFactory sut = new MobilePhoneFactory();
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        //we want to make sure if the insert battery called . the method TurnOnMobile is raised or not
        //assert.raises ->3 parameters
                          //1-the code tha attached to event handler -lmbda
                          //2-the code that deatached from event handler
                          //3-if the code run..event should raise



    }





}
