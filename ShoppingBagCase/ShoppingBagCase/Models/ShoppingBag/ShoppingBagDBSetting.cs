namespace ShoppingBagCase.Models.ShoppingBag
{
    public class ShoppingBagDBSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ShoppingBagCollectionName { get; set; }
    }
}
