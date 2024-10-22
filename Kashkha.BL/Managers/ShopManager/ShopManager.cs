using AutoMapper;
using Kashkha.BL;
using Kashkha.BL.DTOs.ShopOwnerDTOs;
using Kashkha.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ShopManager : IShopManager
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public ShopManager(IUnitOfWork unitOfWork, IMapper mapper,IConfiguration configuration)
    {
      
		_unitOfWork = unitOfWork;
		_mapper = mapper;
        _configuration = configuration;
    }

    public async Task<GetOwnerinfo> GetByIdAsync(string id)
    {
        var shopOwner = await _unitOfWork._shopRepository.GetByIdAsync(id);
        var shopOwnerData = new GetOwnerinfo()
        {
            UserId = shopOwner.UserId,
            ShopName = shopOwner.ShopName,
            City = shopOwner.Address.City ?? "",
            Street = shopOwner.Address.Street ?? "",
            ProfilePicture = _configuration["ApiBaseUrl"] + shopOwner.ProfilePicture,
            Id = shopOwner.Id,
            phone = shopOwner.User.PhoneNumber,
            Product = shopOwner.Products
        };
        foreach(var i in shopOwnerData.Product)
        {
            i.PictureUrl = _configuration["ApiBaseUrl"] + i.PictureUrl;
		}

		return shopOwnerData;
    }

    public async Task<Shop> GetShopByIdAsync(Guid shopId) {
        var shopProd =await _unitOfWork._shopRepository.GetShopByIdAsync(shopId);
        foreach (var i in shopProd.Products)
        {
            i.PictureUrl = _configuration["ApiBaseUrl"] + i.PictureUrl;
        }
        shopProd.ProfilePicture = _configuration["ApiBaseUrl"] + shopProd.ProfilePicture;
        return shopProd;
    }
    // public async Task<IEnumerable<ShopOwnerDTO>> GetAllAsync()
    // {
    //     var shopOwners = await _shopOwnerRepo.GetAllAsync();
    //     return _mapper.Map<IEnumerable<ShopOwnerDTO>>(shopOwners);
    // }

    public async Task<int?> AddAsync(ShopOwnerDTO shopOwnerDto)
    {
        var img = DocumentSettings.UploadFile(shopOwnerDto.ProfilePicture);
        Address address = new Address()
        {
            City= shopOwnerDto.City,
            Street=shopOwnerDto.Street,
            Country="Egypt"
        };
     //   var shopOwner = _mapper.Map<Shop>(shopOwnerDto);
        await _unitOfWork._shopRepository.AddAsync(new Shop(){
            Id= (Guid)shopOwnerDto.Id,
            ProfilePicture=img,
            ShopName=shopOwnerDto.ShopName,
            UserId=shopOwnerDto.UserId,
            Address= address
		});
       int? result= _unitOfWork.Complete();
        if (result is null)
            return null;
        return result;
    }

    public async Task UpdateAsync(ShopOwnerDTO shopOwnerDto)
    {
        var shopOwner = _mapper.Map<Shop>(shopOwnerDto);
        await _unitOfWork._shopRepository.UpdateAsync(shopOwner);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork._shopRepository.DeleteAsync(id);
    }
}