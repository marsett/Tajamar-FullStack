using System;
using ZuvoPet_V2.Helpers;
class GenerarSalt
{
    static void Main()
    {
        string password = "contrasenamario"; // Cambia por la contraseña real
        string salt = HelperCriptography.GenerateSalt();
        byte[] encryptedPassword = HelperCriptography.EncryptPassword(password, salt);

        Console.WriteLine("Salt (Base64): " + salt);
        Console.WriteLine("Contraseña Encriptada (Hex): " + BitConverter.ToString(encryptedPassword).Replace("-", ""));
    }
}