using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudo_Threads
{
    public partial class Form1 : Form
    {
        private delegate void AtualizarControle(Control controle, string propriedade, object valor);

        Thread t;

        public Form1()
        {
            InitializeComponent();

            t = new Thread(new ThreadStart(Tarefa));
            t.IsBackground = true;  
        }

        private void AtualizarPropriedade(Control controle, string propriedade, object valor)
        {
            if (controle.InvokeRequired)
            {
                AtualizarControle d = new AtualizarControle(AtualizarPropriedade);

                controle.Invoke(d, new object[] { controle, propriedade, valor });
            }
            else
            {
                Type t = controle.GetType();
                PropertyInfo[] prop = t.GetProperties();

                foreach (PropertyInfo pi in prop)
                {
                    if (pi.Name.ToUpper() == propriedade.ToUpper())
                    {
                        pi.SetValue(controle, valor, null);
                    }
                }
            }
        }

        private void Tarefa()
        {
            while (true)
            {
                //lblSegundos.Text = DateTime.Now.ToString();
                AtualizarPropriedade(lblSegundos, "Text", DateTime.Now.Second.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (! t.IsAlive) {
                t.Start();
            } 
        }
    }
}
