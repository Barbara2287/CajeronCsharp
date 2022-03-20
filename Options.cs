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
        int LimitWithDrawSol = 1000;
        int LimitWithDrawUSD = 200;
        int Moneda;
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


        public void ConSaldo(int Vali1)
        {
            Titulo();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Opción. ---------> CONSULTA DE SALDO\n");
            Console.WriteLine("Elige Soles o Dólares \n");
            Console.WriteLine("1.- Soles.");
            Console.WriteLine("2.- Dólares.");
            Moneda = Convert.ToInt32(Console.ReadLine());

            switch (Moneda)
            {
                case 1:
                    Console.WriteLine($"Su saldo es S/{Us.SaldoSoles[Vali1]} \n");
                    break;

                case 2:

                    Console.WriteLine($"Su saldo es USD {Us.SaldoDolares[Vali1]} \n");
                    break;

            }


        }

        private void Retiro(int Vali1)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opción 2. ---------> RETIROS \n");
            Console.WriteLine("Elige Retiro Soles o Retiro Dólares \n");
            Console.WriteLine("1.- Soles.");
            Console.WriteLine("2.- Dólares.");
            Moneda = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduce el monto a retirar \n");

            int CantRetiro = Convert.ToInt32(Console.ReadLine());

            switch (Moneda)
            {
                case 1:

                    if (CantRetiro < Us.SaldoSoles[Vali1] && CantRetiro < LimitWithDrawSol)
                    {

                        Us.SaldoSoles[Vali1] -= CantRetiro;
                        Console.WriteLine("Por favor retire su dinero, monto es Soles: " + CantRetiro);
                        Console.WriteLine("Su saldo actual es: S/" + Us.SaldoSoles[Vali1]);

                    }

                    else if (CantRetiro > Us.SaldoSoles[Vali1])
                    {
                        Console.WriteLine("Saldo insuficiente");
                    }
                    else Console.WriteLine("Monto supera el límite, por favor introduce un monto menor");
                    break;

                case 2:


                    if (CantRetiro < Us.SaldoDolares[Vali1] && CantRetiro < LimitWithDrawUSD)
                    {

                        Us.SaldoDolares[Vali1] -= CantRetiro;
                        Console.WriteLine("Por favor retire su dinero, monto es Dólares: " + CantRetiro);
                        Console.WriteLine("Su saldo actual es: USD" + Us.SaldoDolares[Vali1]);

                    }

                    else if (CantRetiro > Us.SaldoDolares[Vali1])
                    {
                        Console.WriteLine("Saldo insuficiente");
                    }
                    else Console.WriteLine("Monto supera el límite, por favor introduce un monto menor");
                    break;

            }

        }

        private void Transf(int Vali1)
        {

            
            Titulo();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Digite la cédula del titular de la cuenta a quien va a transferir");
            int TransfUno = Convert.ToInt32(Console.ReadLine());
            int CtaExiste = Us.ValidaCedula(TransfUno);

            if (CtaExiste != -1)
            {
                Console.WriteLine("Usuario Válido \n");
                Console.Clear();
                Console.WriteLine("Elige Transferir Soles o Transferir Dólares \n");
                Console.WriteLine("1.- Soles.");
                Console.WriteLine("2.- Dólares.");
                Moneda = Convert.ToInt32(Console.ReadLine());

               
                switch (Moneda)
                {

                    case 1:
                        Console.WriteLine("Introduce el monto a transferir En Soles");
                        int CantTransf = Convert.ToInt32(Console.ReadLine());

                        if (CantTransf <= Us.SaldoSoles[Vali1] && CantTransf <= LimitWithDrawSol)
                        {
                            Us.SaldoSoles[Vali1] -= CantTransf;
                            Console.WriteLine("El monto transferido es S/ : " + CantTransf);
                            Console.WriteLine("Su saldo actual es S/ : " + Us.SaldoSoles[Vali1]);
                        }
                        else { Console.WriteLine("Saldo insuficiente"); }
                        break;

                    case 2:
                        Console.WriteLine("Introduce el monto a transferir en Dólares");
                        int CantTransf2 = Convert.ToInt32(Console.ReadLine());

                        if (CantTransf2 <= Us.SaldoDolares[Vali1] && CantTransf2 <= LimitWithDrawUSD)
                        {
                            Us.SaldoDolares[Vali1] -= CantTransf2;
                            Console.WriteLine("El monto transferido es USD : " + CantTransf2);
                            Console.WriteLine("Su saldo actual es USD : " + Us.SaldoDolares[Vali1]);
                        }
                        else { Console.WriteLine("Saldo insuficiente"); }
                        break;


                }
            }
            else Console.WriteLine("La cuenta no existe");
    
                
        

    }



        private void Deposito(int Vali1)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Opción 4. ---------> DEPÓSITOS EN EFECTIVO \n");
            Console.WriteLine("Elige Transferir Soles o Transferir Dólares \n");
            Console.WriteLine("1.- Soles.");
            Console.WriteLine("2.- Dólares.");
            Moneda = Convert.ToInt32(Console.ReadLine());

            switch (Moneda)
            {

                case 1:
                    Console.WriteLine("Introduce el monto a depositar \n");
                    int CantDeposito = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ha introducido " + CantDeposito + "¿Es correcto? Si es correcto, Presione enter");
                    Us.SaldoSoles[Vali1] += CantDeposito;
                    Console.WriteLine("Se ha realizado el depósito con éxito su saldo es S/ : " + Us.SaldoSoles[Vali1] + "Retire su voucher");
                    break;

                case 2:
                    Console.WriteLine("Introduce el monto a depositar \n");
                    int CantDepositoUSD = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ha introducido " + CantDepositoUSD + "¿Es correcto? Si es correcto, Presione enter");
                    Us.SaldoDolares[Vali1] += CantDepositoUSD;
                    Console.WriteLine("Se ha realizado el depósito con éxito su saldo es S/ : " + Us.SaldoDolares[Vali1] + "Retire su voucher");
                    break;


            }
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



