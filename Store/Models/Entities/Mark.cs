namespace Store.Models.Entities
{
    public class Mark :Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
