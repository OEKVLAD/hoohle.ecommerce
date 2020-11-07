
namespace adminPanel_api.Model
{
    public class InventoryManage
    {
        public int id_inventory_manager { get; set; }
        public int id_product { get; set; }
        public int id_localization { get; set; }
        public string price { get; set; }
        public int id_discount_category { get; set; }
        public string factor_price { get; set; }
    }
}
