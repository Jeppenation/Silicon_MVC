using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class UserService(UserRepository userRepository, AddressService addressService)
{
    private readonly UserRepository _userRepository = userRepository;
    private readonly AddressService _addressService = addressService;

    public async Task <ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {
            var result = await _userRepository.AlreadyExistsAsync(x => x.Email == model.EmailAddress);

            if (result.StatusCode != StatusCodes.InternalServerError)
            {
                result = await _userRepository.CreateAsync(UserFactory.Create(model));
                if (result.StatusCode != StatusCodes.Ok)
                {
                    return ResponseFactory.Error("User not created");
                }
                else
                {
                    return result;
                }
            }
            return result;

        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }
}
