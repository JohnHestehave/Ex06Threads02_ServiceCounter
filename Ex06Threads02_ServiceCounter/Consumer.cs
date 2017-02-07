using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex06Threads02_ServiceCounter
{
	class Consumer
	{
		int ClerkID;
		static int ClerkNum;
		bool running = false;
		public void Start()
		{
			ClerkID = ++ClerkNum;
			int Item;
			running = true;
			int sleeptime = 10;
			while (running)
			{
				Thread.Sleep(sleeptime);
				lock (Program.Lock)
				{
					if (Program.Count > 0)
					{
						Item = RemoveItem();
						Program.Count--;
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Clerk "+ClerkID+" Now handling: " + Item);
						sleeptime = 5000;
					}
					else
					{
						sleeptime = 10;
					}
				}
			}
		}
		public void Stop()
		{
			running = false;
		}
		int RemoveItem()
		{
			int item = Program.Buffer[0];
			Program.Buffer.RemoveAt(0);
			return item;
		}
	}
}
