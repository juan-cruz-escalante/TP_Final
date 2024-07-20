using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Dominio;

namespace WebApplication
{
    public class MercadoPagoBack
    {
        public async Task<string> CreatePreferenceAsync()
        {
            var articulos = HttpContext.Current.Session["Carrito"] as List<Articulos>;

            if (articulos == null || articulos.Count == 0)
            {
                throw new InvalidOperationException("El carrito está vacío o no existe.");
            }

            var items = new List<PreferenceItemRequest>();

            foreach (var art in articulos)
            {
                items.Add(new PreferenceItemRequest
                {
                    Title = art.Nombre,
                    Quantity = art.contador,
                    CurrencyId = "ARS",
                    UnitPrice = (decimal)art.Precio
                });
            }

            var request = new PreferenceRequest
            {
                Items = items,
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "Inicio.aspx",
                    Failure = "CarritoDeCompras.aspx",
                    Pending = "CarritoDeCompras.aspx"
                },
                AutoReturn = "approved"
            };

            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            return preference.Id;
        }
    }
}