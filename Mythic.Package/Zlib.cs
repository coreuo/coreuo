using System.IO;
using Ionic.Zlib;

namespace Mythic.Package
{
	/// <summary>
	/// Compression library.
	/// </summary>
	public class Zlib
	{
		#region Decompress
		/// <summary>
		/// Decompresses array of bytes.
		/// </summary>
		/// <param name="dest">Destination byte array.</param>
		/// <param name="destLength">Destination length (Sets it).</param>
		/// <param name="source">Source byte array.</param>
		/// <param name="sourceLength">Source length.</param>
		/// <returns>Error</returns>
		public static void Decompress( byte[] dest, ref int destLength, byte[] source, int sourceLength )
        {
            using var destMemoryStream = new MemoryStream(dest, 0, dest.Length);

            using var zLibStream = new ZlibStream(destMemoryStream, CompressionMode.Decompress);

            using var sourceMemoryStream = new MemoryStream(source, 0, sourceLength);

			sourceMemoryStream.CopyTo(zLibStream);

            destLength = (int) zLibStream.Position;
        }
		#endregion

		#region Compress
		/// <summary>
		/// Compresses array of bytes.
		/// </summary>
		/// <param name="dest">Destination byte array.</param>
		/// <param name="destLength">Destination length (Sets it).</param>
		/// <param name="source">Source byte array.</param>
		/// <param name="sourceLength">Source length.</param>
		/// <returns><see cref="ZLibError.Okay"/> if okay.</returns>
		public static void Compress( byte[] dest, ref int destLength, byte[] source, int sourceLength )
		{
            using var destMemoryStream = new MemoryStream(dest, 0, dest.Length);

            using var zLibStream = new ZlibStream(destMemoryStream, CompressionMode.Compress);

            using var sourceMemoryStream = new MemoryStream(source, 0, sourceLength);

            sourceMemoryStream.CopyTo(zLibStream);

            destLength = (int)zLibStream.Position;
		}

		/// <summary>
		/// Compresses array of bytes.
		/// </summary>
		/// <param name="dest">Destination byte array.</param>
		/// <param name="destLength">Destination length (Sets it).</param>
		/// <param name="source">Source byte array.</param>
		/// <param name="sourceLength">Source length.</param>
		/// <param name="quality"><see cref="ZLibQuality"/> of compression.</param>
		/// <returns><see cref="ZLibError.Okay"/> if okay.</returns>
		public static void Compress( byte[] dest, ref int destLength, byte[] source, int sourceLength, CompressionLevel quality )
		{
            using var destMemoryStream = new MemoryStream(dest, 0, dest.Length);

            using var zLibStream = new ZlibStream(destMemoryStream, CompressionMode.Compress, quality);

            using var sourceMemoryStream = new MemoryStream(source, 0, sourceLength);

            sourceMemoryStream.CopyTo(zLibStream);

            destLength = (int)zLibStream.Position;
		}
		#endregion
	}
}
