using MediatR;
using SiggAgroCoop.Application.Inventory.DTOs;

namespace SiggAgroCoop.Application.Inventory.Queries.GetProducts;

public class GetProductsQuery : IRequest<List<ProductDto>> { }
