/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 12/21/2017
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Programator
{
	partial class AdaugaProgramare
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button button5;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(294, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(271, 75);
			this.button1.TabIndex = 0;
			this.button1.Text = "Adauga";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "HH:mm";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(18, 56);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 1;
			this.dateTimePicker1.Value = new System.DateTime(2018, 1, 8, 9, 0, 0, 0);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "HH:mm";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(398, 56);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.ShowUpDown = true;
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2.TabIndex = 2;
			this.dateTimePicker2.Value = new System.DateTime(2018, 1, 8, 17, 0, 0, 0);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Ora de inceput";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(398, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Ora de Sfarsit";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(615, 100);
			this.panel1.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(224, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(168, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Tip Asigurare";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(224, 55);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(168, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.textBox3);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.textBox2);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Location = new System.Drawing.Point(12, 118);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(615, 70);
			this.panel2.TabIndex = 6;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(0, 40);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(201, 136);
			this.textBox4.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 11);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(203, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Observati";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(412, 37);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(200, 20);
			this.textBox3.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(412, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(200, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Email";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(209, 37);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(200, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2KeyPress);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(209, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Telefon";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(200, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Nume";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 37);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(200, 20);
			this.textBox1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.button5);
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Location = new System.Drawing.Point(12, 387);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(822, 83);
			this.panel3.TabIndex = 7;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(3, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(285, 75);
			this.button2.TabIndex = 1;
			this.button2.Text = "Bon Fiscal";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.listView1);
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.button3);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Controls.Add(this.textBox5);
			this.panel4.Controls.Add(this.comboBox3);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Location = new System.Drawing.Point(12, 194);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(822, 187);
			this.panel4.TabIndex = 12;
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(3, 58);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(603, 120);
			this.listView1.TabIndex = 8;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(620, 93);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(191, 85);
			this.button4.TabIndex = 7;
			this.button4.Text = "Sterge Serviciu";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(620, 7);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(191, 80);
			this.button3.TabIndex = 6;
			this.button3.Text = "Adauga Serviciu";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(3, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(504, 18);
			this.label10.TabIndex = 5;
			this.label10.Text = "Servici";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(513, 31);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(93, 20);
			this.textBox5.TabIndex = 1;
			this.textBox5.TextChanged += new System.EventHandler(this.TextBox5TextChanged);
			this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox5KeyPress);
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(3, 30);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(504, 21);
			this.comboBox3.TabIndex = 4;
			this.comboBox3.DropDownClosed += new System.EventHandler(this.ComboBox3DropDownClosed);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(513, 5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(93, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "Pret";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(662, 407);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(279, 21);
			this.comboBox2.TabIndex = 3;
			this.comboBox2.DropDownClosed += new System.EventHandler(this.ComboBox2DropDownClosed);
			this.comboBox2.Leave += new System.EventHandler(this.ComboBox2Leave);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(683, 317);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(279, 23);
			this.label9.TabIndex = 2;
			this.label9.Text = "Consultatie";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.textBox4);
			this.panel5.Controls.Add(this.label6);
			this.panel5.Location = new System.Drawing.Point(633, 12);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(201, 176);
			this.panel5.TabIndex = 13;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(571, 3);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(246, 75);
			this.button5.TabIndex = 2;
			this.button5.Text = "Inchide";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// AdaugaProgramare
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(836, 474);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.label9);
			this.Name = "AdaugaProgramare";
			this.Text = "AdaugaProgramare";
			this.Load += new System.EventHandler(this.AdaugaProgramareLoad);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
