using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    internal class Program
    {
       
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
            public int StandardID { get; set; }
        }
        public class Standard
        {
            public int StandardID { get; set; }
            public string StandardName { get; set; }
         
        }
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
};
            IList<Standard> standardList = new List<Standard>() {
    new Standard(){ StandardID = 1, StandardName="Standard 1"},
    new Standard(){ StandardID = 2, StandardName="Standard 2"},
    new Standard(){ StandardID = 3, StandardName="Standard 3"}
};
            LINQ1(studentList);
            //LINQWhere(studentList);
            //LINQLamda(studentList);
            //JoinTest(studentList, standardList);
            Console.Read();
        }
        static void LINQLamda(IList<Student> studentList)
        {
            var condition = studentList.Where(x=>x.StandardID == 1);
            foreach (Student student in condition)
            {
                Console.WriteLine(student.StudentName);
            }
        }
        static void JoinTest(IList<Student> studentList, IList<Standard> standardList)
        {
            var innerJoin = studentList.Join(// outer sequence 
                       standardList,  // inner sequence 
                       student => student.StandardID,    // outerKeySelector
                       standard => standard.StandardID,  // innerKeySelector
                       (student, standard) => new  // result selector
                       {
                           StudentName = student.StudentName,
                           StandardName = standard.StandardName
                       });
            foreach (var student in innerJoin)
            {
                Console.WriteLine(student.StudentName + student.StandardName);
            }
        }
        static void LINQWhere(IList<Student> studentList)
        {
            var condition = from s1 in studentList
                            where s1.StudentID == 1
                            select s1;
            foreach (Student student in condition)
            {
                Console.WriteLine(student.StudentName);
            }
        }
        static void LINQ1(IList<Student> studentList)
        {
            // all student name
            var s=studentList.ToList().OrderBy(x=>x.StudentName);
          
            foreach (Student student in s)
            {
                Console.WriteLine(student.StudentName);
            }
        }
    }
}
