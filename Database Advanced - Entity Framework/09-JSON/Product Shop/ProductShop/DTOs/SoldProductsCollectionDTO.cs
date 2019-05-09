using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs
{
    public class SoldProductsCollectionDTO
    {
        [JsonProperty("count")]
        public int Count => this.Products.Count;

        [JsonProperty("products")]
        public List<SoldItemDTO> Products { get; set; } = new List<SoldItemDTO>();
    }
}
