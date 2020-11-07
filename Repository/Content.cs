using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using adminPanel_api.Model;
using adminPanel_api;

namespace adminPanel_api.Repository
{
    public class Content
    {
        public static List<Model.Content> GetContentList(DataTable data)
        {
          
            List<Model.Content> ContentList = new List<Model.Content>();
            ContentList = DataBase.CommonMethod.ConvertToList<Model.Content>(data);
            return ContentList;
        }

        public static List<Model.Content> getContentById(int id) {

            string sql = "select * from content where id_content =" + id + ";";

            return GetContentList(DataBase.GetQuery(sql));
        }
    }
}
