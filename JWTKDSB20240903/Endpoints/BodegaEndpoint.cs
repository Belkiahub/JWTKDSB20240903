namespace JWTKDSB20240903.Endpoints
{
    
    
        public static class BodegaEndpoint
        {
            static List<object> bodegas = new List<object>();

            public static void AddBodegaEndpoints(this WebApplication app)
            {
                app.MapPost("/bodega/crear", (string nombre, string ubicacion) =>
                {
                    var nuevaBodega = new { Id = Guid.NewGuid(), Nombre = nombre, Ubicacion = ubicacion };
                    bodegas.Add(nuevaBodega);
                    return Results.Ok(nuevaBodega);
                }).RequireAuthorization();

                app.MapPut("/bodega/modificar/{id}", (Guid id, string nombre, string ubicacion) =>
                {
                    var bodega = bodegas.FirstOrDefault(b => ((Guid)b.GetType().GetProperty("Id").GetValue(b)) == id);
                    if (bodega == null)
                    {
                        return Results.NotFound();
                    }

                    bodega.GetType().GetProperty("Nombre").SetValue(bodega, nombre);
                    bodega.GetType().GetProperty("Ubicacion").SetValue(bodega, ubicacion);
                    return Results.Ok(bodega);
                }).RequireAuthorization();

                app.MapGet("/bodega/obtener/{id}", (Guid id) =>
                {
                    var bodega = bodegas.FirstOrDefault(b => ((Guid)b.GetType().GetProperty("Id").GetValue(b)) == id);
                    return bodega != null ? Results.Ok(bodega) : Results.NotFound();
                }).RequireAuthorization();
            }
        }
    
}
