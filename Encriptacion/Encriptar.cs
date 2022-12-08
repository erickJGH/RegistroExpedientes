// using System.Security.Cryptography;
// using System.Text;

// class EncryptMD5
// {

//     public string Encrypt(string Mensaje)
//     {
//         string hash = "BqyYLKZRE35eptkc4Xs3dUa6q^U74H!yGfnGCd!rF$d@Qx*AwG87KCt9kprtjpcJk#uQAcW7iTMtf4&t6PH$Dvs^7ZobsP!5Fz9%3yFa%5!wHi&3*^wN6dcva4MyqYqT";
//         byte[] data = UTF8Encoding.UTF8.GetBytes(Mensaje);

//         MD5 md5 = MD5.Create();
//         TripleDES tripldes = TripleDES.Create();

//         tripldes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
//         tripldes.Mode = CipherMode.ECB;

//         ICryptoTransform transform = tripldes.CreateEncryptor();
//         byte[] resultado = transform.TransformFinalBlock(data, 0, data.Length);

//         return Convert.ToBase64String(resultado);
//     }

//     public string Decrypt(string MensajeEn)
//     {
//         string hash = "BqyYLKZRE35eptkc4Xs3dUa6q^U74H!yGfnGCd!rF$d@Qx*AwG87KCt9kprtjpcJk#uQAcW7iTMtf4&t6PH$Dvs^7ZobsP!5Fz9%3yFa%5!wHi&3*^wN6dcva4MyqYqT";
//         byte[] data = Convert.FromBase64String(MensajeEn);

//         MD5 md5 = MD5.Create();
//         TripleDES tripldes = TripleDES.Create();

//         tripldes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
//         tripldes.Mode = CipherMode.ECB;

//         ICryptoTransform transform = tripldes.CreateDecryptor();
//         byte[] resultado = transform.TransformFinalBlock(data, 0, data.Length);

//         return UTF8Encoding.UTF8.GetString(resultado);
//     }


// }

