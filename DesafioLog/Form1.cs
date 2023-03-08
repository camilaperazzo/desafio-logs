namespace DesafioLog
{
    public partial class Form1 : Form
    {
        
        
        private bool mStop = false;
        private clLog mLog;
        public Form1()
        {
            InitializeComponent();

            mLog = new clLog();
        }

        
        public  Semaphore pool = new Semaphore(1,2);

        
        private void btnStart_Click(object sender, EventArgs e)
        {
            mLog.freq = int.Parse(txtFreq.Text)*1000;
            
            mStop = false;
            for (int i = 1; i <= int.Parse(txtQnt.Text); i = i + 1)
            {
                Thread newThread = new Thread(new ThreadStart (ordemThread));
                newThread.Start();
            }
            //mLog.WriteLog(txtBox.Text);
        }
        private void ordemThread()
        {

            while (mStop == false)
            {

                //pool.WaitOne();
                mLog.WriteLog(Thread.CurrentThread.ManagedThreadId.ToString() + " Thread started");
               // pool.Release();
                if (Thread.CurrentThread.IsAlive)
                {
                   // pool.WaitOne();
                    mLog.WriteLog(Thread.CurrentThread.ManagedThreadId.ToString() + " Thread working");
                    //Thread.Sleep(1000);
                    //pool.Release();

                    //(1000 * int.Parse(txtFrq.Text));
                }
                //pool.WaitOne();
                mLog.WriteLog(Thread.CurrentThread.ManagedThreadId.ToString() + " Thread ended");
              // pool.Release();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mStop = true;
            Application.Exit();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mStop = true;
        }

        private void txtQnt_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}