using System;
using System.Collections.Generic;
using System.Text;

namespace EncodeurBase64
{
	public static class Base64
	{
		private const int NB_BITS_PER_CHAR = 6;

		private static char[] charactersTable = new char[]
		{
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '/', '+'
		};
		public static String Encode(byte[] source)
		{
			int mod = source.Length % 3;
			var nbPadding = mod == 2 ? 1 : mod % 3 == 1 ? 2 : 0;
			StringBuilder result = new StringBuilder();

			var listBits = ConvertByteArrayToBoolList(source);
			for (int i = 0; i < nbPadding; i++)
				listBits.AddRange(ConvertByteToBoolArray(Byte.MinValue));

			var bits = listBits.ToArray();

			for (int i = 0; i < bits.Length - (nbPadding * NB_BITS_PER_CHAR); i += NB_BITS_PER_CHAR)
			{
				int charIndex = 0;
				for (int k = 0; k < NB_BITS_PER_CHAR; k++)
				{
					if (bits[i + k])
						charIndex += 1 << (NB_BITS_PER_CHAR - 1 - k);
				}
				result.Append(charactersTable[charIndex]);
			}

			for (int i = 0; i < nbPadding; i++)
				result.Append("=");

			return result.ToString();
		}

		private static bool[] ConvertByteToBoolArray(byte b)
		{
			bool[] result = new bool[8];

			for (int i = 0; i < 8; i++)
				result[i] = (b & (1 << i)) == 0 ? false : true;

			Array.Reverse(result);

			return result;
		}

		private static List<bool> ConvertByteArrayToBoolList(byte[] b)
		{
			List<bool> lst = new List<bool>();
			foreach (var by in b)
				lst.AddRange(ConvertByteToBoolArray(by));

			return lst;
		}

	}
}
