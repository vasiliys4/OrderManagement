namespace OrderManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Number {  get; set; }
        public DateTime Date { get; set; }
        public int ProviderId {  get; set; }
    }
}
