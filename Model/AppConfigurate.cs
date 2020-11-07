using System.ComponentModel.DataAnnotations;

namespace adminPanel_api.Model
{
    public class AppConfigurate
    {
        [Key]
        public int id_app_configurate { get; set; }
        public int id_app { get; set; }     
        public string name { get; set; }
        public string value { get; set; }
        public int parent_id_app_configurate { get; set; }
        public int visiables { get; set; }
        public string id_app_configurate_type { get; set; }
    }
}
