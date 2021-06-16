using DataTransferObjects;
using Models;
using Repositories;
using Services.Interfaces;
using System;

namespace Services
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        private IEncoder _encoder;
        private IUserRepository _userRepository;
        private IJWTHandler _jWTHandler;

        public AuthenticationHandler(IEncoder encoder, IUserRepository userRepository, IJWTHandler jWTHandler)
        {
            _encoder = encoder;
            _userRepository = userRepository;
            _jWTHandler = jWTHandler;
        }

        public User CreateUser(UserCreateRequestDTO createDTO)
        {
            if (CheckIfEmailAssociatedWithAccount(createDTO.Email))
            {
                throw new Exception("Email already used");
            }
            string password = _encoder.HashPassword(createDTO.Password);
            User createdUser = _userRepository.Create(new UserCreateRequestDTO(createDTO.Email,
                password, createDTO.Firstname, createDTO.Lastname, ViewModels.Enums.Role.ADMIN.ToString()));
            createdUser.Password = "";
            return createdUser;

        }

        public string LoginUser(UserLoginRequestDTO loginDTO)
        {
            if (CheckIfEmailAssociatedWithAccount(loginDTO.Email))
            {
                User userToVerify = _userRepository.GetByEmail(loginDTO.Email);
                if (_encoder.ComparePassword(userToVerify, loginDTO.Password))
                {
                    userToVerify.Password = "";
                    return _jWTHandler.GenerateToken(userToVerify, loginDTO.RememberMe);
                }
                throw new Exception("Invalid password");
            }
            throw new Exception("Invalid email");
        }

        private bool CheckIfEmailAssociatedWithAccount(string email)
        {
            if (_userRepository.GetByEmail(email) == null)
            {
                return false;
            }
            return true;
        }

    }
}
