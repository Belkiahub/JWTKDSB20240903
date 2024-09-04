using System.Xml.Linq;

namespace JWTKDSB20240903.Endpoints
{
    
    
        public static class BodegaEndpoint
        {
            static List<object> data = new List<object>();

            public static void AddBodegaEndpoints(this WebApplication app)
            {
                app.MapGet("/bodega", () =>
                {

                    return data;
                }).RequireAuthorization();

                app.MapPost("/bodega", (int id, string nombre, string ubicacion) =>
                {
                    data.Add(new { id, nombre, ubicacion });
                    return Results.Ok();
                }).RequireAuthorization();

                app.MapPut("/bodega/{id}", (int id, string nombre, string ubicacion) =>
                {
                    var bodega = data.FirstOrDefault(b => (int)((Dictionary<string, object>)b)["id"] == id);

                    if (bodega == null)
                    {
                        return Results.NotFound();
                    }

                    var bodegaDict = (Dictionary<string, object>)bodega;

                    bodegaDict["nombre"] = nombre;
                    bodegaDict["ubicacion"] = ubicacion;

                    return Results.Ok(bodegaDict);
                }).RequireAuthorization();



        }
    }
    
}
