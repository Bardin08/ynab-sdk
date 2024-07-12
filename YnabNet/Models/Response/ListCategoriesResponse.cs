using YnabNet.Models.Categories;

namespace YnabNet.Models.Response;

public class ListCategoriesResponse
{
    public required List<CategoryGroup> CategoryGroups { get; set; }
    public long ServerKnowledge { get; set; }
}
