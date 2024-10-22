using Kashkha.BL.DTOs;
using Kashkha.BL.DTOs.FavoriteDTOs;
using Kashkha.DAL;

public interface IFavoriteManager
{
    Task<FavoriteDTO> AddFavoriteAsync(string userId, int productId);

    Task<bool> RemoveFavoriteAsync(int favoriteId);
    Task<List<GetFavoriteDto>> GetUserFavoritesAsync(string userId);
    Task<bool> IsFavoriteAsync(string userId, int productId);
}