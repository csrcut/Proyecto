using System;
//using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

//cambiar el namespace por namespace mysqlConnect
	
namespace Clientes
{ 

	public class funciones:MySQL
	{

		
		public funciones()
		{
		}
	
		//muestra los registros de la base de datos
		public void mostrarTodosp(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string folio = myReader["folio"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string domiclio = myReader["domicilio"].ToString();
	            string telefono = myReader["telefono"].ToString();
	           
	       }

            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}

		public void agregarcliente(string nombre,string domicilio, string telefono){
			this.abrirConexion();
			string sql = "INSERT INTO `registro` (`nombre` , `domicilio` , `telefono` ) values ('"+ nombre +"','"+domicilio+"','"+telefono+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();			
		}
		public void eliminarcliente(string selecionar){
			this.abrirConexion();
			string sql = "DELETE FROM registro WHERE(`id`='" + selecionar + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		public void editarcliente(string folio ,string nombre,string domicilio, string telefono){
			this.abrirConexion();
			string sql ="UPDATE registro SET `nombre`='"+nombre+"',`domicilio`='"+domicilio+"',`telefono`='"+telefono+"' WHERE (`folio`='"+folio+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		private string querySelect(){
			return "SELECT * " +
	           	"FROM registro";
		}
		
		
		
	}
}
