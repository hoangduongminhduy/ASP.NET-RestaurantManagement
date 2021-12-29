using System;

namespace hnminh.demo.csharp{
	class Program{
		static void xyz(string[] args){
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Student s = new Student("Minh");
			s._name = "Meo"; // this uses setter
							 //Console.WriteLine($"{s._name}");
			s.printData<Student>(s);
		}
	}
}
