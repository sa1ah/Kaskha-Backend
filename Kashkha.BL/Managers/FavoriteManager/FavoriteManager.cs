using AutoMapper;
using Kashkha.BL.DTOs;
using Kashkha.BL.DTOs.FavoriteDTOs;
using Kashkha.DAL;
using Microsoft.Extensions.Configuration;

public class FavoriteManager : IFavoriteManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public FavoriteManager(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<FavoriteDTO> AddFavoriteAsync(string userId, int productId)
    {
        if (await _unitOfWork._favoriteRepository.ExistsAsync(userId, productId))
            throw new InvalidOperationException("Favorite already exists");

        var favorite = new Favorite { UserId = userId, ProductId = productId };
        var result = await _unitOfWork._favoriteRepository.AddAsync(favorite);
        return _mapper.Map<FavoriteDTO>(result);
    }

    public async Task<bool> RemoveFavoriteAsync(int favoriteId)
    {
        return await _unitOfWork._favoriteRepository.RemoveAsync(favoriteId);
    }

    public async Task<List<GetFavoriteDto>> GetUserFavoritesAsync(string userId)
    {
        var favorites = await _unitOfWork._favoriteRepository.GetByUserIdAsync(userId);
        foreach (var item in favorites)
        {
            item.Product.PictureUrl = _configuration["ApiBaseUrl"] +item.Product.PictureUrl;
        }
        return _mapper.Map<List<GetFavoriteDto>>(favorites);
    }

    public async Task<bool> IsFavoriteAsync(string userId, int productId)
    {
        return await _unitOfWork._favoriteRepository.ExistsAsync(userId, productId);
    }
}