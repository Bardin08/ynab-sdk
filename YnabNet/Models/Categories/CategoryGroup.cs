namespace YnabNet.Models.Categories;

public class CategoryGroup
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public bool Hidden { get; set; }
    public bool Deleted { get; set; }
    public List<Category>? Categories { get; set; }
}
