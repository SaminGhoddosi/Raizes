﻿using System.Security.Cryptography;
using System.Text;

namespace MinhaPrimeiraApi.Infrastructure;

public class Criptografy
{

    public static string Criptografar(string textoClaro)
    {
        var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        var rfc = new Rfc2898DeriveBytes(textoClaro, salt, 10000);
        byte[] key = rfc.GetBytes(32);
        return BitConverter.ToString(key).Replace("-", "").ToLower();
    }
}