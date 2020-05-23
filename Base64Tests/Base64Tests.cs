using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using EncodeurBase64;
using System.Text;

namespace Base64Tests
{
	[TestClass]
	public class Base64Tests
	{
		[TestMethod]
		public void EncodeStringNoPadding()
		{
			var bytes = Encoding.ASCII.GetBytes("Some s");
			Base64.Encode(bytes).Should().Be(Convert.ToBase64String(bytes));
		}

		[TestMethod]
		public void EncodeStringTwoPadding()
		{
			var bytes = Encoding.ASCII.GetBytes("1234");
			Base64.Encode(bytes).Should().Be(Convert.ToBase64String(bytes));
		}

		[TestMethod]
		public void EncodeStringOnePadding()
		{
			var bytes = Encoding.ASCII.GetBytes("abcde");
			Base64.Encode(bytes).Should().Be(Convert.ToBase64String(bytes));
		}

		[TestMethod]
		public void EncodeBytes()
		{
			var bytes = new byte[] { 106, 119, 196 };
			Base64.Encode(bytes).Should().Be("anfE");
		}
	}
}
