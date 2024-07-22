namespace MobileReview
{
    public abstract class MobilePhone
    {
        public string Name { get; set; }
        public abstract double MobilePhonePrice { get; }
        public abstract double WarrantyFeeBasedOnPercent { get; }
        public double TotalPrice => MobilePhonePrice + (MobilePhonePrice / 100 * WarrantyFeeBasedOnPercent);
    }
}