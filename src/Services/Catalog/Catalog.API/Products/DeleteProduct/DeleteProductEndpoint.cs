namespace Catalog.API.Products.DeleteProduct;

public record DeletePoductResponse(Guid Id);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}",
        async (Guid id, ISender sender) =>
        {            
            var result = await sender.Send(new DeleteProductCommand(id));
            var response = result.Adapt<DeletePoductResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<DeletePoductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}
