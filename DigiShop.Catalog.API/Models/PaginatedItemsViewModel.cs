namespace DigiShop.Catalog.API.Models
{
    public class PaginatedItemsViewModel<T> where T : class
    {
        public PaginatedItemsViewModel(int pageSize, int pageIndex, int totalItems, T itemsOnPage)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalItems = totalItems;
            ItemsOnPage = itemsOnPage;
        }

        public int PageSize { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalItems { get; private set; }
        public T ItemsOnPage { get; private set; }
    }
}