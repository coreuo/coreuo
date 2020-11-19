using System;

namespace Mythic.Package
{
	/// <summary>
	/// The exception that is thrown when adding a file to a full <see cref="MythicPackageBlock"/>.
	/// </summary>
	public class BlockFullException : SystemException
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public BlockFullException() : base( "Block is full!" )
		{
		}
	}

    /// <summary>
    /// The exception that is thrown when loading a <see cref="MythicPackageFile"/>, which is compressed
    /// using unknown compression.
    /// </summary>
    public class InvalidCompressionException : SystemException
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public InvalidCompressionException( short flag ) : base($"Invalid compression flag: {flag}!")
		{
		}
	}

    /// <summary>
	/// The exception that is thrown when Unpacking a <see cref="MythicPackageFile"/> and size of the data read from .uop 
	/// doesn't match <see cref="MythicPackageFile.CompressedSize"/>.
	/// </summary>
	public class StreamSourceException : SystemException
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public StreamSourceException() : base( "Error reading data from stream!" )
		{
		}
	}
}
