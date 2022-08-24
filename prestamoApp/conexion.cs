using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prestamoApp
{
    class conexion
    {
        public MySqlConnection con;

        public conexion()
        {
            string host = "localhost";
            string db = "prestamosdb";
            string port = "3306";
            string user = "root";
            string pass = "Radamanti$";
            string constring = "datasource=" + host +";username= " +  user + ";password=" + pass +";port=" + port + ";database="+ db+";SslMode=none;Convert Zero Datetime=True;maximumpoolsize=50;";
            con = new MySqlConnection(constring);
        }


    }
}
