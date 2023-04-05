using System;
//using System.Reflection;

namespace Reflection_Demo
{

   
        public delegate void RectangleDelegate(double Width, double Height);
        public class Rectangle
        {
            public void GetArea(double Width, double Height)
            {
                Console.WriteLine($"Area is {Width * Height}");
            }
            public void GetPerimeter(double Width, double Height)
            {
                Console.WriteLine($"Perimeter is {2 * (Width + Height)}");
            }
            static void Main(string[] args)
            {
                Rectangle rect = new Rectangle();
                RectangleDelegate rectDelegate = new RectangleDelegate(rect.GetArea);
             
                rectDelegate += rect.GetPerimeter;

                Delegate[] InvocationList = rectDelegate.GetInvocationList();//will show all the functionw lined up
                Console.WriteLine("InvocationList:");
                foreach (var item in InvocationList)
                {
                    Console.WriteLine($"  {item}");
                }

                Console.WriteLine();
                Console.WriteLine("Invoking Multicast Delegate:");
                rectDelegate(23.45, 67.89);
                //rectDelegate.Invoke(13.45, 76.89);

                Console.WriteLine();
                Console.WriteLine("Invoking Multicast Delegate After Removing one Pipeline:");
                //Removing a method from delegate object
                rectDelegate -= rect.GetPerimeter;//removing function
                rectDelegate.Invoke(13.45, 76.89);

              
            Console.WriteLine("Reflection example");
            Type t = typeof(string);//saving type
            int a = 6;
            Console.WriteLine("Name : {0}", t.Name);
            Console.WriteLine("Full Name : {0}", t.FullName);
            Console.WriteLine("Namespace : {0}", t.Namespace);
            Console.WriteLine("Base Type : {0}", t.BaseType);
            Console.WriteLine(t.Assembly);//reflection

            Console.WriteLine("s3econd example for multicast delegate");

            Program p = new Program();
            
            MathDelegate del1 = new MathDelegate(Program.Add);
            MathDelegate del2 = new MathDelegate(Program.Sub);
            //Non-Static Method must be access through object 
            MathDelegate del3 = new MathDelegate(p.Mul);
            MathDelegate del4 = new MathDelegate(p.Div); ;
            
            MathDelegate del5 = del1 + del2 + del3 + del4;

            Delegate[] InvocationList1 = del5.GetInvocationList();
            Console.WriteLine("InvocationList:");
            foreach (var item in InvocationList1)
            {
                Console.WriteLine($" {item}");
            }
            Console.WriteLine();

            Console.WriteLine("Invoking Multicast Delegate::");
            del5.Invoke(20, 5);
            Console.WriteLine();

            Console.WriteLine("Invoking Multicast Delegate After Removing one Delegate:");
            del5 -= del2;
            del5(22, 7);
            Console.WriteLine("cloning example");
            string[] arr = { "one", "two", "three", "four", "five" };
            string[] arrCloned = arr.Clone() as string[];

            Console.WriteLine(string.Join(",", arr));
            Console.WriteLine(string.Join(",", arrCloned));
            Console.WriteLine();

            Console.ReadKey();

        }
    }
    
        public delegate void MathDelegate(int No1, int No2);

        public class Program
        {
            //Static Method
            public static void Add(int x, int y)
            {
                Console.WriteLine($"Addition of {x} and {y} is : {x + y}");
            }
            //Static Method
            public static void Sub(int x, int y)
            {
                Console.WriteLine($"Subtraction of {x} and {y} is : {x - y}");
            }
            //Non-Static Method
            public void Mul(int x, int y)
            {
                Console.WriteLine($"Multiplication of {x} and {y} is : {x * y}");
            }
            //Non-Static Method
            public void Div(int x, int y)
            {
                Console.WriteLine($"Division of {x} and {y} is : {x / y}");
            }

            
        }
    }



