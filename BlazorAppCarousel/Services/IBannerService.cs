
namespace BlazorAppCarousel.Services;

public interface IBannerService
{
    Task<List<string>> GetBanners();
}