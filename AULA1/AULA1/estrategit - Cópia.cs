using System;


namespace AULA1
{
     class estrategitcopia
     {
        static void temp()
        {
            /**
            if () { }
            else if { }
            else { }
            */
            string tecla;
            do
            {
                tecla = Console.ReadLine();

                switch (tecla)
                {
                    case "a":
                        Console.WriteLine("Pra tras");
                        break;
                    case "w":
                        Console.WriteLine("Pra cima");
                        break;
                    case "s":
                        Console.WriteLine("Pra baixo");
                        break;
                    case "d":
                        Console.WriteLine("Pra frente");
                        break;
                }
            } while (tecla != "x");
        }
     }
}
