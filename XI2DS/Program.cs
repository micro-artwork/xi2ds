using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XI2DS
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool excutable;            
            Mutex mutex = new Mutex(true, "XI2DS", out excutable);
            if (excutable)
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    Application.Run(new FormMain());
                }
                catch (Exception e)
                {
                    Application.Exit();
                }
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("XI2DS is running already");
                return;
            }
        }
    }
}
