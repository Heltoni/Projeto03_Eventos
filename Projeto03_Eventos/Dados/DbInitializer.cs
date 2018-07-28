using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto03_Eventos.Dados
{
    public static class DbInitializer
    {

        public static void Initialize(EventosContext context)
        {

            context.Database.EnsureCreated();

        }

    }
}
