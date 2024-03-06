using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Model;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class UserService(UserRepository userRepository, AddressService addressService)
{
    private readonly UserRepository _userRepository = userRepository;
    private readonly AddressService _addressService = addressService;

    public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {
            var exists = await _userRepository.AlreadyExistsAsync(x => x.Email == model.EmailAddress);
            if (exists.StatusCode != StatusCodes.Exists)
            {
                var result = await _userRepository.CreateAsync(UserFactory.Create(model));
                if (result.StatusCode == StatusCodes.Created)
                    return ResponseFactory.Ok("User was created successfully.");

                return result;
            }

            return exists;




        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }


    public async Task<ResponseResult> SignInUserAsync(SignInModel model)
    {
        try
        {
            var user = await _userRepository.GetOneAsync(x => x.Email == model.EmailAddress);
            if (user.StatusCode == StatusCodes.Ok && user.ContentResult != null)
            {
                var userEntity = (UserEntity)user.ContentResult;

                if(PasswordHasher.ValidateSecurePassword(model.Password, userEntity.PasswordHash!, userEntity.SecurityKey))
                    return ResponseFactory.Ok();
            }

            return ResponseFactory.Error("Invalid username or password.");




        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }
}
