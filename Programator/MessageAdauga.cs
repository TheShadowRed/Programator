/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 5/23/2018
 * Time: 13:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Programator
{
	/// <summary>
	/// Description of MessageAdauga.
	/// </summary>
	public partial class MessageAdauga : Form
	{
		public MessageAdauga()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label1.Text="Bonul Fiscal are valoare de :"+MainForm.Suma+" lei";
			MainForm.DaSiNu="Nu";
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			MainForm.DaSiNu="Da";
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
