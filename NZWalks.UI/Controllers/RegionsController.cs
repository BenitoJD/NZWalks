using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models;
using NZWalks.UI.Models.DTO;
using System.Text;
using System.Text.Json;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            //Get all regions from web api
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7177/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>() ?? Enumerable.Empty<RegionDto>());

            }
            catch (Exception ex)
            {

                throw;
            }



            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient();

                var httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7177/api/regions"),
                    Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
                };  
                var httpResponseMessage = await client.SendAsync(httpRequestMessage);
                httpResponseMessage.EnsureSuccessStatusCode();

                var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

                if(response is not null)
                {
                    return RedirectToAction("Index", "Regions");
                }


            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var httpResponseMessage =  await client.GetFromJsonAsync<RegionDto>($"https://localhost:7177/api/regions/{id.ToString()}");

            if(Response is not null)
            {
                return View(httpResponseMessage);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> edit(RegionDto region)
        {
            var client = httpClientFactory.CreateClient();
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7177/api/regions/{region.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(region), Encoding.UTF8, "application/json")
            };
           var httpResponseMessgage =  await client.SendAsync(request);

            httpResponseMessgage.EnsureSuccessStatusCode();

            var response = await httpResponseMessgage.Content.ReadFromJsonAsync<RegionDto>();

            if(response is not null)
            {
                return RedirectToAction("Edit", "Regions");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7177/api/regions/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Regions");

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show an error message, etc.)
                throw;
            }

            return View("Edit");

        }
    }
}
