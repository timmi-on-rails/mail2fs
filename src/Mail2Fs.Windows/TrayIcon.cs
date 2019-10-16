using System;
using System.Windows;

namespace Mail2Fs.Windows
{
    class TrayIcon
    {
        private bool quitting = false;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private Window window;

        private TrayIcon(Window window)
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.BalloonTipText = "mail2fs has been minimised. Click the tray icon to show.";
            notifyIcon.BalloonTipTitle = "mail2fs";
            notifyIcon.Text = "mail2fs";
            notifyIcon.Icon = Mail2FsResources.icon;

            var menuItem = new System.Windows.Forms.MenuItem
            {
                Text = "Quit",
            };
            menuItem.Click += MenuItem_Click;
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(new[] {
                menuItem
            });

            notifyIcon.Click += NotifyIcon_Click;

            this.window = window;
            window.Closed += Window_Closed;
            window.Closing += Window_Closing;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            quitting = true;
            window.Close();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            window.Show();
            notifyIcon.Visible = false;
        }

        public static void Setup(Window window)
        {
            TrayIcon trayIcon = new TrayIcon(window);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!quitting)
            {
                window.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
                e.Cancel = true;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            notifyIcon = null;
        }
    }
}
