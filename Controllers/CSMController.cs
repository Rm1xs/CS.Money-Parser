using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CloudParser.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CloudParser.Hubs;
using Microsoft.AspNet.SignalR;

namespace CloudParser.Controllers
{
    public class CSMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetData()
        {
            List<Item> meny_data2 = new List<Item>();
            const string url = "https://csm.auction/api/skins_base";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            var locations = JsonConvert.DeserializeObject<Dictionary<string, CsMoneyItems>>(data);
            foreach (var item in locations)
            {
                var pros = 15;
                double num = Convert.ToDouble(item.Value.A);
                double procount = num / 100 * pros;
                double result = num + procount;
                double finalres = Math.Round(result, 2);
                meny_data2.Add(new Item { CustomeId = Convert.ToInt32(item.Key), Name = item.Value.M, Price = finalres, Quality = item.Value.E });
            }
            return Json(new { data = meny_data2 });
        }

        public IActionResult Sells(int id)
        {
            List<Transfer> meny_data = new List<Transfer>();

            string url = "https://csm.auction/api/sales?nameId=";
            string customeUrl = url + id;
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(customeUrl).Result.Content.ReadAsStringAsync().Result;
            var jsonResult = JsonConvert.DeserializeObject(data).ToString();
            var result = JsonConvert.DeserializeObject<Sell>(jsonResult);

            foreach (var b in result.sales)
            {
                //bool b1 = string.IsNullOrEmpty(b.floatvalue);
                //if (b1 != true)
                //{
                //    ViewData["Name"] = result.name;
                //overstock = "https://cs.money/check_skin_status?market_hash_name=" + result.name + "&appid=730";
                meny_data.Add(new Transfer() { name = result.name, custom_price = b.custom_price, floatvalue = b.floatvalue, update_time = UnixTimeStampToDateTime(b.update_time) });
                //}
                //else
                //{
                //    ViewData["Name"] = "No sales for this item.";
                //}

            }
            var sort = meny_data.OrderByDescending(d => d.update_time).ToArray();
            return Json(new { data = sort });
        }

        [HttpGet]
        public JsonResult AutoList(string fetch)
        {
            List<Item> meny_data2 = new List<Item>();
            const string url = "https://csm.auction/api/skins_base";
            HttpClient client = new HttpClient();
            Encoding.GetEncoding("ISO-8859-1");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            var data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            var locations = JsonConvert.DeserializeObject<Dictionary<string, CsMoneyItems>>(data);
            foreach (var item in locations)
            {
                meny_data2.Add(new Item { CustomeId = Convert.ToInt32(item.Key), Name = item.Value.M });
            }
            var query = (from c in meny_data2 where c.Name == fetch select c.Name).ToList();

            return Json(query);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.ToUniversalTime();
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dtDateTime;
        }
    }
}