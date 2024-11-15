using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad03
{
    class Program
    {
        //3.0
        static void Foo(Person person)
        {
            person.firstName = "Bogdan";
            person.lastName = "Kowalski";
        }
        static void Bar(Person person)
        {
            person = new Person("Zygmunt", "Kowal");
        }
        static void Baz(Person person)
        {
            person = null;
        }

        static void Main(string[] args)
        {
            //3.0
            Person p = new("Jan", "Nowak");
            Console.WriteLine(p.firstName + " " + p.lastName);
            Foo(p);
            Console.WriteLine(p.firstName + " " + p.lastName);
            Bar(p);
            Console.WriteLine(p.firstName + " " + p.lastName);
            Baz(p);
            Console.WriteLine(p.firstName + " " + p.lastName);

            //3.1
            //Poprawna enkapsulacja, przykladowo prywatne pola firstName, lastName

            //3.2 -> Queue
            //3.3
            //najlepiej klasa generyczna, ale jesli ma moc przechowywac wszystkie objekty to np. w przypadku dziedziczenia Queue : List<Object>

            //3.4 -> Complex
            //3.5 -> Matrix
            //3.5 -> Complex
            Complex<int> val = new(2, 1);
            Complex<int>[,] arr = { { val, val }, { val, val } };
            Complex<int>[,] diag = { { val, new(0, 0) }, { new(0, 0), val } };

            Matrix<Complex<int>> matrix = new(arr);

            Console.WriteLine(val);
            Console.WriteLine(matrix);
            Console.WriteLine(matrix + matrix);

            SquareMatrix<Complex<int>> sqM = new(diag);
            Console.WriteLine(sqM);
            Console.WriteLine(sqM.IsDiagonal());
        }
    }

}
