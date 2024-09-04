using JWTKDSB20240903.Models;
using System.Dynamic;

namespace JWTKDSB20240903.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<bodega> bodegas = new List<bodega>();

        public static void AddBodegaEndpoints(this WebApplication app)
        {
            app.MapGet("/bodega", () =>
            {
                return bodegas;
            }).RequireAuthorization();

            app.MapGet("/bodega/{id}", (int id) =>
            {
                var bodeg = bodegas.FirstOrDefault(c => c.Id == id);
                return bodeg;
            }).RequireAuthorization();

            app.MapPost("/bodega", (bodega bodega1) =>
            {
                bodegas.Add(bodega1);
                return Results.Ok();

            }).RequireAuthorization();

            app.MapPut("/bodega/{id}", (int id, bodega bodegaa) =>
            {
                var existingBog = bodegas.FirstOrDefault(c => c.Id == id);
                if (existingBog != null)
                {
                    existingBog.nombre = bodegaa.nombre;
                    existingBog.ubicacion = bodegaa.ubicacion;
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }

            }).RequireAuthorization();




        }
    }
}
