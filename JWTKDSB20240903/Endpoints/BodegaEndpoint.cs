using System.Dynamic;

namespace JWTKDSB20240903.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<ExpandoObject> data = new List<ExpandoObject>();

        public static void AddBodegaEndpoints(this WebApplication app)
        {
            app.MapGet("/bodega", () =>
            {
                return data;
            }).RequireAuthorization();

            app.MapPost("/bodega", (int id, string nombre, string ubicacion) =>
            {
                dynamic bodega = new ExpandoObject();
                bodega.id = id;
                bodega.nombre = nombre;
                bodega.ubicacion = ubicacion;

                data.Add(bodega);
                return Results.Ok();
            }).RequireAuthorization();

            app.MapPut("/bodega/{id}", (int id, string nombre, string ubicacion) =>
            {
                // Buscando la bodega por id
                var bodega = data.FirstOrDefault(b =>
                    ((IDictionary<string, object>)b)["id"].Equals(id));

                if (bodega == null)
                {
                    return Results.NotFound();
                }

                // Actualizando las propiedades dinámicamente
                var bodegaDict = (IDictionary<string, object>)bodega;
                bodegaDict["nombre"] = nombre;
                bodegaDict["ubicacion"] = ubicacion;

                return Results.Ok(bodega);
            }).RequireAuthorization();
        }
    }
}
