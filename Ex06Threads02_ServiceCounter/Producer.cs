using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex06Threads02_ServiceCounter
{
	class Producer
	{
		bool running = false;
		int inc;
		public void Start()
		{
			int Item;
			running = true;
			while (running)
			{
				Thread.Sleep(2000);
				lock (Program.Lock)
				{
					Item = ProduceItem();
					if (Program.Count < Program.MaxCount)
					{
						Program.Buffer.Add(Item);
						Program.Count++;
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine("The next number to be picked: "+Item);
					}
				}
			}
		}
		public void Stop()
		{
			running = false;
		}
		int ProduceItem()
		{
			inc++;
			return inc;
		}
	}
}
