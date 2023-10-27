using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadPriority
{
    public partial class frmTrackThread : Form
    {
        public frmTrackThread()
        {
            InitializeComponent();
        }

        private void frmTrackThread_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Console.WriteLine(lblThreadStart.Text);

            ThreadStart delThread = new ThreadStart(MyThreadClass.Thread1);
            ThreadStart delStart = new ThreadStart(MyThreadClass.Thread2); 

            Thread ThreadA = new Thread(delThread);
            Thread ThreadB = new Thread(delStart);
            Thread ThreadC = new Thread(delThread);
            Thread ThreadD = new Thread(delStart);


            ThreadA.Priority = System.Threading.ThreadPriority.Highest;
            ThreadB.Priority = System.Threading.ThreadPriority.Normal;
            ThreadC.Priority = System.Threading.ThreadPriority.AboveNormal;
            ThreadD.Priority = System.Threading.ThreadPriority.BelowNormal;

            ThreadA.Name = "Thread A Process";
            ThreadB.Name = "Thread B Process";
            ThreadC.Name = "Thread C Process";
            ThreadD.Name = "Thread D Process";


            ThreadA.Start();
            ThreadB.Start();
            ThreadC.Start();
            ThreadD.Start();

            ThreadA.Join();
            ThreadB.Join();
            ThreadC.Join();
            ThreadD.Join();

            lblThreadStart.Text = "-End of thread-";
            Console.WriteLine(lblThreadStart.Text);
        }
    }
}
