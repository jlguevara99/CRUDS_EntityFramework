   using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prueba.Modelos;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        #region HELPER
        private void Actualizar()
        {
            using (SupermercadoEntity db = new SupermercadoEntity())
            {
                var lista = from d in db.Productos
                            select d;
                dataGridView1.DataSource = lista.ToList();
            }
        }

        private int? GetID()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        #endregion





        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentacion.Agregar vAgregar = new Presentacion.Agregar();
            vAgregar.ShowDialog();
            Actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetID();
            if(id != null)
            {
                Presentacion.Agregar vAgregar = new Presentacion.Agregar(id);
                vAgregar.ShowDialog();

                Actualizar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = GetID();
            if (id != null)
            {
                using(SupermercadoEntity db = new SupermercadoEntity())
                {
                    Productos producto = db.Productos.Find(id);
                    db.Productos.Remove(producto);

                    db.SaveChanges();
                }

                Actualizar();
            }
        }
    }
}
