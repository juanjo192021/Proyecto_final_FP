using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kardex_Productos
{
    public partial class Form1 : Form
    {
        string nombreFicheroAlmacen = "Productos_del_almacen.txt";
        string nombreFicheroSalida = "Productos_de_salida.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarFichero(nombreFicheroAlmacen, dgvProductosEntrada);
            mostrarFicheroSalida(nombreFicheroSalida, dgvProductosSalida);
            //gbProductoSalida.Visible = false;
        }
        private void mostrarFichero(string fichero, DataGridView dgvProductosAlmacen)
        {
            BinaryReader binario = null;
            try
            {
                if (File.Exists(fichero))
                {
                    binario = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));

                    Productos miProducto = new Productos();
                    dgvProductosAlmacen.Rows.Clear();

                    while (binario.BaseStream.Position != binario.BaseStream.Length)
                    {
                        miProducto.Codigo = binario.ReadString();
                        miProducto.Nombre = binario.ReadString();
                        miProducto.Marca = binario.ReadString();
                        miProducto.FechaVencimiento = binario.ReadString();
                        miProducto.Cantidad = binario.ReadInt32();
                        miProducto.TipoDeCantidad = binario.ReadString();

                        dgvProductosAlmacen.Rows.Add(miProducto.Codigo, miProducto.Nombre, miProducto.Marca, miProducto.FechaVencimiento, miProducto.Cantidad ,miProducto.TipoDeCantidad);
                    }
                }
                else
                    MessageBox.Show("El fichero no existe", "Error");
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message, "Error");
            }
            finally
            {
                if (binario != null)
                    binario.Close();
            }
        }
        private void mostrarFicheroSalida(string fichero, DataGridView dgvProductosAlmacen)
        {
            BinaryReader binario = null;
            try
            {
                if (File.Exists(fichero))
                {
                    binario = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));

                    Productos miProducto = new Productos();
                    dgvProductosAlmacen.Rows.Clear();

                    while (binario.BaseStream.Position != binario.BaseStream.Length)
                    {
                        miProducto.Codigo = binario.ReadString();
                        miProducto.Nombre = binario.ReadString();
                        miProducto.Marca = binario.ReadString();
                        miProducto.FechaVencimiento = binario.ReadString();
                        miProducto.Cantidad = binario.ReadInt32();
                        miProducto.TipoDeCantidad = binario.ReadString();
                        miProducto.FechaSalida = binario.ReadString();
                        miProducto.Trabajador = binario.ReadString();

                        dgvProductosAlmacen.Rows.Add(miProducto.Codigo, miProducto.Nombre, miProducto.Marca, miProducto.FechaVencimiento, miProducto.Cantidad, miProducto.TipoDeCantidad, miProducto.FechaSalida, miProducto.Trabajador);
                    }
                }
                else
                    MessageBox.Show("El fichero no existe", "Error");
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message, "Error");
            }
            finally
            {
                if (binario != null)
                    binario.Close();
            }
        }
        private void crearFichero(string fichero, Productos miProducto)
        {
            BinaryWriter crear = null;
            try
            {
                crear = new BinaryWriter(new FileStream(fichero, FileMode.Create, FileAccess.Write));

                crear.Write(miProducto.Codigo);
                crear.Write(miProducto.Nombre);
                crear.Write(miProducto.Marca);
                crear.Write(miProducto.FechaVencimiento);
                crear.Write(miProducto.Cantidad);
                crear.Write(miProducto.TipoDeCantidad);
                crear.Write(miProducto.FechaSalida);
                crear.Write(miProducto.Trabajador);
            }
            finally
            {
                if (crear != null)
                    crear.Close();
            }
        }
        private void agregarFichero(string fichero, Productos miProducto)
        {
            BinaryWriter agregar = null;
            try
            {
                agregar = new BinaryWriter(new FileStream(fichero, FileMode.Append, FileAccess.Write));
                agregar.Write(miProducto.Codigo);
                agregar.Write(miProducto.Nombre);
                agregar.Write(miProducto.Marca);
                agregar.Write(miProducto.FechaVencimiento);
                agregar.Write(miProducto.Cantidad);
                agregar.Write(miProducto.TipoDeCantidad);
                agregar.Write(miProducto.FechaSalida);
                agregar.Write(miProducto.Trabajador);
            }
            finally
            {
                if (agregar != null)
                    agregar.Close();
            }
        }
        private void modificarFichero(string fichero, Productos productoBusqueda)
        {
            BinaryReader archivo = null;
            BinaryWriter archivoTemporal = null;
            string ficheroTemporal = "Temporal.txt";

            try
            {
                archivo = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));
                archivoTemporal = new BinaryWriter(new FileStream(ficheroTemporal, FileMode.Create, FileAccess.Write));

                bool band = false;

                Productos miProducto = new Productos();
                Productos miEmpleadoTemporal = new Productos();

                while (archivo.BaseStream.Position != archivo.BaseStream.Length)
                {

                    miProducto.Codigo = archivo.ReadString();
                    miProducto.Nombre = archivo.ReadString();
                    miProducto.Marca = archivo.ReadString();
                    miProducto.FechaVencimiento = archivo.ReadString();
                    miProducto.Cantidad = archivo.ReadInt32();
                    miProducto.TipoDeCantidad = archivo.ReadString();
                    miProducto.FechaSalida = archivo.ReadString();
                    miProducto.Trabajador = archivo.ReadString();

                    if (miProducto.Codigo == productoBusqueda.Codigo)
                    {
                        miEmpleadoTemporal.Nombre = productoBusqueda.Nombre;
                        miEmpleadoTemporal.Marca = productoBusqueda.Marca;
                        miEmpleadoTemporal.FechaVencimiento = productoBusqueda.FechaVencimiento;
                        miEmpleadoTemporal.Cantidad = productoBusqueda.Cantidad;
                        miEmpleadoTemporal.TipoDeCantidad = productoBusqueda.TipoDeCantidad;
                        miEmpleadoTemporal.FechaSalida = productoBusqueda.FechaSalida;
                        miEmpleadoTemporal.Trabajador = productoBusqueda.Trabajador;

                        archivoTemporal.Write(miProducto.Codigo);
                        archivoTemporal.Write(miEmpleadoTemporal.Nombre);
                        archivoTemporal.Write(miEmpleadoTemporal.Marca);
                        archivoTemporal.Write(miEmpleadoTemporal.FechaVencimiento);
                        archivoTemporal.Write(miEmpleadoTemporal.Cantidad);
                        archivoTemporal.Write(miEmpleadoTemporal.TipoDeCantidad);
                        archivoTemporal.Write(miEmpleadoTemporal.FechaSalida);
                        archivoTemporal.Write(miEmpleadoTemporal.Trabajador);

                        band = true;

                    }
                    else
                    {
                        archivoTemporal.Write(miProducto.Codigo);
                        archivoTemporal.Write(miProducto.Nombre);
                        archivoTemporal.Write(miProducto.Marca);
                        archivoTemporal.Write(miProducto.FechaVencimiento);
                        archivoTemporal.Write(miProducto.Cantidad);
                        archivoTemporal.Write(miProducto.TipoDeCantidad);
                        archivoTemporal.Write(miProducto.FechaSalida);
                        archivoTemporal.Write(miProducto.Trabajador);
                    }

                }

                if (band == false)
                {
                    MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message, "Error");
            }
            finally
            {
                if (archivo != null)
                    archivo.Close();
                if (archivoTemporal != null)
                    archivoTemporal.Close();

                File.Delete(fichero);
                File.Move(ficheroTemporal, fichero);
            }
        }
        private bool validarCantidades(DataGridView almacen)
        {
            if (Convert.ToInt32(almacen.SelectedRows[0].Cells[4].Value) < int.Parse(inputCantidad.Text))
            {
                errorProvider.SetError(inputCantidad, "La cantidad del producto que desea retirar no es posible, ya que supera al stock del producto");
                inputCantidad.Clear();
                inputCantidad.Focus();
                return false;
            }
            errorProvider.SetError(inputCantidad, "");
            return true;
        }
        public bool noVacios()
        {
            if(inputCantidad.Text == "")
            {
                errorProvider.SetError(inputCantidad, "El campo CANTIDAD no puede estar vacio");
                inputCantidad.Focus();
                return false;
            }
            errorProvider.SetError(inputCantidad, "");
            if (inputTrabajador.Text == "")
            {
                errorProvider.SetError(inputTrabajador, "El campo TRABAJADOR no puede estar vacio");
                inputTrabajador.Focus();
                return false;
            }
            errorProvider.SetError(inputTrabajador, "");

            return true;
        }
        private void limpiarControles()
        {
            inputCodigo.Clear();
            inputNombre.Clear();
            inputMarca.Clear();
            dtpVencimiento.ResetText();
            inputCantidad.Clear();
            if (rbUnidades.Checked == true)
            {
                rbUnidades.Checked = false;
            }
            if (rbCajas.Checked == true)
            {
                rbCajas.Checked = false;
            }
            dtpSalida.ResetText();
            inputTrabajador.Clear();
        }
        private void buttonCrearProductoSalida_Click(object sender, EventArgs e)
        {
            if (!noVacios()) return;
            if (!validarCantidades(dgvProductosEntrada)) return;
            Productos myProductos = new Productos();

            myProductos.Codigo = inputCodigo.Text;
            myProductos.Nombre = inputNombre.Text;
            myProductos.Marca = inputMarca.Text;
            myProductos.FechaVencimiento = dtpVencimiento.Value.ToShortDateString();
            myProductos.Cantidad = int.Parse(inputCantidad.Text);
            if (rbUnidades.Checked == true)
            {
                myProductos.TipoDeCantidad = "Paquete(s)";
            }
            if (rbCajas.Checked == true)
            {
                myProductos.TipoDeCantidad = "Caja(s)";
            }
            myProductos.FechaSalida = dtpSalida.Value.ToShortDateString();
            myProductos.Trabajador = inputTrabajador.Text;
            crearFichero(nombreFicheroSalida, myProductos);
            mostrarFicheroSalida(nombreFicheroSalida, dgvProductosSalida);
            limpiarControles();
        }
        private void buttonAgregarProductosSalida_Click(object sender, EventArgs e)
        {
            if (!noVacios()) return;
            if (!validarCantidades(dgvProductosEntrada)) return;

            Productos myProductos = new Productos();

            myProductos.Codigo = inputCodigo.Text;
            myProductos.Nombre = inputNombre.Text;
            myProductos.Marca = inputMarca.Text;
            myProductos.FechaVencimiento = dtpVencimiento.Value.ToShortDateString();
            myProductos.Cantidad = int.Parse(inputCantidad.Text);
            if (rbUnidades.Checked == true)
            {
                myProductos.TipoDeCantidad = "Paquete(s)";
            }
            if (rbCajas.Checked == true)
            {
                myProductos.TipoDeCantidad = "Caja(s)";
            }
            myProductos.FechaSalida = dtpSalida.Value.ToShortDateString();
            myProductos.Trabajador = inputTrabajador.Text;
            agregarFichero(nombreFicheroSalida, myProductos);
            mostrarFicheroSalida(nombreFicheroSalida, dgvProductosSalida);
            limpiarControles();
        }
        private void dgvProductosEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inputCodigo.Text = dgvProductosEntrada.SelectedRows[0].Cells[0].Value.ToString();
            inputNombre.Text = dgvProductosEntrada.SelectedRows[0].Cells[1].Value.ToString();
            inputMarca.Text = dgvProductosEntrada.SelectedRows[0].Cells[2].Value.ToString();
            dtpVencimiento.Text = dgvProductosEntrada.SelectedRows[0].Cells[3].Value.ToString();
            if (dgvProductosEntrada.SelectedRows[0].Cells[5].Value.ToString() == "Paquete(s)")
            {
                rbUnidades.Checked = true;
            }
            if (dgvProductosEntrada.SelectedRows[0].Cells[5].Value.ToString() == "Caja(s)")
            {
                rbCajas.Checked = true;
            }
            labelNumeroStock.Text = dgvProductosEntrada.SelectedRows[0].Cells[4].Value.ToString() +" " + dgvProductosEntrada.SelectedRows[0].Cells[5].Value.ToString();           
            labelMensaje.Visible = false;
            //gbProductoSalida.Visible = true;
            inputCantidad.Clear();
            dtpSalida.ResetText();
            inputTrabajador.Clear();
            inputCodigo.Enabled = false;
            inputNombre.Enabled = false;
            inputMarca.Enabled = false;
            dtpVencimiento.Enabled = false;
            rbUnidades.Enabled = false;
            rbCajas.Enabled = false;
            inputCantidad.Focus();
        }
        private void buttonModificarProductosSalida_Click(object sender, EventArgs e)
        {
            if (!noVacios()) return;
            if (!validarCantidades(dgvProductosEntrada)) return;

            Productos myProductos = new Productos();

            myProductos.Codigo = inputCodigo.Text;
            myProductos.Nombre = inputNombre.Text;
            myProductos.Marca = inputMarca.Text;
            myProductos.FechaVencimiento = dtpVencimiento.Value.ToShortDateString();
            myProductos.Cantidad = int.Parse(inputCantidad.Text);
            if (rbUnidades.Checked == true)
            {
                myProductos.TipoDeCantidad = "Paquete(s)";
            }
            if (rbCajas.Checked == true)
            {
                myProductos.TipoDeCantidad = "Caja(s)";
            }
            myProductos.FechaSalida = dtpSalida.Value.ToShortDateString();
            myProductos.Trabajador = inputTrabajador.Text;
            modificarFichero(nombreFicheroSalida, myProductos);
            mostrarFicheroSalida(nombreFicheroSalida, dgvProductosSalida);
            limpiarControles();
        }
        private void dgvProductosSalida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inputCodigo.Text = dgvProductosSalida.SelectedRows[0].Cells[0].Value.ToString();
            inputNombre.Text = dgvProductosSalida.SelectedRows[0].Cells[1].Value.ToString();
            inputMarca.Text = dgvProductosSalida.SelectedRows[0].Cells[2].Value.ToString();
            dtpVencimiento.Text = dgvProductosSalida.SelectedRows[0].Cells[3].Value.ToString();
            inputCantidad.Text = dgvProductosSalida.SelectedRows[0].Cells[4].Value.ToString();            
            if (dgvProductosSalida.SelectedRows[0].Cells[5].Value.ToString() == "Paquete(s)")
            {
                rbUnidades.Checked = true;
            }
            if (dgvProductosSalida.SelectedRows[0].Cells[5].Value.ToString() == "Caja(s)")
            {
                rbCajas.Checked = true;
            }
            dtpSalida.Text = dgvProductosSalida.SelectedRows[0].Cells[6].Value.ToString();
            inputTrabajador.Text = dgvProductosSalida.SelectedRows[0].Cells[7].Value.ToString();
            //labelNumeroStock.Text = dgvProductosSalida.SelectedRows[0].Cells[4].Value.ToString() + " " + dgvProductosSalida.SelectedRows[0].Cells[5].Value.ToString();
            labelMensaje.Visible = false;
            //gbProductoSalida.Visible = true;
            inputCodigo.Enabled = false;
            inputNombre.Enabled = false;
            inputMarca.Enabled = false;
            dtpVencimiento.Enabled = false;
            rbUnidades.Enabled = false;
            rbCajas.Enabled = false;
        }
        private void buscarFicheroSalida(string fichero, string codigoBuscar)
        {
            BinaryReader archivoBinario = null;
            try
            {
                if (File.Exists(fichero))
                {
                    archivoBinario = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));
                    bool band = false;
                    Productos miProducto = new Productos();
                    while (archivoBinario.BaseStream.Position != archivoBinario.BaseStream.Length)
                    {
                        miProducto.Codigo = archivoBinario.ReadString();
                        miProducto.Nombre = archivoBinario.ReadString();
                        miProducto.Marca = archivoBinario.ReadString();
                        miProducto.FechaVencimiento = archivoBinario.ReadString();
                        miProducto.Cantidad = archivoBinario.ReadInt32();
                        miProducto.TipoDeCantidad = archivoBinario.ReadString();
                        miProducto.FechaSalida = archivoBinario.ReadString();
                        miProducto.Trabajador = archivoBinario.ReadString();

                        if (miProducto.Codigo == codigoBuscar)
                        {
                            MessageBox.Show("El producto de salida ha sido encontrado correctamente", "RESULTADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inputCodigo.Text = miProducto.Codigo;
                            inputNombre.Text = miProducto.Nombre;
                            inputMarca.Text = miProducto.Marca;
                            dtpVencimiento.Text= miProducto.FechaVencimiento;
                            inputCantidad.Text = miProducto.Cantidad.ToString();
                            if (miProducto.TipoDeCantidad == "Paquete(s)")
                            {
                                rbUnidades.Checked = true;
                            }
                            if (miProducto.TipoDeCantidad == "Caja(s)")
                            {
                                rbCajas.Checked = true;
                            }
                            dtpSalida.Text = miProducto.FechaSalida;
                            inputTrabajador.Text = miProducto.Trabajador; 
                            band = true;
                        }
                    }
                    if (band == false)
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("El fichero no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (archivoBinario != null)
                    archivoBinario.Close();
            }
        }
        private void buscarFicheroAlmacen(string fichero, string codigoBuscar)
        {
            BinaryReader archivoBinario = null;
            try
            {
                if (File.Exists(fichero))
                {
                    archivoBinario = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));
                    bool band = false;
                    Productos miProducto = new Productos();
                    while (archivoBinario.BaseStream.Position != archivoBinario.BaseStream.Length)
                    {
                        miProducto.Codigo = archivoBinario.ReadString();
                        miProducto.Nombre = archivoBinario.ReadString();
                        miProducto.Marca = archivoBinario.ReadString();
                        miProducto.FechaVencimiento = archivoBinario.ReadString();
                        miProducto.Cantidad = archivoBinario.ReadInt32();
                        miProducto.TipoDeCantidad = archivoBinario.ReadString();
                        //miProducto.FechaSalida = archivoBinario.ReadString();
                        //miProducto.Trabajador = archivoBinario.ReadString();

                        if (miProducto.Codigo == codigoBuscar)
                        {
                            MessageBox.Show("El producto del almacén ha sido encontrado correctamente", "RESULTADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inputCodigo.Text = miProducto.Codigo;
                            inputNombre.Text = miProducto.Nombre;
                            inputMarca.Text = miProducto.Marca;
                            dtpVencimiento.Text = miProducto.FechaVencimiento;
                            if (miProducto.TipoDeCantidad == "Paquete(s)")
                            {
                                rbUnidades.Checked = true;
                            }
                            if (miProducto.TipoDeCantidad == "Caja(s)")
                            {
                                rbCajas.Checked = true;
                            }
                            labelNumeroStock.Text = miProducto.Cantidad.ToString() + " " + miProducto.TipoDeCantidad;

                            band = true;
                        }
                    }
                    if (band == false)
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("El fichero no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (archivoBinario != null)
                    archivoBinario.Close();
            }
        }
        private void buttonBuscarProductosSalida_Click(object sender, EventArgs e)
        {
            string codigoBuscarSalida = inputBuscarSalida.Text;
            buscarFicheroSalida(nombreFicheroSalida, codigoBuscarSalida);
            labelMensaje.Visible = false;
            gbProductoSalida.Visible = true;
            inputCodigo.Enabled = false;
            inputNombre.Enabled = false;
            inputMarca.Enabled = false;
            dtpVencimiento.Enabled = false;
            rbUnidades.Enabled = false;
            rbCajas.Enabled = false;
            inputBuscarSalida.Clear();
        }
        private void buttonBuscarProductosAlmacen_Click(object sender, EventArgs e)
        {
            string codigoBuscarAlmacen = inputBuscarProductoAlmacen.Text;
            buscarFicheroAlmacen(nombreFicheroAlmacen, codigoBuscarAlmacen);
            labelMensaje.Visible = false;
            gbProductoSalida.Visible = true;
            inputCodigo.Enabled = false;
            inputNombre.Enabled = false;
            inputMarca.Enabled = false;
            dtpVencimiento.Enabled = false;
            rbUnidades.Enabled = false;
            rbCajas.Enabled = false;
            inputBuscarProductoAlmacen.Clear();
        }
        private void eliminarFicheroSalida(string fichero, string codigoSalidaEliminar)
        {
            BinaryReader archivo = null;
            BinaryWriter archivoTemporal = null;
            string ficheroTemporal = "Temporal.txt";
            try
            {
                archivo = new BinaryReader(new FileStream(fichero, FileMode.Open, FileAccess.Read));
                archivoTemporal = new BinaryWriter(new FileStream(ficheroTemporal, FileMode.Create, FileAccess.Write));

                bool band = false;

                Productos miProducto = new Productos();

                while (archivo.BaseStream.Position != archivo.BaseStream.Length)
                {
                    miProducto.Codigo = archivo.ReadString();
                    miProducto.Nombre = archivo.ReadString();
                    miProducto.Marca = archivo.ReadString();
                    miProducto.FechaVencimiento = archivo.ReadString();
                    miProducto.Cantidad = archivo.ReadInt32();
                    miProducto.TipoDeCantidad = archivo.ReadString();
                    miProducto.FechaSalida = archivo.ReadString();
                    miProducto.Trabajador = archivo.ReadString(); 

                    if (miProducto.Codigo == codigoSalidaEliminar)
                    {
                        MessageBox.Show("Producto de Salida eliminado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        band = true;
                    }
                    else
                    {
                        archivoTemporal.Write(miProducto.Codigo);
                        archivoTemporal.Write(miProducto.Nombre);
                        archivoTemporal.Write(miProducto.Marca);
                        archivoTemporal.Write(miProducto.FechaVencimiento);
                        archivoTemporal.Write(miProducto.Cantidad);
                        archivoTemporal.Write(miProducto.TipoDeCantidad);
                        archivoTemporal.Write(miProducto.FechaSalida);
                        archivoTemporal.Write(miProducto.Trabajador);
                    }
                }
                if (band == false)
                {
                    MessageBox.Show("Numero NO encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Error: " + e.Message, "Error");
            }
            finally
            {
                if (archivo != null)
                    archivo.Close();
                if (archivoTemporal != null)
                    archivoTemporal.Close();

                File.Delete(fichero);
                File.Move(ficheroTemporal, fichero);
            }
        }

        private void buttonEliminarProductosSalida_Click(object sender, EventArgs e)
        {
            string codigoSalidaEliminar = inputCodigo.Text;
            if (MessageBox.Show("¿ Desea eliminar el registro de salida del producto con el código " + codigoSalidaEliminar + "  ? ", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                eliminarFicheroSalida(nombreFicheroSalida, codigoSalidaEliminar);
            }
            mostrarFicheroSalida(nombreFicheroSalida, dgvProductosSalida);
            limpiarControles();
        }
    }
}
