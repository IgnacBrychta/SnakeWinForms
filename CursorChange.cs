using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SnakeWinForms;

internal static class CursorChange
{
	public static bool ChangeCursor(CustomCursor cursor)
	{
		if (cursor.FilePath is null) return false;
		Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors\", cursor.type, cursor.FilePath);
		SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);

		return true;
	}

	const int SPI_SETCURSORS = 0x0057;
	const int SPIF_UPDATEINIFILE = 0x01;
	const int SPIF_SENDCHANGE = 0x02;

	[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
	public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
}

internal abstract class CustomCursor 
{
	[DisallowNull]
	public string? FilePath { get; protected set; }
	[DisallowNull]
	internal string? type;
}

internal class ArrowCursor : CustomCursor
{
	internal ArrowCursor()
	{
		type = "Arrow";
	}

	public bool TrySetCursorFilePath(string path)
	{
		if (!File.Exists(path) || !(path.EndsWith(".cur") || path.EndsWith(".ani"))) return false;

		FilePath = path;
		return true;
	}
}

internal class IBeamCursor : CustomCursor
{
	internal IBeamCursor()
	{
		type = "IBeam";
	}

	public bool TrySetCursorFilePath(string path)
	{
		if (!File.Exists(path) || !(path.EndsWith(".cur") || path.EndsWith(".ani"))) return false;

		FilePath = path;
		return true;
	}
}

internal class WaitCursor : CustomCursor
{
	internal WaitCursor()
	{
		type = "Wait";
	}

	public bool TrySetCursorFilePath(string path)
	{
		if (!File.Exists(path) || !(path.EndsWith(".cur") || path.EndsWith(".ani"))) return false;

		FilePath = path;
		return true;
	}
}

internal class HandCursor : CustomCursor
{
	internal HandCursor()
	{
		type = "Hand";
	}

	public bool TrySetCursorFilePath(string path)
	{
		if (!File.Exists(path) || !(path.EndsWith(".cur") || path.EndsWith(".ani"))) return false;

		FilePath = path;
		return true;
	}
}