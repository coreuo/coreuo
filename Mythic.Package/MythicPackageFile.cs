using System;
using System.IO;
using System.Text;
using Ionic.Zlib;

namespace Mythic.Package
{
	/// <summary>
	/// Class describing a file within .uop.
	/// </summary>
	public class MythicPackageFile
	{
		#region Size
		/// <summary>
		/// Size of the file header.
		/// </summary>
		public static int Size{ get{ return 34; } }
		#endregion

		#region Parent
		private MythicPackageBlock _Parent;

		/// <summary>
		/// Reference to <see cref="Mythic.Package.MythicPackageBlock"/>, which contains this file.
		/// </summary>
		public MythicPackageBlock Parent
		{
			get{ return _Parent; }
			set{ _Parent = value; }
		}
		#endregion

		#region Index
		private int _Index;

		/// <summary>
		/// Index of this file in the <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.
		/// </summary>
		public int Index
		{
			get{ return _Index; }
			set{ _Index = value; }
		}
		#endregion

		#region DataBlockAddress
		private long _DataBlockAddress;
		private long _OldDataBlockAddress;

		/// <summary>
		/// Address of actual data.
		/// </summary>
		public long DataBlockAddress
		{
			get{ return _DataBlockAddress; }
		}
		#endregion

		#region DataBlockLength
		private int _DataBlockLength;
		
		/// <summary>
		/// Length of the data header.
		/// </summary>
		public int DataBlockLength
		{
			get{ return _DataBlockLength; }
		}
		#endregion

		#region CompressedSize
		private int _CompressedSize;

		/// <summary>
		/// Size of the compressed file. Equals to <see cref="Mythic.Package.MythicPackageFile.DecompressedSize"/> when 
		/// <see cref="Mythic.Package.MythicPackageFile.Compression"/> is set to <see cref="Mythic.Package.CompressionFlag.None"/>.
		/// </summary>
		public int CompressedSize
		{
			get{ return _CompressedSize; }
		}
		#endregion

		#region DecompressedSize
		private int _DecompressedSize;		

		/// <summary>
		/// Size of the decompressed file.
		/// </summary>
		public int DecompressedSize
		{
			get{ return _DecompressedSize; }
		}
		#endregion

		#region FileHash
		private ulong _FileHash;

		/// <summary>
		/// Hash of the <see cref="Mythic.Package.MythicPackageFile.FileName"/>.
		/// </summary>
		public ulong FileHash
		{
			get{ return _FileHash; }
		}
		#endregion

		#region DataBlockHash
		private uint _DataBlockHash;

		/// <summary>
		/// Adler32 hash of the data header in little endian sequence.
		/// </summary>
		public uint DataBlockHash
		{
			get{ return _DataBlockHash; }
		}
		#endregion

		#region Compression
		private CompressionFlag _Compression;

		/// <summary>
		/// Compression type.
		/// </summary>
		public CompressionFlag Compression
		{
			get{ return _Compression; }
		}
		#endregion

		#region FileName
		private string _FileName;

		/// <summary>
		/// Name and relative path of the file.
		/// </summary>
		public string FileName
		{
			get{ return _FileName; }
			set{ _FileName = value; }
		}
		#endregion

		#region SourceFileName
		private string _SourceFileName;
		#endregion

		#region SourceBuffer
		private byte[] _SourceBuffer;
		#endregion

		#region Modified
		private bool _Modified;
		
		/// <summary>
		/// Indicates if this file has been changed (added, removed or changed a file).
		/// </summary>
		public bool Modified
		{
			get{ return _Modified; }
			set
			{ 
				if ( value )
					_Parent.Modified = value;
				
				_Modified = value; 
			}
		}
		#endregion

		#region Added
		private bool _Added;
		
