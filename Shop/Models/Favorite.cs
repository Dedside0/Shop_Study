namespace Shop.Models;

public class Favorite
{
    public List<FavoriteItem> Items { get; set; }
    public Guid Id { get; set; }
    public string UserId { get; set; }
}

public class FavoriteItem
{
    public Guid Id { get; set; }
    public Product Product { get; set; }

}