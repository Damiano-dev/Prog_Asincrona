using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programmazione_asincrona
{
    class Program
    {
        static Thread thread1, thread2;
        static CountdownEvent cte;


        public static void Main()
        {
            int n = 0;
            Object obj = new Object();//l'oggetto deve essere privato altrimente si può usare da altre classi per bloccare altri thread

            //thread1 = new Thread(ThreadProc);
            //thread1.Name = "Thread1";
            //thread1.Start();

            //thread2 = new Thread(ThreadProc);
            //thread2.Name = "Thread2";
            //thread2.Start();
            //thread2.Join(); // il main si blocca per far finire il thread 2, infatti è il main che invoca il join

            for (int i = 0; i < 5; i++)
            {
               
                Thread th = new Thread(() =>
                {
                    #region istruzione Lock
                    ////lock (obj)
                    ////{
                    //    Interlocked.Increment(ref n);
                    ////n = n + 1;
                    //Thread.Sleep(2000);
                    //Thread.CurrentThread.Name = "Thread" + i;
                    //    Console.WriteLine("n={0}, thread={1}",  n, Thread.CurrentThread.Name);

                    ////}
                    #endregion

                });

                th.Start();
            }

            

            Console.ReadLine();
        }

        private static void ThreadProc()
        {
            Console.WriteLine(Thread.CurrentThread.Name);

            // il thread 1 invoca il join del thread 2 e si blocca, il thread due poi invoca il suo stesso thread per bloccarsi, quindi ci vuole un if per bloccare solo il thread che  chiama il join
            //thread2.Join();


            //if (Thread.CurrentThread == thread1)
            //{
            //    if (thread2.Join(10000)) // Per il tempo indicato il thread 2 blocca il thread 1
            //    {
            //        Console.WriteLine("il secondo thread è finito");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Continua il thread 1");
            //    }
            //}


            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(i+ " "+ Thread.CurrentThread.Name);
            //}

        }
    }
}
