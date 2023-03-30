namespace NewMVC.Models
{
    public class InvRows
    {
        public int ProdId { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
        public List<Select> PL { get; set; }
    }
}
