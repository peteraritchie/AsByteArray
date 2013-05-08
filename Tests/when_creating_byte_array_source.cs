using System.IO;
using AsByteArray;
using Xunit;

namespace Tests
{
	public class when_creating_byte_array_source
	{
		[Fact]
		public void then_is_works()
		{
			var outMemoryStream = new MemoryStream();
			var inMemoryStream = new MemoryStream(new byte[] {1, 2, 3, 4});
			var streamWriter = new StreamWriter(outMemoryStream);
			Program.AsByteArray("bytes", streamWriter, 4, new BinaryReader(inMemoryStream));
			streamWriter.Flush();
			var text = streamWriter.Encoding.GetString(outMemoryStream.ToArray());
			Assert.Equal(@"private static byte[] bytes = 
	{
		0x01, 0x02, 0x03, 0x04, 
	};
", text);
		}
	}
}
