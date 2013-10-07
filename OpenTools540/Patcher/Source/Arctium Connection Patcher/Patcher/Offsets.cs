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

namespace Arctium_Connection_Patcher.Patcher
{
    public class Offset
    {
        public enum x86
        {
            Movement     = 0x390E4E,
            Movement2    = 0x390E5F,
            Movement3    = 0x390E6B,
            Movement4    = 0x390E75,
            Legacy       = 0x390E49,
            Email        = 0x655695,
            User         = 0x2461CA
        }

        public enum x64
        {
            Movement     = 0x5A0F0A,
            Movement2    = 0x5A0F19,
            Movement3    = 0x5A0F28,
            Movement4    = 0x5A0F34,
            Legacy       = 0x5A0F03,
            Email        = 0xA644ED,
            User         = 0x3A5430
        }
    }
}
