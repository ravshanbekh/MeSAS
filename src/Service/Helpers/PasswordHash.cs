﻿using Org.BouncyCastle.Crypto.Generators;

namespace Service.Helpers;

public class PasswordHash
{
    public static string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool Verify(string hashedPassword, string password)
	{
		return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
	}

}
