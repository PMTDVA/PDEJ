using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace PDEJ
{
    internal class CheatPattern
    {
		// public static ResourceManager rm = new ResourceManager("Xereca.lang_" + System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());
		public struct ProcessEntry32
		{
			public uint dwSize;

			public uint cntUsage;

			public uint th32ProcessID;

			public IntPtr th32DefaultHeapID;

			public uint th32ModuleID;

			public uint cntThreads;

			public uint th32ParentProcessID;

			public int pcPriClassBase;

			public uint dwFlags;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szExeFile;
		}
		[DllImport("KERNEL32.DLL")]
		public static extern IntPtr CreateToolhelp32Snapshot(uint uint_0, uint uint_1);

		[DllImport("KERNEL32.DLL")]
		public static extern int Process32First(IntPtr intptr_0, ref ProcessEntry32 processEntry32_0);

		[DllImport("KERNEL32.DLL")]
		public static extern int Process32Next(IntPtr intptr_0, ref ProcessEntry32 processEntry32_0);
		public string ToFind;
		public string PatchString;
		public CheatPattern(string a, string b)
		{
			ToFind = a;
			PatchString = b;
		}

		public async Task EnableCheat()
		{
			await DoPatch(ToFind, PatchString);
		}
		public async Task DisableCheat()
		{
			await DoPatch(PatchString, ToFind);
		}
		Mem mem_0 = new Mem();
		public async Task DoPatch(string a, string b)
		{
			DetectEmulator();
			if (mem_0.OpenProcess(Globals.PID))
			{
				IEnumerable<long> enumerable = await mem_0.AoBScan(0L, 140737488355327L, a, writable: true, executable: true, string.Empty);

				foreach (long item in enumerable)
				{

					mem_0.ChangeProtection("0x" + item.ToString("X"), Mem.MemoryProtection.ReadWrite, out Mem.MemoryProtection oldprot);
					mem_0.WriteMemory(item.ToString("X"), "bytes", b, string.Empty);
					mem_0.ChangeProtection("0x" + item.ToString("X"), oldprot, out var _);
				}

				mem_0.CloseProcess();
			}

		}
		private static void DetectEmulator()
		{
			IntPtr intPtr = IntPtr.Zero;
			uint num = 0u;
			IntPtr intPtr2 = CreateToolhelp32Snapshot(2u, 0u);
			if ((int)intPtr2 > 0)
			{
				ProcessEntry32 processEntry32_ = default(ProcessEntry32);
				processEntry32_.dwSize = (uint)Marshal.SizeOf(processEntry32_);
				for (int num2 = Process32First(intPtr2, ref processEntry32_); num2 == 1; num2 = Process32Next(intPtr2, ref processEntry32_))
				{
					IntPtr intPtr3 = Marshal.AllocHGlobal((int)processEntry32_.dwSize);
					Marshal.StructureToPtr(processEntry32_, intPtr3, fDeleteOld: true);
					ProcessEntry32 processEntry = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
					Marshal.FreeHGlobal(intPtr3);
					
					
					if (processEntry.szExeFile.Contains("LdVBoxHeadless.exe") && processEntry.cntThreads > num)
					{
						num = processEntry.cntThreads;
						intPtr = (IntPtr)processEntry.th32ProcessID;
						Globals.ProcessEmulator = "LdVBoxHeadless.exe"; // blue
						Globals.IntCode = 140737488355327L;
					}
				
				}
				Globals.PID = (int)intPtr;
			}
		}
	}
}
