
namespace adminPanel_api.Model
{
    public class Worker
    {
        public int id_worker { get; set; }
        public int id_app { get; set; }     
        public int id_worker_post_map { get; set; }
        public string worker_name { get; set; }
        public string worker_image { get; set; }
        public string worker_pass { get; set; }
        public string worker_email { get; set; }
    }
}
