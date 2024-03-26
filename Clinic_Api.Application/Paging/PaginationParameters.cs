namespace Clinic_Api.Application.Paging
{
    public class PaginationParameters
    {
        public const int maxPageSize = 50;
        public int Page { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value <= 0)
                {
                    _pageSize = 1;
                }
                else
                {
                    _pageSize = (value > maxPageSize) ? maxPageSize : value;
                }

            }
        }

    }
}
