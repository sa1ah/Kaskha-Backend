using Kashkha.BL.DTOs;
using Kashkha.BL.DTOs.FavoriteDTOs;
using Kashkha.BL.Managers.CartManager;
using Kashkha.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteManager _favoriteManager;

    public FavoriteController(IFavoriteManager favoriteManager)
    {
        _favoriteManager = favoriteManager;
    }

    [HttpPost]
    public async Task<ActionResult<FavoriteDTO>> AddFavorite([FromBody] AddToFavoriteDTO addToFavoriteDTO)
    {
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var favorite = await _favoriteManager.AddFavoriteAsync(userId, addToFavoriteDTO.ProdId);
        //if (IsFavorite(addToFavoriteDTO.ProdId));

        return Ok(new { Message = "Done" });
        //return CreatedAtAction(nameof(GetUserFavorites), new { }, favorite);
    }

    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult> RemoveFavorite(int favoriteId)
    {
        var result = await _favoriteManager.RemoveFavoriteAsync(favoriteId);
        if (!result) return NotFound();
        return Ok(new { Message = "success" });
    }

    [HttpGet("Favorite")]
    public async Task<ActionResult<IEnumerable<FavoriteDTO>>> GetUserFavorites()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var favorites = await _favoriteManager.GetUserFavoritesAsync(userId);
        return Ok(favorites);
    }

    [HttpGet("check/{productId}")]
    public async Task<ActionResult<bool>> IsFavorite(int productId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var isFavorite = await _favoriteManager.IsFavoriteAsync(userId, productId);
        return Ok(isFavorite);
    }
}