using BlazorWasm.FoodDelivery.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BlazorWasm.FoodDelivery.Services
{
    public class FoodService
    {
        public List<FoodModel> FoodList => Get<FoodModel>(JsonData.Food);

        public List<FoodCategoryModel> FoodCategoryList => Get<FoodCategoryModel>(JsonData.FoodCategory);

        public FoodPaginationResponseModel? GetFoods(int CategoryId = 0, int pageNo = 1, int pageSize = 8)
        {
            int count = 0;
            int totalPageNo = 0;
            List<FoodModel> lst = new();
            if (CategoryId == 0)
            {
                count = FoodList.Count();
                lst = FoodList.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                count = FoodList.Where(x => x.FoodCategory == CategoryId).Count();
                lst = FoodList
                    .Where(x => x.FoodCategory == CategoryId)
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

        public List<EnumPageType> GetPages()
        {
            List<EnumPageType> pageTypes = Enum.GetValues(typeof(EnumPageType)).Cast<EnumPageType>().ToList();
            return pageTypes;
        }
    }

    public static class JsonData
    {
        public static string Food { get; } = @" [
        {
          ""FoodId"": 1,
          ""FoodName"": ""Chicken Burger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 5,
          ""FoodName"": ""Cheese Burger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 6,
          ""FoodName"": ""Royal Cheese Burger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 10,
          ""FoodName"": ""Classic Hamburger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 2,
          ""FoodName"": ""Vegetarian Pizza"",
          ""FoodPrice"": 115,
          ""FoodCategory"": 2
        },
        {
          ""FoodId"": 3,
          ""FoodName"": ""Double Cheese Margherita"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },
        {
          ""FoodId"": 7,
          ""FoodName"": ""Maxican Green Wave"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 8,
          ""FoodName"": ""Seafood Pizza"",
          ""FoodPrice"": 115,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 9,
          ""FoodName"": ""Thin Cheese Pizza"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 4,
          ""FoodName"": ""Pizza With Mushroom"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 11,
          ""FoodName"": ""Crunchy Bread"",
          ""FoodPrice"": 35,
          ""FoodCategory"": 3
        },
        {
          ""FoodId"": 12,
          ""FoodName"": ""Delicious Bread"",
          ""FoodPrice"": 35,
          ""FoodCategory"": 3
        },
        {
          ""FoodId"": 13,
          ""FoodName"": ""Loaf Bread"",
          ""FoodPrice"": 35,
          ""FoodCategory"": 3
        }
        ]";

        public static string FoodCategory { get; } = @"[
        {
            ""CategoryId"": 1,
            ""CategoryName"": ""Burger""
        },
        {
            ""CategoryId"": 2,
            ""CategoryName"": ""Pizzia""
        },
        {
            ""CategoryId"": 3,
            ""CategoryName"": ""Bread""
        }
        ]";
    }
}