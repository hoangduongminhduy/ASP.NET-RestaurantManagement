using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hnminh.demo.csharp{
	public class Student{
		#region Constructor;
		public Student(string name)
		{
			this._name = name;
		}

		//Ham khoi tao noi tiep
		public Student(string name, string age) : this(name)
		{
			this.Age = age;
		}
		#endregion


		#region const, readonly
		public const string SCHOOL_NAME = "Đại học Pách Khoa HN"; //Access directly by class, cannot change
		public readonly string CLASS_NAME = "Lớp CNTT"; //Access by obj, can change value in constructor (equal to const field of obj in java)
		public static string subject = "Lập chình hướng đối tượng"; //Access by class, can change
		#endregion


		#region Fields
		public string _name;
		public int? _age; // ? : assign null neu khong dat, thay vi assign default: 0
		#endregion


		#region Props
		public string FullName
		{
			set { _name = "asfasd"; }
			get { return _name; }
		}
		public string Age
		{
			//shorthand
			set; get;
		}
		#endregion


		#region methods

		/// <summary>
		/// Ham demo generic type
		/// Go 3 dau gach no tu gen ra
		/// </summary>
		/// <typeparam name="T">Kieu du lieu se truyen vao</typeparam>
		/// <param name="obj">Doi tuong se truyen vao</param>
		/// CreatedBy: Hoang Nhat Minh (01/11/2021)
		/// ModifiedBy: Hoang Nhat 
		public void printData<T>(T obj)
		{
			var fields = typeof(T).GetFields();
			foreach(var field in fields)
			{
				var fieldName = field.Name;
				var fieldValue = field.GetValue(obj);
				Console.WriteLine($"{fieldName} = {fieldValue}");
			}
		}
		#endregion
	}
}
