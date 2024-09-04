namespace JWTKDSB20240903.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddCategoriaEndpoints(this WebApplication app)
        {
            app.MapGet("/CategoriaProducto", () =>
            {
                return data;
            }).AllowAnonymous();

            app.MapPost("/CategoriaProducto", (string name, string description) =>
            {
                data.Add(new { name, description });
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
