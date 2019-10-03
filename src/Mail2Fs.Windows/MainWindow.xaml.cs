using System;
using System.Windows;

namespace Mail2Fs.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool quitting = false;
        System.Windows.Forms.NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();

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
            Closed += MainWindow_Closed;
            Closing += MainWindow_Closing;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            quitting = true;
            Close();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            notifyIcon.Visible = false;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!quitting)
            {
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
                e.Cancel = true;
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            notifyIcon = null;
        }
    }
}
