using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWinForms;

internal static class CursorChange
{
	public static void ChangeCursor(string curFile, CustomCursor cursor)
	{
		Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors\", cursor.FilePath, curFile);
		SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
	}

	const int SPI_SETCURSORS = 0x0057;
	const int SPIF_UPDATEINIFILE = 0x01;
	const int SPIF_SENDCHANGE = 0x02;

	[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
	public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
}

public interface ICursorFileTypeANI 
{
	public bool TrySetCursorFilePath(string path);
}
public interface ICursorFileTypeCUR
{
	public bool TrySetCursorFilePath(string path);
}

internal abstract class CustomCursor 
{
	[DisallowNull]
	public string? FilePath { get; protected set; }
}

internal class Arrow : CustomCursor, ICursorFileTypeCUR
{
	public bool TrySetCursorFilePath(string path)
	{
		throw new NotImplementedException();
	}
}

internal class IBeam : CustomCursor, ICursorFileTypeCUR
{
	public bool TrySetCursorFilePath(string path)
	{
		throw new NotImplementedException();
	}
}

internal class Wait : CustomCursor, ICursorFileTypeANI
{
	public bool TrySetCursorFilePath(string path)
	{
		throw new NotImplementedException();
	}
}