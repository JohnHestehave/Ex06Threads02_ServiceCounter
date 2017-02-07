using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex06Threads02_ServiceCounter
{
	class Program
	{
		public static Producer Producer;
		public static Consumer Consumer;
		public static Consumer Consumer2;
		public static int MaxCount = 100;
		public static int Count;
		public static List<int> Buffer = new List<int>();
		public static object Lock = new object();
		static void Main(string[] args)
		{
			Producer = new Producer();
			Consumer = new Consumer();
			Consumer2 = new Consumer();
			Thread t1 = new Thread(new ThreadStart(Producer.Start));
			Thread t2 = new Thread(new ThreadStart(Consumer.Start));
			Thread t3 = new Thread(new ThreadStart(Consumer2.Start));
			t1.Start();
			t2.Start();
			t3.Start();
		}
	}
}
