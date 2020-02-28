using System;

namespace Ciphers
{
	class CaesarCipher
	{
		#region Private Instance Fields

		private int shiftValue;

		#endregion

		public CaesarCipher(string toEncrypt)
		{
			Console.WriteLine("Original string: " + toEncrypt);
			shiftValue = new Random().Next(1, 26);
			string cleanToEncrypt = CleanString(toEncrypt);
			string encrypted = ApplyCipher(cleanToEncrypt);
			ReverseCipher(encrypted);
		}

		private static string CleanString(string toClean)
		{
			return toClean.ToUpper().Replace(" ", "");
		}

		private string ApplyCipher(string toEncrypt)
		{
			string encrypted = "";
			for (int i = 0; i < toEncrypt.Length; i++) {
				encrypted += EncryptCharacter(toEncrypt[i]);
			}
			Console.WriteLine("Encrypted string: " + encrypted);

			return encrypted;
		}

		private char EncryptCharacter(char toEncrypt)
		{
			int charToInt = toEncrypt;
			int newValue = charToInt + shiftValue;
			int diff;
			char encrypted;
			if (newValue > 90) {
				diff = newValue - 90;
				encrypted = (char) (65 + diff - 1);
			} else {
				encrypted = (char) newValue;
			}

			return encrypted;
		}

		private void ReverseCipher(string toDecrypt)
		{
			string decrypted = "";
			for (int i = 0; i < toDecrypt.Length; i++) {
				decrypted += DecryptCharacter(toDecrypt[i]);
			}
			Console.WriteLine("Ddecrypted string: " + decrypted);
		}

		private char DecryptCharacter(char toDecrypt)
		{
			int charToInt = toDecrypt;
			int newValue = charToInt - shiftValue;
			char decrypted;

			if (newValue < 65) {
				int diff = 65 - newValue;
				decrypted = (char) (90 - diff + 1);
			} else {
				decrypted = (char) newValue;
			}

			return decrypted;
		}
	}
}