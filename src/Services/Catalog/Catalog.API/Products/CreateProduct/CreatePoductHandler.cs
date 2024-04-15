﻿using BuildingBlocks.CQRS;
using MediatR;
namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string description, string ImageFile, decimal Price)
    : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        

        throw new NotImplementedException();
    }
}
