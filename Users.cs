using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraConsolaCSharp
{
   class Users
    {
        public int[] ID = { 17555325, 8727329, 5602696, };
        public int[] Password = { 2287, 0954, 0760 };
        public int[] SaldoSoles = { 20001, 10001, 5001 };
        public int[] SaldoDolares = { 2000, 600, 140 };


        public int ValidaCedula (int cedula)
        {
            int Respuesta = -1;

            for (int i = 0; i < ID.Length; i++)
            {
                if (ID[i] == cedula) Respuesta = i;  
            }

            return Respuesta;
        }

        public int ValidaPassword (int Clave)
        {
            int Respuesta2 = -1;

            for (int i = 0; i < Password.Length; i++)
            {
                if (Password[i] == Clave) Respuesta2 = i;
            }

            return Respuesta2;
        }


       



    }
}
