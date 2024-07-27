using Xunit.Sdk;

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
    [Fact]
    public void NotHaveOperatiogsystemDefualt()
    {
        //we should make sure the operating system is null
        MobilePhoneSpecification sut = new MobilePhoneSpecification();

        //assert.null (oposite ==> assert.notnull)
        Assert.Null(sut.OperatingSystem);
        //As you can see, the test is failed becouse OperatingSystem = string.Empty is not null . it is s.th like this "  "

    }
    [Fact]
    public void Havenot5GNetwork()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        Assert.DoesNotContain("G", sut.Networks);
    }




    [Fact]
    public void HaveGinnetwork()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //predicate:lambda expression that checks if any network specification (n) contains the letter "G".
        Assert.Contains(sut.Networks, n => n.Contains("G"));

    }


    [Fact]
    public void HaveAllexpectednetwork()
    {
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        //make a collection
        List<string> expectedNetworks = new List<string>()
        {
            "2G",
            "3G",
            "5G"
        };
        Assert.Equal(expectedNetworks, sut.Networks);
        //the test is failed becouse the the sut.Network list have more options
    }
    [Fact]
    public void HvenotEmptyDefaultNetwork()
    {
        //we want to make sure that we have no empty Network in sut.Network

        MobilePhoneSpecification sut = new MobilePhoneSpecification();


        Assert.All(sut.Networks, networks => Assert.False(string.IsNullOrEmpty(networks)));
    }
    [Fact]
    public void EnsureEnglishname()
    {
        //we want to makesure the model name just can be in englishh letter
        MobilePhoneSpecification sut = new MobilePhoneSpecification();
        sut.ModelName = "هووای";
        Assert.Matches("^[a-zA-Z]+$", sut.ModelName);
    }
    

}