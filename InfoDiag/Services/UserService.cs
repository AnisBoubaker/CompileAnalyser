namespace Services.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using AutoMapper;
    using Entity.DTO;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Repositories.Interfaces;
    using Services.Interfaces;
    using Services.Models;

    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ServiceCallResult<UserDto> AuthenticateUser(LoginDto dto)
        {
            var user = _userRepository.Get(u => u.Email == dto.Email).SingleOrDefault();

            if (user == null)
            {
                return Error<UserDto>("User does not exist");
            }

            if (VerifyPassword(user.Password, dto.Password))
            {
                return Success(_mapper.Map<UserDto>(user));
            }

            return Error<UserDto>("The username password combo does not match");
        }

        public bool ChangePassword(LoginDto dto, string newPassword)
        {
            var user = _userRepository.Get(u => u.Email == dto.Email).SingleOrDefault();

            if (user == null)
            {
                return false;
            }

            if (VerifyPassword(user.Password, dto.Password))
            {
                user.Password = EncryptPassword(newPassword);
                _userRepository.Update(user);

                return true;
            }

            return false;
        }

        public ServiceCallResult Exists(int userId)
        {
            return _userRepository.AllAsQueryable.Any(u => u.Id == userId) ? Success(): Error("The specified user id does not exist");
        }

        public ServiceCallResult<IEnumerable<UserDto>> GetAll()
        {
            return Success(_mapper.Map<IEnumerable<UserDto>>(_userRepository.AllAsQueryable.Where(u => u.Role != Constants.Enums.UserRole.Admin)));
        }

        private string EncryptPassword(string password)
        {
            const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
            const int Pbkdf2IterCount = 10000; // default for Rfc2898DeriveBytes
            const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
            const int SaltSize = 128 / 8; // 128 bits

            // Produce a version 2 (see comment above) text hash.
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            var outputBytes = new byte[SaltSize + Pbkdf2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 0, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, SaltSize, Pbkdf2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var decoded = Convert.FromBase64String(hashedPassword);
            const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
            const int Pbkdf2IterCount = 10000; // default for Rfc2898DeriveBytes
            const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
            const int SaltSize = 128 / 8; // 128 bits

            // We know ahead of time the exact length of a valid hashed password payload.
            if (decoded.Length != SaltSize + Pbkdf2SubkeyLength)
            {
                return false;
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(decoded, 0, salt, 0, salt.Length);

            byte[] expectedSubkey = new byte[Pbkdf2SubkeyLength];
            Buffer.BlockCopy(decoded, salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            byte[] actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
        }
    }
}