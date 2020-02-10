using System;
using System.Windows.Forms;
using Prueba.Modelos;

namespace Prueba.Presentacion
{
    public partial class Agregar : Form
    {
        public int? id;
        public Productos productos = null;

        public Agregar(int? id=null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
                CargarCampos();
        }

        private void CargarCampos() 
        { 
            using (SupermercadoEntity db = new SupermercadoEntity())
            {
                productos = db.Productos.Find(id);
                tfNombre.Text = productos.nombre;
                tfPrecio.Text = productos.precio.ToString();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SupermercadoEntity db = new SupermercadoEntity())
            {
                if(id == null)
                productos = new Productos();

                productos.nombre = tfNombre.Text;
                productos.precio = int.Parse(tfPrecio.Text);

                if(id == null)
                db.Productos.Add(productos);
                else
                {
                    db.Entry(productos).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                this.Close();
            }
        }
    }
}
