using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AsByteArray
{
	public class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Usage();
				return;
			}

			var fileStream = File.OpenRead(args[0]);
			using (var reader = new BinaryReader(fileStream))
			{
				AsByteArray("bytes", Console.Out, fileStream.Length, reader);
			}

		}

		private static void Usage()
		{
			Console.WriteLine("AsByteArray filename");
		}

		public static void AsByteArray(string variableName, TextWriter writer, long length, BinaryReader reader)
		{
			writer.WriteLine("private static byte[] {0} = ", variableName);
			writer.Write("\t{");
			for (int i = 0; i < length; i++)
			{
				if (i%15 == 0)
				{
					writer.WriteLine();
					writer.Write("\t\t");
				}
				writer.Write("0x{0:X2}, ", reader.ReadByte());
			}
			writer.WriteLine();
			writer.WriteLine("\t};");
		}
	}
}
