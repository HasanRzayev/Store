using System.Text.RegularExpressions;

namespace Store.Models.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }


        public int? mark_id { get; set; }
        public int price { get; set; }
        public virtual Mark Mark { get; set; }
    }
}
