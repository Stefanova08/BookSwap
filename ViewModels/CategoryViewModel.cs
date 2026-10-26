namespace BookSwap.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int BookCount { get; set; }
    }
}