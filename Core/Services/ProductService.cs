using ApiSalud.Core.Interfaces;
using ApiSalud.Core.Models.DTO;
using ApiSalud.Entities;
using ApiSalud.Repositories.Interfaces;
using AutoMapper;

namespace ApiSalud.Core.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<(int totalPages, IEnumerable<Product> recordList)> GetProductsPagingdos(int pageNumber,
        int pageSize)
    {
        return await _unitOfWork.ProductRepository!.GetAllPaging(pageNumber, pageSize);


        //  var result = _unitOfWork.ProductRepository.GetAllPaging(pageNumber, pageSize).Result.recordList.AsEnumerable().OrderBy//(x=>x.ProductName);
        //
        //
        //  return result;
    }

    public Task InsertProduct(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDeposit(int id, ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var result = await _unitOfWork.ProductRepository!.GetAll();


        return result;
    }
}