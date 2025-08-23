using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applogin
{
    internal class Cliente
    {
        private int cli_id;
        private string cli_nombre;
        private int cli_edad;
        private string cli_email;

        public Cliente()
        {
        }

        public Cliente(int cli_id, string cli_nombre, int cli_edad, string cli_email)
        {
            this.cli_id = cli_id;
            this.cli_nombre = cli_nombre;
            this.cli_edad = cli_edad;
            this.cli_email = cli_email;
        }

        public int Cli_id { get => cli_id; set => cli_id = value; }
        public string Cli_nombre { get => cli_nombre; set => cli_nombre = value; }
        public int Cli_edad { get => cli_edad; set => cli_edad = value; }
        public string Cli_email { get => cli_email; set => cli_email = value; }
    }
}
