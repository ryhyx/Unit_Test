namespace MobileReview
{
    public abstract class MobilePhone
    {
        public string Name  { get; set; }
        public abstract double MobilePhonePrice { get; }
        public abstract double WarrantyFeeBasedOnPercent { get; } //هزینه ی گارانتی
        public double TotalPrice => MobilePhonePrice + (MobilePhonePrice / 100 * WarrantyFeeBasedOnPercent); //550
        //we should write a test to ensure that the formula works true(total price)
    }
}