/*
 * Copyright (C) 2012-2013 Arctium <http://arctium.org>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Windows.Controls;

namespace Arctium_Connection_Patcher.Patcher
{
    public class Patcher
    {
        public static bool Initialized { get; set; }
        public static bool Is64Bit { get; set; }

        static string WoWBinary;

        public static void Initialize(ref TextBlock stateBlock)
        {
            Initialized = false;
            Is64Bit = false;

            var filedialog = new OpenFileDialog();
            filedialog.DefaultExt = ".exe";
            filedialog.Filter = "Executables (.exe)|*.exe";

            if (filedialog.ShowDialog() == true)
            {
                WoWBinary = filedialog.FileName.Replace(".exe", "") + "_Patched.exe";

                // Make copy of original file for patching
                File.Copy(filedialog.FileName, WoWBinary, true);
                stateBlock.Text = "Ready!\n";

                Initialized = true;
            };
        }

        public static void Patch(Int32 offset, byte[] pBytes, ref TextBlock stateBlock)
        {
            Thread.Sleep(100);

            using (var wowReader = new BinaryReader(File.Open(WoWBinary, FileMode.Open, FileAccess.Read)))
            {
                wowReader.BaseStream.Seek(offset, SeekOrigin.Begin);

                if (wowReader.ReadByte() == pBytes[0])
                    stateBlock.Text += string.Format("0x{0:X} already patched.\n", offset);
                else
                {
                    wowReader.Close();

                    using (var wowWriter = new BinaryWriter(File.Open(WoWBinary, FileMode.Open, FileAccess.ReadWrite)))
                    {
                        try
                        {
                            wowWriter.BaseStream.Seek((int)offset, SeekOrigin.Begin);
                            wowWriter.Write(pBytes);

                            stateBlock.Text += string.Format("0x{0:X} patched.\n", offset);
                        }
                        catch (Exception ex)
                        {
                            stateBlock.Text = string.Format("{0}\nStop patching!!!", ex.Message.ToString());
                        }
                    }
                }
            }
        }

        public static void Dispose()
        {
            Initialized = false;
            Is64Bit = false;
            WoWBinary = "";
        }
    }
}
