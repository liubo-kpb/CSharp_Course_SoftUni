namespace BorderControl.Model.Interfaces
{
    public interface IBuyer
    {
        public int FOOD_CAPACITY_PROP { get; }
        int Food { get; }
        void BuyFood();
    }
}
