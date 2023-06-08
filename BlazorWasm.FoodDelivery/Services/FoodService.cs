using BlazorWasm.FoodDelivery.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorWasm.FoodDelivery.Services
{
    public class FoodService
    {
        public List<FoodModel> FoodList => Get<FoodModel>(JsonData.Food);

        public List<FoodCategoryModel> FoodCategoryList => Get<FoodCategoryModel>(JsonData.FoodCategory);

        public FoodPaginationResponseModel? GetFoods(int category_id = 0, int pageNo = 1, int pageSize = 8)
        {
            int count = 0;
            int totalPageNo = 0;
            List<FoodModel> lst = new();
            if (category_id == 0)
            {
                count = FoodList.Count();
                lst = FoodList.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                count = FoodList.Where(x => x.food_category == category_id).Count();
                lst = FoodList
                    .Where(x => x.food_category == category_id)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }

            totalPageNo = count / pageSize;
            if (count % pageSize > 0)
                totalPageNo++;
            return new FoodPaginationResponseModel
            {
                FoodList = lst,
                TotalPageNo = totalPageNo
            };
        }

        public List<T> Get<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonStr);
        }
    }

    public static class JsonData
    {
        public static string Food { get; } = @" [
        {
          ""food_id"": 1,
          ""food_name"": ""Chicken Burger"",
          ""food_price"": 24,
          ""food_category"": 1
        },
        {
          ""food_id"": 2,
          ""food_name"": ""Cheese Burger"",
          ""food_price"": 24,
          ""food_category"": 1
        },
        {
          ""food_id"": 3,
          ""food_name"": ""Royal Cheese Burger"",
          ""food_price"": 24,
          ""food_category"": 1
        },
        {
          ""food_id"": 4,
          ""food_name"": ""Classic Hamburger"",
          ""food_price"": 24,
          ""food_category"": 1
        },
        {
          ""food_id"": 5,
          ""food_name"": ""Vegetarian Pizza"",
          ""food_price"": 115,
          ""food_category"": 2
        },
        {
          ""food_id"": 6,
          ""food_name"": ""Double Cheese Margherita"",
          ""food_price"": 110,
          ""food_category"": 2
        },
        {
          ""food_id"": 7,
          ""food_name"": ""Maxican Green Wave"",
          ""food_price"": 110,
          ""food_category"": 2
        },{
          ""food_id"": 8,
          ""food_name"": ""Seafood Pizza"",
          ""food_price"": 115,
          ""food_category"": 2
        },{
          ""food_id"": 9,
          ""food_name"": ""Thin Cheese Pizza"",
          ""food_price"": 110,
          ""food_category"": 2
        },{
          ""food_id"": 10,
          ""food_name"": ""Pizza With Mushroom"",
          ""food_price"": 110,
          ""food_category"": 2
        },{
          ""food_id"": 11,
          ""food_name"": ""Crunchy Bread"",
          ""food_price"": 35,
          ""food_category"": 3
        },
        {
          ""food_id"": 12,
          ""food_name"": ""Delicious Bread"",
          ""food_price"": 35,
          ""food_category"": 3
        },
        {
          ""food_id"": 13,
          ""food_name"": ""Loaf Bread"",
          ""food_price"": 35,
          ""food_category"": 3
        }
        ]";

        public static string FoodCategory { get; } = @"[
        {
            ""category_id"": 1,
            ""category_name"": ""Burger""
        },
        {
            ""category_id"": 2,
            ""category_name"": ""Pizzia""
        },
        {
            ""category_id"": 3,
            ""category_name"": ""Bread""
        }
        ]";
    }
}