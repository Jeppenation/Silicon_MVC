using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AddressService(AddressRepository repository)
{
    private readonly AddressRepository _addressRepository = repository;

    

    public async Task<ResponseResult> GetOrCreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await GetAddressAsync(streetName, postalCode, city);
            if(result.StatusCode == StatusCodes.NotFound)
            {
                return await CreateAddressAsync(streetName, postalCode, city);
            }
            else
            {
                return result;
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }



    public async Task<ResponseResult> CreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var exists = await _addressRepository.AlreadyExistsAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (exists == null)
            {
                var result = await _addressRepository.CreateAsync(AddressFactory.CreateAddress(streetName, postalCode, city));
                
                if(result.StatusCode == StatusCodes.Ok)
                {
                    return ResponseFactory.Ok(AddressFactory.CreateAddress((AddressEntity)result.ContentResult!));

                }
                else
                {
                    return result;
                }
            }
            else
            {
                return ResponseFactory.Exists();
            }


        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }

    public async Task<ResponseResult> GetAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await _addressRepository.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return result;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }
}
