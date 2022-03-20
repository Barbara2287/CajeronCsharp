namespace CalculadoraConsolaCSharp {

    class Program {

        static void Main(string[] args)
        {


            //Variables e instancias de clases

            int Cedula;
            int Clave;

            Options Opt = new Options();

            Users users = new Users();

            int Vali1 = -1;

            int Vali2 = -1;



            // cédula usuario

            Opt.Titulo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite su Cécula");
           
            Cedula = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            //clave usuario
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite su clave, por favor"); 
            Clave = Convert.ToInt32(Console.ReadLine());

            Vali1 = users.ValidaCedula(Cedula);

            Vali2 = users.ValidaPassword(Clave);


            //validación

            if (Vali1 != -1 && Vali2 != -1 && Vali1== Vali2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Usuario Válido \n");
                Opt.UsersOptions(Vali1);

            }
            else { Console.WriteLine("Usuario o Clave Incorrectos, por favor intenta nuevamente"); }


        }

        }
}


