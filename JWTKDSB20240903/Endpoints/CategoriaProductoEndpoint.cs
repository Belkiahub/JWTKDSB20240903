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

            app.MapPost("/CategoriaProducto", (string name, string lastName) =>
            {
                data.Add(new { name, lastName });
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
