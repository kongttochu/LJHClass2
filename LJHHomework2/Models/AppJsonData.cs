using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJHHomework2.Models
{
    public class AppJsonData
    {
        public List<FOOD_COUNTRY> GetFoodList()
        {
            
            List<FOOD_COUNTRY> list = new List<FOOD_COUNTRY>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETCOUNTRYAll");
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                FOOD_COUNTRY country = new FOOD_COUNTRY();
                country.IDX = (int)data["IDX"];
                country.COUNTRY_KOR_NAME = data["COUNTRY_KOR_NAME"].ToString();
                country.REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now;
                country.REGID = data["REGID"].ToString();
                country.UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now;
                country.UPDID = data["UPDID"].ToString();
                country.ISUSE = data["ISUSE"] == "Y" ? true : false;
                country.StoreList = GetStore(country.IDX);
                list.Add(country);
            }
            return list;
        }

        private List<STORE> GetStore(int countryId)
        {
            List<STORE> list = new List<STORE>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETSTORE {0}", countryId);
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                STORE store = new STORE();
                store.IDX = (int)data["IDX"];
                store.STORE_KOR_NAME = data["STORE_KOR_NAME"].ToString();
                store.STORE_DELIVERY_TIP = data["STORE_DELIVERY_TIP"].ToString();
                store.STORE_DELIVERY_MIN_TIME = data["STORE_DELIVERY_MIN_TIME"].ToString();
                store.STORE_DELIVERY_MAX_TIME = data["STORE_DELIVERY_MAX_TIME"].ToString();
                store.STORE_RATING = (int)data["STORE_RATING"];
                store.REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now;
                store.REGID = data["REGID"].ToString();
                store.UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now;
                store.UPDID = data["UPDID"].ToString();
                store.ISUSE = data["ISUSE"] == "Y" ? true : false;
                store.FoodList = GetFoodDetail(store.IDX);
                list.Add(store);
            }
            return list;
        }

        private List<FOOD_DETAIL> GetFoodDetail(int storeId)
        {
            List<FOOD_DETAIL> list = new List<FOOD_DETAIL>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETFOODDETAIL {0}", storeId);
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                FOOD_DETAIL food = new FOOD_DETAIL();
                food.IDX = (int)data["IDX"];
                food.FOOD_KOR_NAME = data["FOOD_KOR_NAME"].ToString();
                food.FOOD_PRICE = (int)data["FOOD_PRICE"];
                food.REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now;
                food.REGID = data["REGID"].ToString();
                food.UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now;
                food.UPDID = data["UPDID"].ToString();
                food.ISUSE = data["ISUSE"] == "Y" ? true : false;
                list.Add(food);
            }
            return list;
        }

        public string GetJsonData(List<FOOD_COUNTRY> list)
        {
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }
    }
}
