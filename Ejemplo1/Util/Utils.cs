using Ejemplo1.Models;

namespace Ejemplo1.Util
{
    public class Utils
    {
        public static List<Producto> ListaProducto = new List<Producto>()
        {
            new Producto(){ 
                IdProducto = 1,
                Nombre="Producto1",
                Descripcion="Descripcion 1",
                Cantidad=1
            },

            new Producto(){
                IdProducto = 2,
                Nombre="Producto2",
                Descripcion="Descripcion 2",
                Cantidad=2
            },

            new Producto(){
                IdProducto = 3,
                Nombre="Producto3",
                Descripcion="Descripcion 3",
                Cantidad=3
            }


        };
    }
}
