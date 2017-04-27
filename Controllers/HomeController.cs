using System.Net.Http;
using System.Threading.Tasks;
using MagicPricr.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Twilio.TwiML;

namespace MagicPricr.Controllers
{
    public class HomeController : Controller
    {
        private string cardResponse;
        public async Task<IActionResult> Index(string body)
        {
            var card = body;
            using (var client = new HttpClient())
            {
                using(var response = await client.GetAsync($"https://api.scryfall.com/cards/search?q={card}"))
                {
                    var messagingResponse = new MessagingResponse();
                    if(response.IsSuccessStatusCode){
                        var result = await response.Content.ReadAsStringAsync();
                        var prices = JsonConvert.DeserializeObject<RootObject>(result).data[0];
                        cardResponse = messagingResponse.Message($"The card {card} costs: \n ${prices.usd} \n €{prices.eur} \n Tix {prices.tix}").ToString();                        
                    }else{
                        cardResponse = messagingResponse.Message($"The card {card} doesn't exist").ToString();                        
                    }
                    return Content(cardResponse, "text/xml");
                    
                }
            }
        }
    }
}


