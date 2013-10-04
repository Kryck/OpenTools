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

using System.Windows;
using System.Windows.Input;

namespace Arctium_Connection_Patcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Point CurrentPosition;

        /// <summary>
        /// MouseMove event.
        /// Gets the new mouse position and handles the window movement.
        /// </summary>
        void SetNewWindowPosition(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var newPos = e.GetPosition(this);

                Left -= CurrentPosition.X - newPos.X;
                Top -= CurrentPosition.Y - newPos.Y;
            }
        }

        /// <summary>
        /// MouseDown event.
        /// Gets the current mouse position on left mouse button click.
        /// </summary>
        void SetCurrentMousePosition(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                CurrentPosition = e.GetPosition(this);
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            Patcher.Patcher.Initialize(ref StateBox);
            Patcher.Patcher.Is64Bit = false;

            if (Patcher.Patcher.Initialized)
            {
                NoteText.Content = "Click on Arctium logo to start the patching process :)";
                NoteText.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            Patcher.Patcher.Initialize(ref StateBox);
            Patcher.Patcher.Is64Bit = true;

            if (Patcher.Patcher.Initialized)
            {
                NoteText.Content = "Click on Arctium logo to start the patching process :)";
                NoteText.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            if (Patcher.Patcher.Initialized)
            {
                NoteText.Content = "Patching in progress...";

                if (Patcher.Patcher.Is64Bit)
                {
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.Movement, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.Movement2, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.Movement3, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.Movement4, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.Legacy, Patcher.Bytes.Legacy, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.Email, Patcher.Bytes.Email, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x64.User, Patcher.Bytes.User, ref StateBox);
                }
                else
                {
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.Movement, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.Movement2, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.Movement3, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.Movement4, Patcher.Bytes.Movement, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.Legacy, Patcher.Bytes.Legacy, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.Email, Patcher.Bytes.Email, ref StateBox);
                    Patcher.Patcher.Patch((int)Patcher.Offset.x86.User, Patcher.Bytes.User, ref StateBox);
                }

                Patcher.Patcher.Dispose();
            }

            NoteText.Content = "Patching done!";
        }
    }
}
