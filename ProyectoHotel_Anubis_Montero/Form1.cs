using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHotel_Anubis_Montero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //aparecer ventana en el centro de la pantalla

            this.StartPosition = FormStartPosition.CenterScreen;

            //poner nombre al titulo del formulario

            this.Text = "Registro de Clientes";

            

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //cerrar la aplicacion

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //limpiar los textBox

            textBoxNombres.Clear();
            textBoxApellidos.Clear();
            textBoxRut.Clear();
            textBoxTelefono.Clear();
            textBoxCorreo.Clear();
            textBoxDireccion.Clear();
            textBoxNumeroHabitacion.Clear();
            textBoxDiasHospedaje.Clear();
            textBoxValorHabitacion.Clear();

            //limpiar los checkBox

            checkBoxPiscina.Checked = false;
            checkBoxSeguridad.Checked = false;
            checkBoxBaryRestaurant.Checked = false;
            checkBoxLimpieza.Checked = false;

            //limpiar comboBox

            comboBox1.SelectedIndex = -1;

            //limpiar comboBox incluso con un string o int ingresado

            comboBox1.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNombres.Text == "" || !Regex.IsMatch(textBoxNombres.Text, @"[a-zA-Z]" ))
            {

                MessageBox.Show("Ingrese el Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxApellidos.Text == "" || !Regex.IsMatch(textBoxApellidos.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Ingrese el Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxRut.Text == "" || !Regex.IsMatch(textBoxRut.Text, @"[0-9]"))
            {
                MessageBox.Show("Ingrese el Rut", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxTelefono.Text == "" || !Regex.IsMatch(textBoxTelefono.Text, @"[0-9]"))
            {
                MessageBox.Show("Ingrese el Telefono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxCorreo.Text == "" || !Regex.IsMatch(textBoxCorreo.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Ingrese el Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxDireccion.Text == "" || !Regex.IsMatch(textBoxDireccion.Text, @"[a-zA-Z]"))
            {
                MessageBox.Show("Ingrese la Direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxValorHabitacion.Text == "" || !Regex.IsMatch(textBoxValorHabitacion.Text, @"[0-9]"))
            {
                MessageBox.Show("Ingrese el Valor de la Habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxNumeroHabitacion.Text == "" || !Regex.IsMatch(textBoxNumeroHabitacion.Text, @"[0-9]"))
            {
                MessageBox.Show("Ingrese el Numero de Habitacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBoxDiasHospedaje.Text == "" || !Regex.IsMatch(textBoxDiasHospedaje.Text, @"[0-9]"))
            {
                MessageBox.Show("Ingrese los Dias de Hospedaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Generando Boleta!", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            int precioHab,servicios, diasHospedaje, piscinaGym, seguridadEstacionamiento, barRestaurant, limpieza, valorHabitacion;
            double Total, IVA, ValorFinal;

            servicios = 0;
            precioHab = 0;

            //precio de la habitacion

            if (comboBox1.SelectedIndex == 0)
            {
                precioHab = 200000;
                textBoxValorHabitacion.Text = "200000";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                precioHab = 360000;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                precioHab = 580000;
            }

            //valor de la habitacion

            valorHabitacion = Convert.ToInt32(textBoxValorHabitacion.Text);

            //cantidad de dias de hospedaje

            diasHospedaje = Convert.ToInt32(textBoxDiasHospedaje.Text);

            //precio de los servicios adicionales (piscina, gym, seguridad, estacionamiento, bar y restaurant, limpieza)

            if (checkBoxPiscina.Checked == true)
            {
                piscinaGym = 100000;
                servicios = servicios + piscinaGym;
            }
            if (checkBoxSeguridad.Checked == true)
            {
                seguridadEstacionamiento = 150000;
                servicios = servicios + seguridadEstacionamiento;
            }
            if (checkBoxBaryRestaurant.Checked == true)
            {
                barRestaurant = 200000;
                servicios = servicios + barRestaurant;
            }
            if (checkBoxLimpieza.Checked == true)
            {
                limpieza = 80000;
                servicios = servicios + limpieza;
            }

            //calcular el precio total de la boleta

            Total = precioHab * diasHospedaje + servicios + valorHabitacion;
            IVA = Total * 0.19;
            ValorFinal = Total + IVA;

            //instanciar clase Registro Hotel

            Registro_Hotel registro = new Registro_Hotel();

            //asignar valores a los atributos de la clase Registro_Hotel

            registro.Nombres = textBoxNombres.Text;
            registro.Apellidos = textBoxApellidos.Text;
            registro.Rut = textBoxRut.Text;
            registro.Telefono = textBoxTelefono.Text;
            registro.Correo = textBoxCorreo.Text;
            registro.Direccion = textBoxDireccion.Text;
            registro.ValorHabitacion = int.Parse(textBoxValorHabitacion.Text);
            registro.TipoHabitacion = comboBox1.Text;
            registro.NHabitacion = int.Parse(textBoxNumeroHabitacion.Text);
            registro.DiasHospedaje = int.Parse(textBoxDiasHospedaje.Text);

            //instancias de la clase windows forms Boleta_Generada

            Boleta_Generada boleta = new Boleta_Generada();

            boleta.listBox1.Items.Add("---------------------------- Boleta -----------------------------");
            boleta.listBox1.Items.Add("---------------- Datos Cliente --------------");
            boleta.listBox1.Items.Add(" ");
            boleta.listBox1.Items.Add("Nombres: " + registro.Nombres);
            boleta.listBox1.Items.Add("Apellidos: " + registro.Apellidos);
            boleta.listBox1.Items.Add("Rut: " + registro.Rut);
            boleta.listBox1.Items.Add("Telefono: " + registro.Telefono);
            boleta.listBox1.Items.Add("Correo: " + registro.Correo);
            boleta.listBox1.Items.Add("Direccion: " + registro.Direccion);
            boleta.listBox1.Items.Add("Numero de Habitacion: " + registro.NHabitacion);
            boleta.listBox1.Items.Add(" ");
            boleta.listBox1.Items.Add("---------------- Costos y Servicios --------------");
            boleta.listBox1.Items.Add("Tipo de Habitacion: " + registro.TipoHabitacion);
            boleta.listBox1.Items.Add("Dias de Hospedaje: " + registro.DiasHospedaje);
            boleta.listBox1.Items.Add("Precio Habitacion: " + registro.ValorHabitacion);
            boleta.listBox1.Items.Add("Precio de los servicios añadidos: " + servicios);
            boleta.listBox1.Items.Add(" ");
            boleta.listBox1.Items.Add("---------------- TOTAL --------------");
            boleta.listBox1.Items.Add("Precio Neto: " + Total);
            boleta.listBox1.Items.Add("IVA: " + IVA);
            boleta.listBox1.Items.Add("Precio Bruto: " + ValorFinal);

            // generar boleta en el centro de la pantalla

            boleta.StartPosition = FormStartPosition.CenterScreen;

            boleta.Show();

        }
        
    }
}
