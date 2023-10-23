using Ejemplo1.Models;
using Ejemplo1.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {

        Uri baseAddress = new Uri("http://localhost:5129/api");
        private readonly HttpClient _client;

        public ProductoController()
        {
            
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        // GET: ProductoController
        public IActionResult Index()
        {   
            List<Producto> productos = new List<Producto>();
            HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress +"/Producto").Result;

            if (respone.IsSuccessStatusCode) {
                String data = respone.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.DeserializeObject<List<Producto>>(data);
            }
            
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int IdProducto)
        {
            Producto producto = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {

                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync(_client.BaseAddress + "/Producto", producto).Result;
            return RedirectToAction("Index");
        }


        
        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            Producto nuevo = await _client.GetFromJsonAsync<Producto>(_client.BaseAddress + "/Producto/" + IdProducto);
            if (nuevo != null)
            {

                return View(nuevo);
            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult Edit( Producto producto)
        {
            HttpResponseMessage respone = _client.PutAsJsonAsync(_client.BaseAddress + "/Producto/" + producto.IdProducto, producto).Result;
            return RedirectToAction("Index");

        }


        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Producto/" + IdProducto).Result;
            return RedirectToAction("Index");
        }

    }
}
