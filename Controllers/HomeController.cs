using ConsumeDogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeDogAPI.Controllers;

public class HomeController : Controller
{
    private readonly DogApiService _dogApiService;

    public HomeController(DogApiService dogApiService)
    {
        _dogApiService = dogApiService;
    }

    public async Task<IActionResult> Index()
    {
        var terrierSubBreeds = await _dogApiService.GetTerrierSubBreed();
        //var sortedSubBreeds = _dogApiService.SortByLengthBubbleSort(terrierSubBreeds);
        var sortedSubBreeds = _dogApiService.SortAlphabeticallyAndByLength(terrierSubBreeds);
        return View(sortedSubBreeds);
    }
}