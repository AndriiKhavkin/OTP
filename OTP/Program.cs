using System;
using System.Linq;

public class OneTimePad
{
    private static byte[] textToBytes(string text)
    {
        byte[] bytes = new byte[text.Length * 2];
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            bytes[i * 2] = (byte)(c >> 8);
            bytes[i * 2 + 1] = (byte)c;
        }

        return bytes;
    }

    private static string bytesToText(byte[] bytes)
    {
        var charArray = bytes.Select((b, i) => (char)((bytes[i * 2] << 8) | (bytes[i * 2 + 1] & 0xFF))).ToArray();
        return new string(charArray);
    }

    private static byte[] xor(byte[] a, byte[] b)
    {
        byte[] result = new byte[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = (byte)(a[i] ^ b[i]);
        }

        return result;
    }

    public static void Main()
    {
        string message =
            "Слово – найтонший дотик до серця; воно може стати і ніжною запашною квіткою, і живою водою, що повертає віру в добро, і гострим ножем, і розпеченим залізом, і брудом. Василь СУХОМЛИНСЬКИЙ";
        string key = "110000 011110 010100 110010 010110 011110";
        string[] keyStrings = key.Split(' ');
        byte[][] keyBytes = new byte[keyStrings.Length][];
        Console.WriteLine(textToBytes("abc"));
        for (int i = 0; i < keyStrings.Length; i++)
        {
            string keyString = keyStrings[i];
            Console.WriteLine(keyString);
            //  byte[] keyByte = new byte[2];
            //  keyByte[0] = Convert.ToByte(keyString.Substring(0, 8), 2);
            //  keyByte[1] = Convert.ToByte(keyString.Substring(8), 2);
            //  keyBytes[i] = keyByte;
        }
        //
         byte[] messageBytes = textToBytes(message);
        // byte[] encryptedBytes = new byte[messageBytes.Length];
        // for (int i = 0; i < messageBytes.Length; i += 2)
        // {
        //     int keyIndex = i / 2 % keyBytes.Length;
        //     byte[] keyByte = keyBytes[keyIndex];
        //     byte[] messageByte = new byte[2];
        //     messageByte[0] = messageBytes[i];
        //     messageByte[1] = messageBytes[i + 1];
        //     byte[] encryptedByte = xor(messageByte, keyByte);
        //     encryptedBytes[i] = encryptedByte[0];
        //     encryptedBytes[i + 1] = encryptedByte[1];
        // }
        //
        // string encryptedMessage = bytesToText(encryptedBytes);
        // Console.WriteLine("Encrypted message: " + encryptedMessage);
        //
        // byte[] decryptedBytes = new byte[encryptedBytes.Length];
        // for (int i = 0; i < encryptedBytes.Length; i += 2)
        // {
        //     int keyIndex = i / 2 % keyBytes.Length;
        //     byte[] keyByte = keyBytes[keyIndex];
        //     byte[] encryptedByte = new byte[2];
        //     encryptedByte[0] = encryptedBytes[i];
        //     encryptedByte[1] = encryptedBytes[i + 1];
        //     byte[] decryptedByte = xor(encryptedByte, keyByte);
        //     decryptedBytes[i] = decryptedByte[0];
        //     decryptedBytes[i + 1] = decryptedByte[1];
        // }
        //
        // string decryptedMessage = bytesToText(decryptedBytes);
        // Console.WriteLine("Decrypted message: " + decryptedMessage);
    }
}