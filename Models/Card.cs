using System.Collections.Generic;

namespace MagicPricr.Models
{
    public class RootObject
    {
        public List<Card> data { get; set; }
    }

    public class Card
    {
        public string id { get; set; }
        public string image_uri { get; set; }
        public string usd { get; set; }
        public string tix { get; set; }
        public string eur { get; set; }
    }
}