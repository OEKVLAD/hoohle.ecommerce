
namespace adminPanel_api.Model
{
    public class Order
    {
        public int id_order { get; set; }
        public int id_user { get; set; }
        public int id_order_product { get; set; }
        public int id_payment { get; set; }
        public int id_app { get; set; }
    }
}
