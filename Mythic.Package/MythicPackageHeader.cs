using System;
using System.IO;
using System.Collections.Generic;

namespace Mythic.Package
{
	/// <summary>
	/// Class describing .uop file header.
	/// </summary>
	public class MythicPackageHeader
	{
		#region SupportedVersion
		/// <summary>
		/// Supported version.
		/// </summary>
		public static int SupportedVersion{ get{ return 5; } }
		#endregion

		#region DefaultMisc
		/// <summary>
		/// Default misc value.
		/// </summary>
		public static uint DefaultMisc{ get{ return 0xFD23EC43; } }
		#endregion

		#region DefaultStartAddress
		/// <summary>
		/// Default start address.
		/// </summary>
		public static int DefaultStartAddress{ get{ return 0x200; } }
		#endregion

		#region DefaultBlockSize
		/// <summary>
		/// Default <see cref="Mythic.Package.MythicPackageHeader.BlockSize"/>.
		/// </summary>
		public static int DefaultBlockSize{ get{ return 1000; } }
		#endregion

		#region Version
		private int _Version;

		/// <summary>
		/// Version of .uop format.
		/// </summary>
		public int Version
		{
			get{ return _Version; }
			set{ _Version = value; }
		}
		#endregion

		#region Misc
		private uint _Misc;

		/// <summary>
		/// Probably format release date and time
		/// </summary>
		public uint Misc
		{
			get{ return _Misc; }
			set{ _Misc = value; }
		}
		#endregion

		#region StartAddress
		private long _StartAddress;

		/// <summary>
		/// Start of the first <see cref="Mythic.Package.MythicPackageBlock"/>.
		/// </summary>
		public long StartAddress
		{
			get{ return _StartAddress; }
			set{ _StartAddress = value; }
		}
		#endregion

		#region BlockSize
		private int _BlockSize;

		/// <summary>
		/// Maximum amount of files that one <see cref="Mythic.Package.MythicPackageBlock"/> can hold.
		/// </summary>
		public int BlockSize
		{
			get{ return _BlockSize; }
			set{ _BlockSize = value; }
		}
		#endregion

		#region FileCount
		private int _FileCount;

		/// <summary>
		/// Number if files in this .uop file.
		/// </summary>
		public int FileCount
		{
			get{ return _FileCount; }
			set{ _FileCount = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public MythicPackageHeader( int version )
		{
			_Version = version;
			_Misc = DefaultMisc;
			_StartAddress = DefaultStartAddress;
			_BlockSize = DefaultBlockSize;

			_FileCount = 0;
		}

		/// <summary>
		/// Creates a new instance from <paramref name="reader"/>.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		public MythicPackageHeader( BinaryReader reader )
		{
			byte[] id = reader.ReadBytes( 4 );

			if ( id[ 0 ] != 'M' || id[ 1 ] != 'Y' || id[ 2 ] != 'P' || id[ 3 ] != 0 )
				throw new FormatException( "This is not a Mythic Package file!" );

			_Version = reader.ReadInt32();

			if ( _Version > SupportedVersion )
				throw new FormatException( "Unsupported version!" );

			_Misc = reader.ReadUInt32();
			_StartAddress = reader.ReadInt64();

			_BlockSize = reader.ReadInt32();
			_FileCount = reader.ReadInt32();
		}
		#endregion

		#region Save
		/// <summary>
		/// Saves .uop header to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void Save( BinaryWriter writer )
		{
			writer.Write( (byte) 'M' );
			writer.Write( (byte) 'Y' );
			writer.Write( (byte) 'P' );
			writer.Write( (byte) 0x0 );

			writer.Write( _Version );
			writer.Write( _Misc );
			writer.Write( _StartAddress );
			writer.Write( _BlockSize );
			writer.Write( _FileCount );

			for ( int i = 28; i < _StartAddress; i++ )
				writer.Write( (byte) 0x0 );
		}
		#endregion
	}
}
