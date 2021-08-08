using System.Security.Cryptography;

namespace WTelegram
{
  internal static class SHA
  {
    public static SHA1 SHA1 => SHA1.Create();
    public static SHA256 SHA256 => SHA256.Create();
  }
}
