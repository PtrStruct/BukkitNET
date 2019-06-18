using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WIPtoMRBTransfer.Data
{
	[Serializable]
	public class SettingsData
	{
		private static SettingsData instance;
		public static SettingsData Instance => instance ?? (instance = LoadFromBinaryStream());
		public static DirectoryInfo DataStorageDirectory =
			new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\BukkitNET\UserConfig\" +
				System.Reflection.Assembly.GetEntryAssembly() .GetName().Name);

		public static FileInfo DataStorageFile = new FileInfo(DataStorageDirectory.FullName + @"\Servers.bin");

		private SettingsData() { }

		private string username = "";
		public string Username
		{
			get { return Instance.username; }
			set
			{
				Instance.username = value;
				SaveToBinaryStream();
			}
		}

		private string password = "";
		public string Password
		{
			get { return Instance.password; }
			set
			{
				Instance.password = value;
				SaveToBinaryStream();
			}
		}
		private string url = "";
		public string URL
		{
			get { return Instance.url; }
			set
			{
				Instance.url = value;
				SaveToBinaryStream();
			}
		}
		private int port = 22;
		public int Port
		{
			get { return Instance.port; }
			set
			{
				Instance.port = value;
				SaveToBinaryStream();
			}
		}
		public void SaveToBinaryStream()
		{
			IFormatter formatter = new BinaryFormatter();
			if (!DataStorageDirectory.Exists) DataStorageDirectory.Create();
			Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, this);
			stream.Close();
		}
		private static SettingsData LoadFromBinaryStream()
		{
			if (!DataStorageFile.Exists)
				return new SettingsData();
			try
			{
				IFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(DataStorageFile.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				var obj = (SettingsData)formatter.Deserialize(stream);
				stream.Close();
				return obj;
			}
			catch
			{
				return new SettingsData();
			}
		}
	}
}
