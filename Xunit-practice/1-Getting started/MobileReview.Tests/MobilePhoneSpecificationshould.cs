namespace MobileReview.Tests;

public class MobilePhoneSpecificationshould
{
    [Fact]
    public void HaveFastCharging()
    {
        //make an instance of a class that we want to test
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        Assert.True(sut.IsFastCharge);

    }
    //test for fname then lastname currectly :equal -3th:ignore case for casesensitive
    [Fact]
    public void CalculateFullname()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //consider user put these data:
        sut.CompanyName = "Samsung";
        sut.ModelName = "Note";
        //then we check our expected and the acual result tha proccesed in FullName => $"{CompanyName}{ModelName}"
        Assert.Equal("Samsung Note", sut.FullName);
    }


    //make sure that fullname start with company name :startwith
    [Fact]
    public void StartwithComapanyname()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //inline data
        sut.CompanyName = "Xiaomi";
        sut.ModelName = "redmi";
        Assert.StartsWith("Xiaomi", sut.FullName);
    }
    //make sure that fullname end with model name :ends with
    [Fact]
    public void Endwithmodelname()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //inline data
        sut.CompanyName = "Xiaomi";
        sut.ModelName = "redmi";
        Assert.EndsWith("redmi", sut.FullName);
    }
    //subbesring : contains
    [Fact]
    public void TwolastletterSubstring()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //inline data
        sut.CompanyName = "Xiaomi";
        sut.ModelName = "redmi";
        Assert.Contains("oi", sut.FullName);
        //as you can see , the test has been failed
    }
    //both names should start with Capital letter :matches
    [Fact]
    public void CamleCasesubstring()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //inline data
        sut.CompanyName = "Xiaomi";
        sut.ModelName = "Redmi";
        Assert.Matches(@"^[A-Z][a-z]+ [A-Z][a-z]+$", sut.FullName);
        //your test gonna be failed if you ignore the space in regex (after + )
        //Assert.Matches(@"^[A-Z][a-z]+[A-Z][a-z]+$",sut.FullName); =>fail

    }



}