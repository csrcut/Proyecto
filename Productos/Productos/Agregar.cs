
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clientes
{
	/// <summary>
	/// Description of Agregar.
	/// </summary>
	public partial class Agregar : Form
	{
		private MainForm Mf;
		
		public Agregar(MainForm Mf)
		{
			
			this.Mf=Mf;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			funciones fun=new funciones();
			fun.agregarcliente(this.textBox1.Text.Trim(),this.textBox2.Text.Trim(),this.textBox3.Text.Trim());
			this.Mf.actualizarTabla();
			this.Dispose();
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
	}
}