		/// <summary>
		/// Indicates if this is a new file.
		/// </summary>
		public bool Added
		{
			get{ return _Added; }
			set
			{ 
				if ( _Added != value )
				{
					_Parent.Modified = true;
					_Added = value; 
				}
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance from existing Mythic package file.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		/// <param name="parent">Parent entity.</param>
		public MythicPackageFile( BinaryReader reader, MythicPackageBlock parent )
		{
			_Parent = parent;

			_DataBlockAddress = _OldDataBlockAddress = reader.ReadInt64();
			_DataBlockLength = reader.ReadInt32();
			_CompressedSize = reader.ReadInt32();
			_DecompressedSize = reader.ReadInt32();
			_FileHash = reader.ReadUInt64();

			if ( _FileHash != 0 )
				_FileName = HashDictionary.Get( _FileHash, true );

			_DataBlockHash = reader.ReadUInt32();

			short flag = reader.ReadInt16();

			switch ( flag )
			{
				case 0x0: _Compression = CompressionFlag.None; break;
				case 0x1: _Compression = CompressionFlag.Zlib; break;
				default: throw new InvalidCompressionException( flag );
			}
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="fileName">Absolute path to the file on HD.</param>
		/// <param name="innerFolder">Relative folder within KR (destination).</param>
		/// <param name="flag">Compression type.</param>
		public MythicPackageFile( string fileName, string innerFolder, CompressionFlag flag )
		{
			if ( String.IsNullOrEmpty( fileName ) )
				throw new ArgumentException( "fileName" );

			_FileName = Path.Combine( innerFolder, Path.GetFileName( fileName ) ).ToLower();

			if ( _FileName.StartsWith( "\\" ) || _FileName.StartsWith( "/" ) )
				_FileName = _FileName.Substring( 1 );

			_FileName = _FileName.Replace( '\\', '/' );
			_FileHash = HashDictionary.HashFileName( _FileName );
			_SourceFileName = fileName;
			_Compression = flag;
			_DataBlockLength = 0;
			_DataBlockHash = 0;
		}
		#endregion

		#region ToString
		/// <summary>
		/// Returns a <see cref="String"/> that represents this.
		/// </summary>
		/// <returns>Constructed String.</returns>
		public override string ToString()
		{
			string value = String.Empty;

			if ( _FileName != null )
				value = Path.GetFileName( _FileName );
			else
				value = String.Format( "Index_{0}", _Index );
			
			if ( _Added )
				value = String.Format( "+{0}", value );
			else if ( _Modified )
				value = String.Format( "*{0}", value );

			return value;
		}
		#endregion

		#region Search
		/// <summary>
		/// Checks if <see cref="Mythic.Package.MythicPackageFile.FileName"/> or <see cref="Mythic.Package.MythicPackageFile.FileHash"/>
		/// contains <paramref name="keyword"/>.  
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns>If <paramref name="keyword"/> is found.</returns>
		public bool Search( string keyword )
		{
			if ( _FileName != null && _FileName.Contains( keyword ) )
				return true;

			string hash = _FileHash.ToString( "X16" );

			if ( hash.Contains( keyword ) )
				return true;

			return false;
		}

		/// <summary>
		/// Checks if hash of <paramref name="keyword"/> is equal to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.
		/// </summary>
		/// <param name="hash">Hash of the <paramref name="keyword"/></param>
		/// <param name="keyword">Word or a phrase.</param>
		/// <returns>If <paramref name="keyword"/> equals to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.</returns>
		public bool SearchHash( ulong hash, string keyword )
		{
			if ( _FileName == null && _FileHash == hash )
			{
				HashDictionary.Set( hash, keyword );
				_FileName = keyword;
				return true;
			}	
		
			return false;
		}

		/// <summary>
		/// Checks if hash of <paramref name="keyword"/> is equal to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.
		/// </summary>
		/// <param name="hash">Hash of the <paramref name="keyword"/></param>
		/// <param name="keyword">Word or a phrase.</param>
		/// <returns>If <paramref name="keyword"/> equals to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.</returns>
		public bool SearchHash( ulong hash, char[] keyword )
		{
			if ( _FileName == null && _FileHash == hash )
			{
				String name = new String( keyword );
				HashDictionary.Set( hash, name );
				_FileName = name;
				return true;
			}

			return false;
		}
		#endregion

		#region RefreshFileNames
		/// <summary>
		/// Reloads file names from the dictionary.
		/// </summary>
		public void RefreshFileName()
		{
			_FileName = HashDictionary.Get( _FileHash, false );
		}
		#endregion

		#region Replace
		/// <summary>
		/// Replaces this file with another.
		/// </summary>
		/// <param name="fileName">Path to the file on HD.</param>
		/// <param name="packageFolder">Relative folder within KR.</param>
		/// <param name="flag">Compression type.</param>
		public void Replace( string fileName, string packageFolder, CompressionFlag flag )
		{
			_FileName = Path.Combine( packageFolder, Path.GetFileName( fileName ) ).ToLower();
			_FileHash = HashDictionary.HashFileName( _FileName );
			_SourceFileName = fileName;
			_Compression = flag;
			_DataBlockLength = 0;
			_DataBlockHash = 0;

			Modified = true;
		}
		#endregion

		#region Remove
		/// <summary>
		/// Removes this file from <see cref="Mythic.Package.MythicPackageBlock.Files"/> list.
		/// </summary>
		public void Remove()
		{
			_Parent.RemoveFile( _Index );
		}
		#endregion

		#region Save
		/// <summary>
		/// Saves file header to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void Save( BinaryWriter writer )
		{
			writer.Write( _DataBlockAddress );
			writer.Write( _DataBlockLength );
			writer.Write( _CompressedSize );
			writer.Write( _DecompressedSize );
			writer.Write( _FileHash );
			writer.Write( _DataBlockHash );
			writer.Write( (short) _Compression );
		}

		/// <summary>
		/// Saves file data to <paramref name="writer"/>.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void SaveData( BinaryReader reader, BinaryWriter writer )
		{
			if ( _SourceBuffer != null )
			{
				writer.Write( _SourceBuffer, 0, _CompressedSize );
				HashDictionary.Set( _FileHash, _FileName );
			}
			else
			{
				reader.BaseStream.Seek( _OldDataBlockAddress + _DataBlockLength, SeekOrigin.Begin );
				_SourceBuffer = reader.ReadBytes( _CompressedSize );
				writer.Write( _SourceBuffer, 0, _CompressedSize );
			}

			_OldDataBlockAddress = _DataBlockAddress;
			_SourceBuffer = null;
			_Modified = false;
			_Added = false;
		}
		#endregion

		#region UpdateOffsets
		/// <summary>
		/// Updates <see cref="Mythic.Package.MythicPackageFile.DataBlockAddress"/> within .uop file, 
		/// <see cref="Mythic.Package.MythicPackageFile.CompressedSize"/> and <see cref="Mythic.Package.MythicPackageFile.DecompressedSize"/>.
		/// </summary>
		/// <param name="pointer">Address of <see cref="Mythic.Package.MythicPackageFile.DataBlockAddress"/>.</param>
		public void UpdateOffsets( ref long pointer )
		{
			_DataBlockAddress = pointer;
			_DataBlockLength = 0; // Custom .uop files don't need data header.

			if ( _Added || _Modified )
			{
				if ( !File.Exists( _SourceFileName ) )
					throw new FileNotFoundException();

				FileInfo info = new FileInfo( _SourceFileName );

				_CompressedSize = (int) info.Length;
				_DecompressedSize = (int) info.Length;

				byte[] sourceBuffer;

				using ( BinaryReader reader = new BinaryReader( info.OpenRead() ) )
				{
					sourceBuffer = reader.ReadBytes( _DecompressedSize );
				}

				if ( sourceBuffer.Length < 4 )
					_Compression = CompressionFlag.None;

				switch ( _Compression )
				{
					case CompressionFlag.Zlib:
					{
						_SourceBuffer = new byte[ _CompressedSize ];
						Zlib.Compress( _SourceBuffer, ref _CompressedSize, sourceBuffer, _DecompressedSize, CompressionLevel.BestSpeed );

						break;
					}
					case CompressionFlag.None:
					{
						_SourceBuffer = sourceBuffer;
						break;
					}
				}
			}
			else
				_SourceBuffer = null;

			pointer += _DataBlockLength + _CompressedSize;	
		}
		#endregion

		#region Unpack
		/// <summary>
		/// Unpacks this file to <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( string folder, bool fullPath )
		{
			if ( _Parent != null && _Parent.Parent != null )
			{
				using ( FileStream stream = File.OpenRead( _Parent.Parent.FileInfo.FullName ) )
				{
					using ( BinaryReader source = new BinaryReader( stream ) )
						Unpack( source, folder, fullPath );
				}
			}
		}

		/// <summary>
		/// Unpacks this file to <paramref name="folder"/> from <paramref name="source"/>.
		/// </summary>
		/// <param name="source">Binary file (.uop source).</param>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( BinaryReader source, string folder, bool fullPath )
		{
			string fileName = _FileName;

			if ( String.IsNullOrEmpty( fileName ) )
				fileName = String.Format( "{0}_{1}_{2}.bin", _Parent.Parent.FileInfo.Name, _Parent.Index, _Index );
			
			fileName = Path.Combine( folder, fullPath ? fileName : Path.GetFileName( fileName ) );

			string directory = Path.GetDirectoryName( fileName );

			if ( !Directory.Exists( directory ) )
				Directory.CreateDirectory( directory );

			using ( FileStream stream = File.Create( fileName ) )
			{
				using ( BinaryWriter writer = new BinaryWriter( stream ) )
				{
					byte[] data = Unpack( source );

					if ( data != null )
						writer.Write( data, 0, _DecompressedSize );
				}
			}
		}

		/// <summary>
		/// Unpacks this file<paramref name="source"/>.
		/// </summary>
		/// <param name="myp">Path to mythic package.</param>
		/// <returns>Binary data from this file.</returns>
		public byte[] Unpack( string myp )
		{
			using ( FileStream stream = File.OpenRead( myp ) )
			{
				using ( BinaryReader source = new BinaryReader( stream ) )
					return Unpack( source );
			}
		}

		/// <summary>
		/// Unpacks this file<paramref name="source"/>.
		/// </summary>
		/// <param name="source">Binary file (.uop source).</param>
		/// <returns>Binary data from this file.</returns>
		public byte[] Unpack( BinaryReader source )
		{
			source.BaseStream.Seek( _DataBlockAddress + _DataBlockLength, SeekOrigin.Begin );

			byte[] sourceData = new byte[ _CompressedSize ];

			if ( source.Read( sourceData, 0, _CompressedSize ) != _CompressedSize )
				throw new StreamSourceException();

			switch ( _Compression )
			{
				case CompressionFlag.Zlib:
					{
						byte[] destData = new byte[ _DecompressedSize ];
						int destLength = _DecompressedSize;
						Zlib.Decompress( destData, ref destLength, sourceData, _CompressedSize );

						return destData;
					}
				case CompressionFlag.None:
					{
						return sourceData;
					}
			}

			return null;
		}
		#endregion
	}
}
