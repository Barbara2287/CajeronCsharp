using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraConsolaCSharp
{
    class Options
    {
        int SelectUser;
        int LimitWithDraw = 1000;
        Users Us = new Users();



        public void UsersOptions(int Vali1)
        {
            do
            {
                Titulo();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Selecciona una opción y dale Enter \n");
                Console.WriteLine("1.- Consulta de saldo.");
                Console.WriteLine("2.- Retiro.");
                Console.WriteLine("3.- Transferencia.");
                Console.WriteLine("4.- Depósito de efectivo.");
                Console.WriteLine("5.- Salir.\n");
                Console.ForegroundColor = ConsoleColor.White;
                SelectUser = Convert.ToInt32(Console.ReadLine());

                switch (SelectUser)
                {

                    case 1:
                        Console.Clear();
                        ConSaldo(Vali1);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        //OptionsUsers(Vali1);
                        break;

                    case 2:
                        Console.Clear();
                        Retiro(Vali1);
                        break;


                    case 3:
                        Console.Clear();
                        Transf(Vali1);
                        break;


                    case 4:
                        Console.Clear();
                        Deposito(Vali1);
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opción NO Válida");
                        break;
                }
            } while (SelectUser != 5);

        }


        public void ConSaldo (int Vali1)
        {
            Titulo ();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Opción. ---------> CONSULTA DE SALDO\n");
            Console.WriteLine($"Su saldo es ${Us.Saldo[Vali1]} \n");
        }

        private void Retiro (int Vali1)
        {      

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opción 2. ---------> RETIROS \n");
            Console.WriteLine("Introduce el monto a retirar \n");

            int CantRetiro = Convert.ToInt32 (Console.ReadLine());
            

            if (CantRetiro < Us.Saldo[Vali1] && CantRetiro < LimitWithDraw)
            {

                Us.Saldo [Vali1] -= CantRetiro;
                Console.WriteLine("Por favor retire su dinero, monto es Soles: "+ CantRetiro);
                Console.WriteLine("Su saldo actual es: "+ Us.Saldo[Vali1]);

            }

            else if(CantRetiro > Us.Saldo[Vali1])
            {
                Console.WriteLine("Saldo insuficiente");
            }
            else Console.WriteLine("Monto supera el límite, por favor introduce un monto menor");

        }

        private void Transf(int Vali1)
        {

            // FALTA SUMAR LAS CANTIDADES TRANSFERIDAS A TERCEROS
            Titulo();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Digite la cédula del titular de la cuenta a quien va a trnasferrir");
            int TransfUno = Convert.ToInt32 (Console.ReadLine());
            int CtaExiste = Us.ValidaCedula(TransfUno);

            if (CtaExiste != -1)
            {
                Console.WriteLine("Usuario Válido");

                Console.WriteLine("Introduce el monto a transferir");

                int CantTransf = Convert.ToInt32(Console.ReadLine());

                if (CantTransf <= Us.Saldo[Vali1] && CantTransf <= LimitWithDraw)
                {
                    Us.Saldo[Vali1] -= CantTransf;
                    Console.WriteLine("El monto transferido a la cuenta: " + CantTransf);
                    Console.WriteLine("Su saldo actual es: " + Us.Saldo[Vali1]);
                }
                else Console.WriteLine("Saldo insuficiente");

            }
            else Console.WriteLine("La cuenta no existe");
             }



        private void Deposito (int Vali1)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Opción 4. ---------> DEPÓSITOS EN EFECTIVO \n");
            Console.WriteLine("Introduce el monto a depositar \n");

            int CantDeposito = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ha introducido " + CantDeposito + "Es correcto? Presione enter");

            Us.Saldo[Vali1] += CantDeposito;

            Console.WriteLine("Se ha realizado el depósito con éxito su saldo es: " + Us.Saldo[Vali1] + "Retire du voucher");
    }


        public void Titulo()
            {

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*********************************************");
                Console.WriteLine("************** CAJERO AUTOMATICO ***********");
                Console.WriteLine("********************************************");

            }







        }
    }

