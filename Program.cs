using System;
using System.Windows.Forms;
using Controllers;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new LoginTela());
        }
    }
}
