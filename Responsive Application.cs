using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace WindowsFormsAsync
{
    public partial class Form1 : Form
    {
        private readonly SynchronizationContext synchronizationContext;
        private DateTime previousTime = DateTime.Now;
 
        public Form1()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
        }
 
        private async void ButtonClickHandlerAsync(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var count = 0;
 
            await Task.Run(() =>
            {
                for (var i = 0; i <= 5000000; i++)
                {
                    UpdateUI(i);
                    count = i;
                }
            });
 
            label1.Text = @"Counter " + count;
            button1.Enabled = true;
        }
 
        public void UpdateUI(int value)
        {
            var timeNow = DateTime.Now;
 
            if ((DateTime.Now - previousTime).Milliseconds <= 50) return;
 
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                label1.Text = @"Counter " + (int)o;
            }), value);             
 
            previousTime = timeNow;
        }
    }
}
