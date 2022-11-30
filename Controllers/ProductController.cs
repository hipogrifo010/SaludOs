using AlkemyWallet.Core.Helper;
using ApiSalud.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static AlkemyWallet.Core.Helper.Constants;

namespace ApiSalud.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;


    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> GetFixedTermDepositByUserId(int page)
    {
        var result =
            await _productService.GetProductsPagingdos(page <= 0 ? page = PageListed.PAGE : page, PageListed.PAGESIZE);
        if (result.totalPages < page) return NotFound(CAT_NOT_FOUND_PAGE);

        var pagedTransactions = new PageListed(page, result.totalPages);
        pagedTransactions.AddHeader(Response, Url.ActionLink(null, "Product", null, "https"));
        return Ok(result.recordList);
    }
}