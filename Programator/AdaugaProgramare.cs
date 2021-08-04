/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 12/21/2017
 * Time: 10:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Programator
{
	/// <summary>
	/// Description of AdaugaProgramare.
	/// </summary>
	public partial class AdaugaProgramare : Form
	{
		public string numeid;
 		int sizeChanged=0;
 		int OldSize=0;
		public int duration;
		public DataTable dta;
		public string Timestartp;
		public DateTime currentDate;
		public AdaugaProgramare(String name,String TimpStart,String TimpStop,String pass,String pozition,String OraCurrent,DateTime CurrentDate)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			listView1.View=View.Details;
			listView1.Columns.Add("serviciu");
       		listView1.Columns.Add("id");
       		listView1.Columns.Add("Pret");
			numeid=name;
			int acounterTime=1;
			Timestartp=TimpStart;
			dateTimePicker1.Value=CurrentDate;
			dateTimePicker2.Value=CurrentDate;
			currentDate=CurrentDate;
			dateTimePicker1.MinDate = DateTime.Parse(TimpStart);
			dateTimePicker1.MaxDate = DateTime.Parse(TimpStop);
			dateTimePicker2.MinDate = DateTime.Parse(TimpStart);
			dateTimePicker2.MaxDate = DateTime.Parse(TimpStop);
			var TimpStarta=TimeSpan.Parse(TimpStart);
			var TimpStopa=TimeSpan.Parse(TimpStop);
			//var TimpResultStart=TimpStopa-TimpStarta;
			var TimpResultStart=TimpStarta;
			String intresult=TimpResultStart.ToString();
			intresult = intresult.Substring(0, intresult.Length-2);
			var TimpInceput=TimeSpan.Parse(TimpStart);
			pass="00:"+pass;
			var Timppass=TimeSpan.Parse(pass);
			var TimpCurrent=TimeSpan.Parse(OraCurrent);
			while(acounterTime==1)
			{
				
				
				
				var TimpSecund=TimpInceput+Timppass;
				
				if(TimpSecund>TimpCurrent)
				{
					acounterTime=2;
					string[] timpInceput = TimpInceput.ToString().Split(':');
					dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(timpInceput[0]),Int32.Parse(timpInceput[1]),0);
					string[] timpend = TimpSecund.ToString().Split(':');
					dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(timpend[0]),Int32.Parse(timpend[1]),0);
				}else
				{
					TimpInceput=TimpSecund;	
				}
			}
			LoadDatas();
			
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label7.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label4.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label5.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label9.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label6.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label8.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
		
			label10.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox4.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			textBox5.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button4.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			button5.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			comboBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			comboBox2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			comboBox3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			listView1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			dateTimePicker1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			dateTimePicker2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			comboBox3.DropDownHeight=100;
			String comb=dta.Rows[comboBox3.SelectedIndex][1].ToString();
		using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Programator_select_analizaPret", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("nr_crt_i", comb));
     con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox5.Text=reader["Pret_Plata"].ToString();
                        }
                    }
    
    }
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void LoadDatas()
		{
			//load groupe analize 
			using(MySqlConnection conn = new MySqlConnection(MainForm.myStringCon))
				{
    MySqlCommand command = new MySqlCommand("Select_analizeGroup", conn);
    command.CommandType = System.Data.CommandType.StoredProcedure;

    conn.Open();
      MySqlDataAdapter Da = new MySqlDataAdapter(command);
          						 
                						
                						DataTable dt = new DataTable("DataTable_ListaTir");
                						Da.Fill(dt);
                						dta = new DataTable("DataTable_ListaTira");
                						Da.Fill(dta);
                						comboBox2.ValueMember = "nr_crt";
                						comboBox2.DisplayMember = "subgrup";
                						comboBox2.DataSource = dt;
                						
                						comboBox3.ValueMember = "nr_crt";
                						comboBox3.DisplayMember = "subgrup";
                						comboBox3.DataSource = dta;
				}
				using(MySqlConnection conn = new MySqlConnection(MainForm.myStringCon))
				{
    MySqlCommand command = new MySqlCommand("Select_Tip_asigurare", conn);
    command.CommandType = System.Data.CommandType.StoredProcedure;

    conn.Open();
      MySqlDataAdapter Da = new MySqlDataAdapter(command);
          						 
                						
                						DataTable dt = new DataTable("DataTable_ListaTir");
                						Da.Fill(dt);
                						comboBox1.ValueMember = "cod";
                						comboBox1.DisplayMember = "Nume";
                						comboBox1.DataSource = dt;
				}
		}
		void Button1Click(object sender, EventArgs e)
		{
			String resultCheck="";
			//check if exist
			using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("CheckProgramare;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("data1_i", new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, dateTimePicker1.Value.Hour,dateTimePicker1.Value.Minute,0).ToString("yyyy-MM-dd HH:mm:ss")));
    command.Parameters.Add(new MySqlParameter("Medic_i", MainForm.DoctorId[Int32.Parse(numeid)]));
    con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultCheck=reader["Data_Start"].ToString();
                        }
                    }
    
    }
			//insert
			if(resultCheck==""){
			using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("InsertDataInProgramare;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    command.Parameters.Add(new MySqlParameter("cod_intern_i", MainForm.DoctorId[Int32.Parse(numeid)]));
    command.Parameters.Add(new MySqlParameter("nume_i", new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, dateTimePicker1.Value.Hour,dateTimePicker1.Value.Minute,0).ToString("yyyy-MM-dd HH:mm:ss")));
    command.Parameters.Add(new MySqlParameter("cod_w_i", new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, dateTimePicker2.Value.Hour,dateTimePicker2.Value.Minute,0).ToString("yyyy-MM-dd HH:mm:ss")));
    command.Parameters.Add(new MySqlParameter("Numei_i", textBox1.Text.ToString()));
    if(textBox2.Text.ToString()==""){
     command.Parameters.Add(new MySqlParameter("Telefon_i", null));
    }else{
    command.Parameters.Add(new MySqlParameter("Telefon_i", textBox2.Text.ToString()));
    }
    command.Parameters.Add(new MySqlParameter("Mail_i", textBox3.Text.ToString()));
    command.Parameters.Add(new MySqlParameter("Observatie_i", textBox4.Text.ToString()));
    command.Parameters.Add(new MySqlParameter("AnalizaModTrimitere_i", comboBox1.SelectedValue.ToString()));
    
    con.Open();
    command.ExecuteNonQuery();
    //int result = (int)command.ExecuteScalar();
    
    }
			//get id
			String id_programare="";
			//insert in angajat_programator_detaliat
				         
        
            using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("cauta_max;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    command.Parameters.Add(new MySqlParameter("tabel", "angajati_programari"));
    command.Parameters.Add(new MySqlParameter("coloana",  "ID"));
   con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_programare=reader["max"].ToString();
                        }
                    }
    }
        
    
			for (int a=0;a<listView1.Items.Count;a++)
    {            
        
            using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("InsertDataInProgramare_Detaliat;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    command.Parameters.Add(new MySqlParameter("ID_lista_i", listView1.Items[a].SubItems[1].Text));
    command.Parameters.Add(new MySqlParameter("Nume_i",  listView1.Items[a].SubItems[0].Text));
    command.Parameters.Add(new MySqlParameter("Pret_i", listView1.Items[a].SubItems[2].Text));

     command.Parameters.Add(new MySqlParameter("ID_Programare_i",id_programare ));
    con.Open();
    command.ExecuteNonQuery();
    }
        
    }
			MessageBox.Show("Date Introduse",
    "Programare");
			//add image in table
			string time1 = dateTimePicker1.Value.ToString("HH:mm");
			string time2 = dateTimePicker2.Value.ToString("HH:mm");
			int timeInt1;
			int timeInt2;
			//duration e ora de inceput in  pixeli
			  	var durationa=TimeSpan.Parse(Timestartp);
				var timespan1=TimeSpan.Parse(time1);
				var timespan2=TimeSpan.Parse(time2);
				var TimpResultStart=timespan1-durationa;
				var Marime=timespan2-timespan1;
				String marimefin=Marime.ToString().Replace(":", "");
			String timeFinal=TimpResultStart.ToString().Replace(":", "");
			int timp=Int32.Parse(timeFinal.Remove(timeFinal.Length-2));
			int marFin=Int32.Parse(marimefin.Remove(marimefin.Length-2));
			string[] words = Marime.ToString().Split(':');
			string[] wordas = TimpResultStart.ToString().Split(':');
			double total = (Convert.ToInt32(words[0]) * 60) + Convert.ToInt32(words[1]);
			double timeMarimea = (Convert.ToInt32(wordas[0]) * 60) + Convert.ToInt32(wordas[1]);
			total=(total/60)*100;
			timeMarimea=(timeMarimea/60)*100;
			int timeMarime=timp;
			Panel panel1=new Panel();
			Label Nume=new Label();
			Nume.ForeColor = Color.Yellow;
			Label Telefon=new Label();
			Label TipAsigurare=new Label();
			TipAsigurare.ForeColor = Color.Yellow;
			TipAsigurare.Click += new EventHandler(PanelClickModifica);
			TipAsigurare.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			TipAsigurare.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			TipAsigurare.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			TipAsigurare.Text=comboBox1.Text.ToString();
			Telefon.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			Telefon.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			Nume.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			Nume.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			Telefon.ForeColor = Color.Yellow;
			Nume.Text=textBox1.Text.ToString();
			Telefon.Text=textBox2.Text.ToString();
			panel1.Controls.Add(Telefon);
			Telefon.Dock=DockStyle.Right;
			Telefon.Click += new EventHandler(PanelClickModifica);
			Telefon.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			Nume.Click += new EventHandler(PanelClickModifica);
			Nume.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			panel1.Controls.Add(Nume);
			panel1.Controls.Add(TipAsigurare);
			TipAsigurare.Dock=DockStyle.Bottom;
			//TipAsigurare.Location=new Point(TipAsigurare.Location.Y+20,TipAsigurare.Location.X+20);
			TipAsigurare.BringToFront();
			panel1.Size = new Size(200, Convert.ToInt32(total));
			panel1.Name=numeid;
			panel1.BorderStyle=BorderStyle.FixedSingle;
			panel1.Location = new Point(panel1.Location.Y, panel1.Location.X+Convert.ToInt32(timeMarimea));
			panel1.BackColor=Color.Red;
			MainForm.PanelDoctori[Int32.Parse(numeid)].Controls.Add(panel1);
			panel1.BringToFront();
			Nume.BringToFront();
			panel1.Click += new EventHandler(PanelClickModifica);
			panel1.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			panel1.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			panel1.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			//insert
			this.Close();
			}
			else
			{
				MessageBox.Show("Date Exista deja pentru perioada de timp introdusa",
    "Programare");
    }
			
		}
		void PanelClickModifica(object sender, EventArgs e)
		{
			//select specific panel
			var panel = sender as Panel;
			if(panel==null)
			 {
			 	var label=sender as Label;
			 	panel=label.Parent as Panel;
			 }
			int Counter=Int32.Parse(panel.Name);
			ModificaProgramare f2 = new ModificaProgramare(panel.Name,MainForm.TimpStartDoca[Counter],MainForm.TimpStopDoca[Counter],MainForm.TickPerDoctor[Counter],MainForm.pozitionAA,MainForm.a.Text,currentDate);
			f2.ShowDialog();
		}
		void Panel3MouseEnter(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if(panel==null)
			 {
			 	var label=sender as Label;
			 	panel=label.Parent as Panel;
			 	if(panel.Size.Height<35)
					{
						OldSize=panel.Size.Height;
						panel.Size= new Size(panel.Size.Width, 50);
						sizeChanged=1;
						panel.BringToFront();
					}
			}
			
		}
		void Panel3MouseLeave(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if(panel==null)
			 {
			 	var label=sender as Label;
			 	panel=label.Parent as Panel;
			 	if(panel.Size.Height==50)
				{
					if(sizeChanged==1){
						panel.Size= new Size(panel.Size.Width, OldSize);
						sizeChanged=0;
					}
				}
			 }
			
		}
		void Panel3MouseMove(object sender, MouseEventArgs e)
		{
			string[] words = MainForm.oraStart.Split(':');
			double total = (Convert.ToInt32(words[0]) * 60) + Convert.ToInt32(words[1]);
			Point point = panel3.PointToClient(Cursor.Position);
			double addaos=point.Y*0.6;
			total=total+addaos;
			point.X=point.X-105;
			MainForm.a.Location=(point);
			MainForm.a.BackColor = System.Drawing.Color.Transparent;
			var MinutesFromDB = Convert.ToInt32(total);
			TimeSpan timeSpan = TimeSpan.FromMinutes(MinutesFromDB);
			MainForm.a.Text=timeSpan.ToString(@"hh\:mm");
			MainForm.timp=timeSpan.ToString(@"hh\:mm");
			MainForm.a.BringToFront();
			
		}
		void AdaugaProgramareLoad(object sender, EventArgs e)
		{
	
		}
		void TextBox2KeyPress(object sender, KeyPressEventArgs e)
		{
    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
    {
            e.Handled = true;
    }

    // only allow one decimal point
    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
    {
        e.Handled = true;
    }

		}
		void TextBox5TextChanged(object sender, EventArgs e)
		{
	
		}
		void TextBox5KeyPress(object sender, KeyPressEventArgs e)
		{
    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
    {
            e.Handled = true;
    }

    // only allow one decimal point
    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
    {
        e.Handled = true;
    }

		}
		void Button3Click(object sender, EventArgs e)
		{
				
			if(textBox5.Text=="0"){
			
				MessageBox.Show("Pretul este 0",
    "Avertizare");
			try{
			string test=comboBox3.Text.ToString();
			String Pret="";
			String comb=dta.Rows[comboBox3.SelectedIndex][1].ToString();
				using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Programator_select_analizaPret", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("nr_crt_i", comb));
     con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pret=reader["Pret_Plata"].ToString();
                        }
                    }
    
				}		if (Pret!=textBox5.Text.ToString()){
			 listView1.Items.Add(new ListViewItem(new string[]{test, comb,textBox5.Text.ToString()}));
				}else
				{
						 listView1.Items.Add(new ListViewItem(new string[]{test, comb,Pret}));		
				}
			 listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			 listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}catch(Exception easd)
			{
				MessageBox.Show("Valoare incorecta",
    "Error");
				}
			
			}else{
			try{
			string test=comboBox3.Text.ToString();
			String Pret="";
			String comb=dta.Rows[comboBox3.SelectedIndex][1].ToString();
				using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Programator_select_analizaPret", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("nr_crt_i", comb));
     con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pret=reader["Pret_Plata"].ToString();
                        }
                    }
    
				}		if (Pret!=textBox5.Text.ToString()){
			 listView1.Items.Add(new ListViewItem(new string[]{test, comb,textBox5.Text.ToString()}));
				}else
				{
						 listView1.Items.Add(new ListViewItem(new string[]{test, comb,Pret}));		
				}
			 listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			 listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}catch(Exception easd)
			{
				MessageBox.Show("Valoare incorecta",
    "Error");
				}}
		}
		void Button4Click(object sender, EventArgs e)
		{
			foreach (ListViewItem eachItem in listView1.SelectedItems)
{
    listView1.Items.Remove(eachItem);
}
		}
		void Button2Click(object sender, EventArgs e)
		{
			//open new form
			//da nu
			//if
			double Calcul=0;
			//
				for (int a=0;a<listView1.Items.Count;a++)
    			{
					Calcul=Calcul+Double.Parse(listView1.Items[a].SubItems[2].Text);
				}
			
				MainForm.Suma=Calcul.ToString();
			
			//
			MessageAdauga DaNu= new MessageAdauga();
			DaNu.ShowDialog();
			if(MainForm.DaSiNu=="Da"){
			
			
			
			String resultCheck="";
			//check if exist
			using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("CheckProgramare;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("data1_i", new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, dateTimePicker1.Value.Hour,dateTimePicker1.Value.Minute,0).ToString("yyyy-MM-dd HH:mm:ss")));
    command.Parameters.Add(new MySqlParameter("Medic_i", MainForm.DoctorId[Int32.Parse(numeid)]));
    con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultCheck=reader["Data_Start"].ToString();
                        }
                    }
    
    }
			//insert
			if(resultCheck==""){
			using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("InsertDataInProgramare;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    command.Parameters.Add(new MySqlParameter("cod_intern_i", MainForm.DoctorId[Int32.Parse(numeid)]));
    command.Parameters.Add(new MySqlParameter("nume_i", new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, dateTimePicker1.Value.Hour,dateTimePicker1.Value.Minute,0).ToString("yyyy-MM-dd HH:mm:ss")));
    command.Parameters.Add(new MySqlParameter("cod_w_i", new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, dateTimePicker2.Value.Hour,dateTimePicker2.Value.Minute,0).ToString("yyyy-MM-dd HH:mm:ss")));
    command.Parameters.Add(new MySqlParameter("Numei_i", textBox1.Text.ToString()));
    if(textBox2.Text.ToString()==""){
     command.Parameters.Add(new MySqlParameter("Telefon_i", null));
    }else{
    command.Parameters.Add(new MySqlParameter("Telefon_i", textBox2.Text.ToString()));
    }
    command.Parameters.Add(new MySqlParameter("Mail_i", textBox3.Text.ToString()));
    command.Parameters.Add(new MySqlParameter("Observatie_i", textBox4.Text.ToString()));
    command.Parameters.Add(new MySqlParameter("AnalizaModTrimitere_i", comboBox1.SelectedValue.ToString()));
    
    con.Open();
    command.ExecuteNonQuery();
    //int result = (int)command.ExecuteScalar();
    
    }
			//get id
			String id_programare="";
			//insert in angajat_programator_detaliat
				         
        
            using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("cauta_max;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    command.Parameters.Add(new MySqlParameter("tabel", "angajati_programari"));
    command.Parameters.Add(new MySqlParameter("coloana",  "ID"));
   con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_programare=reader["max"].ToString();
                        }
                    }
    }
        
    
			for (int a=0;a<listView1.Items.Count;a++)
    {            
        
            using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("InsertDataInProgramare_Detaliat;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    
    command.Parameters.Add(new MySqlParameter("ID_lista_i", listView1.Items[a].SubItems[1].Text));
    command.Parameters.Add(new MySqlParameter("Nume_i",  listView1.Items[a].SubItems[0].Text));
    command.Parameters.Add(new MySqlParameter("Pret_i", listView1.Items[a].SubItems[2].Text));

     command.Parameters.Add(new MySqlParameter("ID_Programare_i",id_programare ));
    con.Open();
    command.ExecuteNonQuery();
    }
        
    }
			
			//add image in table
			string time1 = dateTimePicker1.Value.ToString("HH:mm");
			string time2 = dateTimePicker2.Value.ToString("HH:mm");
			int timeInt1;
			int timeInt2;
			//duration e ora de inceput in  pixeli
			  	var durationa=TimeSpan.Parse(Timestartp);
				var timespan1=TimeSpan.Parse(time1);
				var timespan2=TimeSpan.Parse(time2);
				var TimpResultStart=timespan1-durationa;
				var Marime=timespan2-timespan1;
				String marimefin=Marime.ToString().Replace(":", "");
			String timeFinal=TimpResultStart.ToString().Replace(":", "");
			int timp=Int32.Parse(timeFinal.Remove(timeFinal.Length-2));
			int marFin=Int32.Parse(marimefin.Remove(marimefin.Length-2));
			string[] words = Marime.ToString().Split(':');
			string[] wordas = TimpResultStart.ToString().Split(':');
			double total = (Convert.ToInt32(words[0]) * 60) + Convert.ToInt32(words[1]);
			double timeMarimea = (Convert.ToInt32(wordas[0]) * 60) + Convert.ToInt32(wordas[1]);
			total=(total/60)*100;
			timeMarimea=(timeMarimea/60)*100;
			int timeMarime=timp;
			Panel panel1=new Panel();
			Label Nume=new Label();
			Nume.ForeColor = Color.Yellow;
			Label Telefon=new Label();
			Label TipAsigurare=new Label();
			TipAsigurare.ForeColor = Color.Yellow;
			TipAsigurare.Click += new EventHandler(PanelClickModifica);
			TipAsigurare.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			TipAsigurare.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			TipAsigurare.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			TipAsigurare.Text=comboBox1.Text.ToString();
			Telefon.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			Telefon.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			Nume.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			Nume.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			Telefon.ForeColor = Color.Yellow;
			Nume.Text=textBox1.Text.ToString();
			Telefon.Text=textBox2.Text.ToString();
			panel1.Controls.Add(Telefon);
			Telefon.Dock=DockStyle.Right;
			Telefon.Click += new EventHandler(PanelClickModifica);
			Telefon.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			Nume.Click += new EventHandler(PanelClickModifica);
			Nume.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			panel1.Controls.Add(Nume);
			panel1.Controls.Add(TipAsigurare);
			TipAsigurare.Dock=DockStyle.Bottom;
			//TipAsigurare.Location=new Point(TipAsigurare.Location.Y+20,TipAsigurare.Location.X+20);
			TipAsigurare.BringToFront();
			panel1.Size = new Size(200, Convert.ToInt32(total));
			panel1.Name=numeid;
			panel1.BorderStyle=BorderStyle.FixedSingle;
			panel1.Location = new Point(panel1.Location.Y, panel1.Location.X+Convert.ToInt32(timeMarimea));
			panel1.BackColor=Color.Red;
			MainForm.PanelDoctori[Int32.Parse(numeid)].Controls.Add(panel1);
			panel1.BringToFront();
			Nume.BringToFront();
			panel1.Click += new EventHandler(PanelClickModifica);
			panel1.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			panel1.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			panel1.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			//insert
			//run casa marcat
			
			var process = Process.Start(@"c:/dep/dep_casa_marcat.exe");
			process.WaitForExit();
			//verifica rezultat
			if(File.Exists(@"c:/dep/eroare.txt")){
			string[] lines = File.ReadAllLines(@"c:/dep/eroare.txt", Encoding.UTF8);

        foreach (string line in lines) {
        
				if( line=="true")
				{
				}else
				{
					   using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("programari_salvare_casa_marcat;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
  
     command.Parameters.Add(new MySqlParameter("ID_Programare_i",id_programare ));
    con.Open();
    command.ExecuteNonQuery();
    }
				}
            
            
        }
			//schimba flag
			}else{};
			this.Close();
			}
			else
			{
				MessageBox.Show("Date Exista deja pentru perioada de timp introdusa",
    "Programare");
    }
			}else
			{
				
			}
		}
		void ComboBox2Leave(object sender, EventArgs e)
		{
	
		}
		void ComboBox2DropDownClosed(object sender, EventArgs e)
		{
			
		}
		void ComboBox3DropDownClosed(object sender, EventArgs e)
		{
	String comb=dta.Rows[comboBox3.SelectedIndex][1].ToString();
		using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Programator_select_analizaPret", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("nr_crt_i", comb));
     con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox5.Text=reader["Pret_Plata"].ToString();
                        }
                    }
    
    }
		}
		void Button5Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
