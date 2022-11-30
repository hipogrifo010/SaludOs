using Newtonsoft.Json;

namespace AlkemyWallet.Core.Helper;

public class PageListed
{
    public const int PAGE = 1;
    public const int PAGESIZE = 10;

    public PageListed(int pageNumber, int totalPages)
    {
        CurrentPage = pageNumber;
        TotalPages = totalPages;
    }

    public int CurrentPage { get; }
    public int TotalPages { get; }
    private bool HasPrevious => CurrentPage > 1;
    private bool HasNext => CurrentPage < TotalPages;

    internal void AddHeader(HttpResponse response, string? urlBase)
    {
        var UrlPrev = HasPrevious ? CreateUrl(urlBase, CurrentPage - 1) : null;
        var UrlNext = HasNext ? CreateUrl(urlBase, CurrentPage + 1) : null;
        var metadata = new { CurrentPage, UrlPrev, UrlNext, TotalPages, PAGESIZE };
        response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
    }

    private string? CreateUrl(string? urlBase, int page)
    {
        return urlBase + (urlBase!.Contains('?') ? "&" : "?") + "page=" + page;
    }
}