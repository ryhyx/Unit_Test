

using System.Threading;
//Quiz
namespace MobileReview.Tests
{
    public class BerriesShould
    {
        [Fact]
        public void EndsWithBerry()
        {
            Fruits sut = new Fruits();
            Assert.All(sut.Berries, berries => Assert.EndsWith("berry", berries));
        }
    }
}
