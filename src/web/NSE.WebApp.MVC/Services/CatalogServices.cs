using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class CatalogServices : Service, ICatalogServices
    {
        private readonly HttpClient _httpClient;

        public CatalogServices(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CatalogUrl);
            _httpClient = httpClient;

        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync(requestUri: $"/catalog/products/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ProductViewModel>(response);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync(requestUri: $"/catalog/products/");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<IEnumerable<ProductViewModel>>(response);
        }
    }
}
