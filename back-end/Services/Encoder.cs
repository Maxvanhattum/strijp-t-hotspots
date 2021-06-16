using Models;
using Services.Interfaces;
using System;

namespace Services
{
    public class Encoder : IEncoder
    {
        public bool ComparePassword(User userToVerify, string rawPassword)
        {

            if (userToVerify == null)
            {
                throw new Exception("Email not associated with an employee");
            }
            return BCrypt.Net.BCrypt.Verify(rawPassword, userToVerify.Password);
        }

        public string HashPassword(string rawPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(rawPassword);
        }

    }
}
