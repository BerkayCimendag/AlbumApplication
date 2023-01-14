namespace AlbumApplication.Data.Classes
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        private decimal _lastPrice;

        public decimal LastPrice
        {
            get { return Price - (Price * Discount / 100); }
            set { _lastPrice = value; }
        }

        public bool IsItOnSale { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
