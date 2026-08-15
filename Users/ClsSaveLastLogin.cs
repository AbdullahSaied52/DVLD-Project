using Bussiness_Layer;
using DTOUsers_namespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public class ClsSaveLastLogin
    {
        public static void save_to_file(string name, string password)
        {
            string line = name + "/" + password;
            try
            {
                StreamWriter sw = new StreamWriter("login.txt");
                sw.WriteLine(line);
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }

        }

        public static DTOUser read_from_file()
        {
            string line;
            string[] result;
            DTOUser info = new DTOUser();
            try
            {
                StreamReader sr = new StreamReader("login.txt");
                line = sr.ReadLine();
                result = line.Split('/');
                info.name = result[0];
                info.password = result[1];
                info = ClsBussinessUser.get_user_by_username(info.name);
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
            return info;
        }
    }
}
