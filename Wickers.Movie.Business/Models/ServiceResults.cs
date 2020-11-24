using System.Collections.Generic;

namespace Wickers.Movie.Business.Models
{
    public class ServiceResults<T>
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
    }
}
