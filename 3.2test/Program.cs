using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._9assignment
{
    class Human
    {
        public string Name;
        public string Sex;
        public int Age;
        public int Stature;//身高
        public int Avoird;//体重
    }
    class Student : Human
    {
        public int Class;
        public int Score;

        public string judge()
        {
            if (((Age >= 16 && Age <= 20) && Score >= 480) || ((Age >= 20 && Age <= 30) && Score >= 450))
            {
                return "该学生成绩合格";
            }
            else
            {
                return "该学生成绩不合格";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Stu1 = new Student();
            Console.WriteLine("请输入学生的名字");
            Stu1.Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("请输入该学生的年龄");
            Stu1.Age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("请输入该学生的总分");
            Stu1.Score = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(Convert.ToString(Stu1.judge()));

            //Student[] Stu = new Student[10];
        }
    }
}
