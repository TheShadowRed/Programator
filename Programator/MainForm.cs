/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 12/13/2017
 * Time: 14:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Programator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		System.Drawing.Point mousePosition;
	    DataGridView dataGrid;
        DataSet dataSet;
        Button button;
        public static MainForm MainSatic;
        public static String DaSiNu="";
        public static String Suma="";
        public string closethis="0";
        public static Panel panel3static;
 		public static Label a = new Label();
 		int sizeChanged=0;
 		int OldSize=0;
 		public static string username="";
 		public static string password="";
 		public static string ip="";
 		public static string baza="";
 		public static string numeTemp="";
 		public static string Intern="";
        public static Panel[] PanelDoctori;
        public static String[] TimpStartDoca;
        public static string pozitionAA;
        public static String[] TimpStopDoca;
        public static String[] TickPerDoctor;
        public static String timp;
        public static String[] DoctorId;
        public static String CurrentDoctorID;
        public static Panel[] PanelOre;
        public ToolTip yourToolTip;
        public static TextBox[] LabelDoctori;
        public static Panel[] PanelDoctoriExpanding;
        public static int counterPlus=0;
        public static String[] StringID;
        public static string oraStart;
        public static String CurrentSectie="";
        public int runonce=0;
        
        private List<string> MergedRowsInFirstColumn = new List<string>();
        private bool readyToMerge = false;
        
        
        private List<string> PlayerName = new List<string>();
        private List<Panel> Panels = new List<Panel>();
		
        public List<String> playersListbox;
        String maxTime="";
		String minTime="";
        
		String host;
		String nume;
		String parola;
		public static String myStringCon;
         
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			if(File.Exists(@"transfer.txt"))
			{
					//load file
			// Read the file and display it line by line.  
string[] lines = File.ReadAllLines("transfer.txt", Encoding.UTF8);

        foreach (string line in lines) {
        
            string[] words = line.Split(' ');
            username = words[0];
            password = words[1];
            ip = words[2];
            baza = words[3];
            //numele tabelui temp pentru a modifica
            numeTemp= words[4];
            Intern=words[5];
            
            
        }
        //filedelete
        if(File.Exists(@"transfer.txt"))
{
  //  File.Delete(@"transfer.txt");
}
			label1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label2.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			comboBox1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			dateTimePicker1.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			
			panel3static=panel3;
			setString();
			LoadInterface();
			LoadDoctori();
			loadOreOcupate();
			double round = 0.6;
			a.Text="asdsad";
			a.AutoSize = false;    
			a.TextAlign = ContentAlignment.MiddleCenter;
			a.BackColor = System.Drawing.Color.Transparent;
			panel3.Controls.Add(a);
			MainSatic=this;
			panel2.MouseEnter += new System.EventHandler(this.Panel5MouseEnter);
			panel2.MouseLeave += new System.EventHandler(this.Panel5MouseLeave);
			label3.Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
			label3.Enabled=false;
							
			panel2.Visible=false;
			}else{closethis="1";
				}
		
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public void loadOreOcupate()
		{
			
		
			//id id doctor
			//for in id 
			for(int counter =0;counter<counterPlus;counter++){
			//iau id doctor in for
			//pictez panelurie existente
					using (MySqlConnection con = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand command = new MySqlCommand("CheckDoctor;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("data1_i", DoctorId[counter]));
    command.Parameters.Add(new MySqlParameter("data2_i", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")));
    con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        	
         //add image in table
			string time1 = reader["Data_Start"].ToString();
			string[] words1 = time1.Split(' ');
			time1=words1[1];
			string time2 = reader["Data_End"].ToString();
			string[] words2 = time2.Split(' ');
			time2=words2[1];
			int timeInt2;
			//duration e ora de inceput in  pixeli
			var durationa=TimeSpan.Parse(TimpStartDoca[counter]);
				var timespan1=TimeSpan.Parse(time1);
				var timespan2=TimeSpan.Parse(time2);
				var TimpResultStart=timespan1-durationa;
				//TimpResultStart=TimpResultStart-TimpResultStart;
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
			Label TipAsigurare=new Label();
			TipAsigurare.ForeColor = Color.Yellow;
			TipAsigurare.Click += new EventHandler(PanelClickModifica);
			TipAsigurare.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			TipAsigurare.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			TipAsigurare.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			using (MySqlConnection conAsig = new MySqlConnection(MainForm.myStringCon))
    {
        MySqlCommand commandAsig = new MySqlCommand("Select_Tip_AsigSpecific;", conAsig);
    commandAsig.CommandType = System.Data.CommandType.StoredProcedure;
    commandAsig.Parameters.Add(new MySqlParameter("cod_i", reader["AnalizaModTrimitere"].ToString()));
    conAsig.Open();
         using (MySqlDataReader readerAsig = commandAsig.ExecuteReader())
                    {
                        while (readerAsig.Read())
                        {
                            TipAsigurare.Text=readerAsig["Nume"].ToString();
                        }
                    }
    
    }
			Nume.ForeColor = Color.Yellow;
			Nume.Text=reader["Nume"].ToString();
			panel1.Controls.Add(Nume);
			panel1.Controls.Add(TipAsigurare);
			TipAsigurare.Dock=DockStyle.Bottom;
			//TipAsigurare.Location=new Point(TipAsigurare.Location.Y+20,TipAsigurare.Location.X+20);
			TipAsigurare.BringToFront();
			Label Telefon=new Label();
			Telefon.ForeColor = Color.Yellow;
			Telefon.Click += new EventHandler(PanelClickModifica);
			Telefon.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			Telefon.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			Telefon.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			Nume.Click += new EventHandler(PanelClickModifica);
			Nume.MouseMove+= new MouseEventHandler(MainForm.MainFormMouseMoveAA);
			Nume.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			Nume.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			Telefon.Text=reader["Telefon"].ToString();
			
			panel1.Controls.Add(Telefon);
			Telefon.Dock=DockStyle.Right;
			panel1.Size = new Size(200, Convert.ToInt32(total));
			panel1.BorderStyle=BorderStyle.FixedSingle;
			panel1.Name=counter.ToString();
			//add sicechangefunctions
			panel1.MouseEnter += new System.EventHandler(this.Panel3MouseEnter);
			panel1.MouseLeave += new System.EventHandler(this.Panel3MouseLeave);
			panel1.Location = new Point(panel1.Location.Y, panel1.Location.X+Convert.ToInt32(timeMarimea));
			String Culoare=reader["Stare"].ToString();
			if(Culoare=="1")
			{
				panel1.BackColor=Color.MediumBlue;
			}else{
				panel1.BackColor=Color.Red;
			}
			PanelDoctori[counter].Controls.Add(panel1);
			panel1.BringToFront();
			Nume.BringToFront();
                        }
                    }
					}
    
    }
		}
		public void LoadSectie()
		{
			comboBox1.BringToFront();
			Dictionary<string, string>SectiiCombobox = new Dictionary<string, string>();
			SectiiCombobox.Add("Toate", "Toate");
			using (MySqlConnection con = new MySqlConnection(myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Programator_select_sectii;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String nr_crt=reader["nr_crt"].ToString();
                            String Sectie=reader["sectie"].ToString();
                             SectiiCombobox.Add(nr_crt, Sectie);
                        }
                    }
    
    }
			comboBox1.DataSource = new BindingSource(SectiiCombobox, null);
        comboBox1.DisplayMember = "Value";
        comboBox1.ValueMember = "Key";
			
		}
		public void LoadInterface()
		{
			//load box with sectii
			if(runonce==0){
				runonce=1;
			LoadSectie();
			}
			dateTimePicker1.BringToFront();
			int r = (int)dateTimePicker1.Value.DayOfWeek;
			r++;
			if(r==1){}else{
				
			using (MySqlConnection con = new MySqlConnection(myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Select_ore;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.Parameters.Add(new MySqlParameter("id_i", r));
    con.Open();
         using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maxTime=reader["Ore_stop"].ToString();
                            minTime=reader["Ora_start"].ToString();
                            if(minTime==""){}else{
                            oraStart=minTime;
                            }
                        }
                    }
    
    }
			//try{
        	string[] words = minTime.Split(':');
        	int StartHour=Int32.Parse(words[0]);
        	int StartMIn=Int32.Parse(words[1]);
        	string[] maxT = maxTime.Split(':');
        	int endhour=Int32.Parse(maxT[0])-StartHour;
        	int endMinute=Int32.Parse(maxT[1]);
			for(int a = 0;a<=endhour;a++)
			{
				int b=StartHour+a;
				int location=a*100;
				Label LabelOra=new Label();
				LabelOra.Text=b.ToString()+":"+StartMIn.ToString();
				LabelOra.Size = new Size(40, 40);
				LabelOra.Location = new Point(0, location);
				LabelOra.Font=new Font(label1.Font.Name, 8, FontStyle.Bold);
				panel3.Controls.Add(LabelOra);
			}
				
			//}catch(Exception e)
			//{
				
			//}
		
			
			
			
			
			
			}
			
			
		}
		public void LoadDoctori()
		{
			int r = (int)dateTimePicker1.Value.DayOfWeek;
			r++;
			int nrDocotriDinZi=0;
			//get nr Doctori
			using (MySqlConnection con = new MySqlConnection(myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Select_angajati_count;", con);
        command.Parameters.Add(new MySqlParameter("Sectii_i", CurrentSectie));
    command.CommandType = System.Data.CommandType.StoredProcedure;

    // Add your parameters here if you need them
    //command.Parameters.Add(new MySqlParameter("id_auto_i", id_auto));
    con.Open();
    using (MySqlDataReader reader = command.ExecuteReader())
                    {
    		
                        while (reader.Read())
                        {
                        	nrDocotriDinZi=Int32.Parse(reader["numarAngajati"].ToString());
                        	counterPlus=nrDocotriDinZi;
                        }
    				}
	}
			PanelDoctoriExpanding=new Panel[nrDocotriDinZi];
			DoctorId = new string[nrDocotriDinZi];
			TickPerDoctor= new string[nrDocotriDinZi];
			PanelDoctori=new Panel[nrDocotriDinZi];
			TimpStartDoca=new string[nrDocotriDinZi];
			TimpStopDoca=new string[nrDocotriDinZi];
			LabelDoctori=new TextBox[nrDocotriDinZi];
			StringID=new string[nrDocotriDinZi];
			int InitialPoz=40;
			int InitialCounter=0;
			//Load Data
			using (MySqlConnection con = new MySqlConnection(myStringCon))
    {
        MySqlCommand command = new MySqlCommand("Select_angajati;", con);
        
        command.Parameters.Add(new MySqlParameter("Sectii_i", CurrentSectie));
    command.CommandType = System.Data.CommandType.StoredProcedure;

    // Add your parameters here if you need them
    command.Parameters.Add(new MySqlParameter("id_i", r));
    con.Open();
    using (MySqlDataReader reader = command.ExecuteReader())
                    {
    		
                        while (reader.Read())
                        {
                        	Label Programati;
                        	Label Veniti;
                        	Label Ramasi;
                        	var TimpStartProg=TimeSpan.Parse(minTime);
							var TimpStartDoc=TimeSpan.Parse(reader["Ora_start"].ToString());
							TimpStartDoca[InitialCounter] = TimpStartDoc.ToString();
							var TimpResultStart=TimpStartDoc-TimpStartProg;
							//get new start size
							String TimpStartDif=TimpResultStart.ToString();
							string[] words = TimpStartDif.Split(':');
							int initialpozMax=Int32.Parse(words[0])*100;
							int initialPoz=(Int32.Parse(words[1])*100)/60;
							initialpozMax=initialpozMax+initialPoz;
							//get finish size
							var TimpStopDoc=TimeSpan.Parse(reader["Ora_stop"].ToString());
							TimpStopDoca[InitialCounter] = TimpStopDoc.ToString();
							var TimpResultstop=TimpStopDoc-TimpStartDoc;
							String TimpMax=TimpResultstop.ToString();
							string[] word = TimpMax.Split(':');
							int maxhour=Int32.Parse(word[0])*100;
							int maxmin=(Int32.Parse(word[1])*100)/60;
							maxhour=maxhour+maxmin;
							if(reader["pas"].ToString()=="")
							{
								TickPerDoctor[InitialCounter]="15";
							}else
							{
							TickPerDoctor[InitialCounter]=reader["pas"].ToString();
							}
							PanelDoctori[InitialCounter]=new Panel();
                        	PanelDoctoriExpanding[InitialCounter]=new Panel();
							LabelDoctori[InitialCounter]=new TextBox();
							PanelDoctori[InitialCounter].Location=new Point(InitialPoz,initialpozMax);
							PanelDoctori[InitialCounter].Size = new Size(200, maxhour);
							PanelDoctori[InitialCounter].BackColor=Color.LightGray;
							PanelDoctori[InitialCounter].Name=InitialCounter.ToString();
							PanelDoctoriExpanding[InitialCounter].Location=new Point(InitialPoz,0);
							PanelDoctoriExpanding[InitialCounter].Name=InitialCounter.ToString();
							//LabelDoctori[InitialCounter].Location=new Point(InitialPoz,0);
							LabelDoctori[InitialCounter].Size = new Size(199, 49);
							//select doctori ore
							Programati= new Label();
							Veniti= new Label();
							Ramasi= new Label();
							using (MySqlConnection conDocRap = new MySqlConnection(myStringCon))
    {
        MySqlCommand commandDocRap = new MySqlCommand("Programator_select_raport;", conDocRap);
        commandDocRap.Parameters.Add(new MySqlParameter("data_i", dateTimePicker1.Value.ToString("yyyy-MM-dd")));
        commandDocRap.Parameters.Add(new MySqlParameter("id_medic_i", reader["ID_angajat"].ToString()));
    commandDocRap.CommandType = System.Data.CommandType.StoredProcedure;

    // Add your parameters here if you need them
    //command.Parameters.Add(new MySqlParameter("id_auto_i", id_auto));
    conDocRap.Open();
    using (MySqlDataReader readerDocRap = commandDocRap.ExecuteReader())
                    {
    		
                        while (readerDocRap.Read())
                        {
                        	
                        	Programati.Text="Programati azi :"+readerDocRap["programati"].ToString();
                        	
                        	Veniti.Text="Veniti azi :"+readerDocRap["veniti"].ToString();
                        	
                        	Ramasi.Text="Ramasi sa vina :"+readerDocRap["ramasi"].ToString();
                        	
                        	
                        }
    				}
	}
							Programati.Location=new Point(0,50);
							Programati.ForeColor=Color.Red;
							Veniti.Location=new Point(0,80);
							Veniti.ForeColor=Color.MediumBlue;
							Ramasi.Location=new Point(0,110);
							PanelDoctoriExpanding[InitialCounter].Size = new Size(200, 50);
							PanelDoctoriExpanding[InitialCounter].MouseEnter += new System.EventHandler(this.Panel4MouseEnter);
							PanelDoctoriExpanding[InitialCounter].MouseLeave += new System.EventHandler(this.Panel4MouseLeave);
							LabelDoctori[InitialCounter].Multiline=true;
							LabelDoctori[InitialCounter].ReadOnly=true;
							
							//LabelDoctori[InitialCounter].Enabled=false;
							LabelDoctori[InitialCounter].MouseEnter += new System.EventHandler(this.Panel4MouseEnter);
							LabelDoctori[InitialCounter].MouseLeave += new System.EventHandler(this.Panel4MouseLeave);
							
							LabelDoctori[InitialCounter].MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel5MouseClick);
							LabelDoctori[InitialCounter].Text=reader["nume"].ToString()+" "+reader["prenume"].ToString();
							LabelDoctori[InitialCounter].Font=new Font(label1.Font.Name, 12, FontStyle.Bold);
							DoctorId[InitialCounter]=reader["ID_angajat"].ToString();
							PanelDoctori[InitialCounter].Click += new EventHandler(PanelClick);
							PanelDoctori[InitialCounter].MouseMove+= new MouseEventHandler(Panel3MouseMove);
							panel1.Controls.Add(PanelDoctoriExpanding[InitialCounter]);
							PanelDoctoriExpanding[InitialCounter].Controls.Add(LabelDoctori[InitialCounter]);
							PanelDoctoriExpanding[InitialCounter].Controls.Add(Programati);
							PanelDoctoriExpanding[InitialCounter].Controls.Add(Veniti);
							PanelDoctoriExpanding[InitialCounter].Controls.Add(Ramasi);
							panel3.Controls.Add(PanelDoctori[InitialCounter]);
							StringID[InitialCounter]=reader["nr_crt"].ToString();
							InitialCounter=InitialCounter+1;
							InitialPoz=InitialPoz+205;
                        }
    				}
	}
			
		}
		public void setString()
		{
		baza=baza;
		host=ip;
		nume=username;
		parola=password;
		myStringCon = "SERVER=" + host + ";" +
                 "DATABASE=" + baza + ";" +
                 "UID=" + nume + "; PASSWORD=" + parola + " " + ";pooling=true;Allow Zero Datetime=True;Min Pool Size=1; Max Pool Size=100; default command timeout=120";
      
		}
		private void CreateGridAndButton()
        {
            dataGrid = new DataGridView();
            dataSet = new DataSet();
 
            dataGrid.Height = this.Height - 100;
            dataGrid.Dock = DockStyle.Top;
            dataGrid.ReadOnly = true;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.RowHeadersVisible = false;
            this.dataGrid.Paint += new PaintEventHandler(dataGrid_Paint);
            
            this.Controls.Add(this.dataGrid);
 
            button = new Button();
            button.Text = "Merge";
            button.Dock = DockStyle.Bottom;
            button.Click += new System.EventHandler(this.button_Click);
 
            this.Controls.Add(this.button);
            
		DataTable tbl_main = new DataTable("tbl_main");
			using (MySqlConnection con = new MySqlConnection(myStringCon))
    {
        MySqlCommand command = new MySqlCommand("programator;", con);
    command.CommandType = System.Data.CommandType.StoredProcedure;

    // Add your parameters here if you need them
    //command.Parameters.Add(new MySqlParameter("id_auto_i", id_auto));
    con.Open();
    using (MySqlDataReader reader = command.ExecuteReader())
                    {
    		
 
            tbl_main.Columns.Add("timp");
            tbl_main.Columns.Add("nume1");
            tbl_main.Columns.Add("nume2");
 
            DataRow row;
                        while (reader.Read())
                        {
                        	row = tbl_main.NewRow();
                        	row["timp"] = reader["timp"].ToString();
                        	//row["nume1"] = reader["nume1"].ToString();
                        	//row["nume2"] = reader["nume2"].ToString();
            				//row["timp"] = "timp";
                        	row["nume1"] = "nume1";
                        	row["nume2"] = "nume2";
            				
                        	tbl_main.Rows.Add(row);
                        }
    				}
    
    }

            dataSet.Tables.Add(tbl_main);
            dataGrid.DataSource = dataSet;
            dataGrid.RowTemplate.Height = 10;
            dataGrid.DataMember = "tbl_main";
            
        }
		private void dataGrid_Paint(object sender, PaintEventArgs e)
        {
            if (readyToMerge)
            {
                Merge();
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Merge();
            readyToMerge = true;
        }
        private bool isSelectedCell(int[] Rows, int ColumnIndex)
        {
            if (dataGrid.SelectedCells.Count > 0)
            {
                for (int iCell = Rows[0]; iCell <= Rows[1]; iCell++)
                {
                    for (int iSelCell = 0; iSelCell < dataGrid.SelectedCells.Count; iSelCell++)
                    {
                    	
  if (dataGrid.Rows[iCell].Cells[ColumnIndex] == dataGrid.SelectedCells[iSelCell])
                        {
                            return true;
                        }

                        
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        private void Merge()
        {
            int[] RowsToMerge = new int[2];
            RowsToMerge[0] = -1;
 
            //Merge first column at first
            for (int i = 0; i < dataSet.Tables["tbl_main"].Rows.Count - 1; i++)
            {
                if (dataSet.Tables["tbl_main"].Rows[i]["nume2"] == dataSet.Tables["tbl_main"].Rows[i + 1]["nume2"])
                {
                    if (RowsToMerge[0] == -1)
                    {
                        RowsToMerge[0] = i;
                        RowsToMerge[1] = i + 1;
                    }
                    else
                    {
                        RowsToMerge[1] = i + 1;
                    }
                }
                else
                {
                    MergeCells(RowsToMerge[0], RowsToMerge[1], dataGrid.Columns["nume2"].Index, isSelectedCell(RowsToMerge, dataGrid.Columns["nume2"].Index) ? true : false);
                    CollectMergedRowsInFirstColumn(RowsToMerge[0], RowsToMerge[1]);
                    RowsToMerge[0] = -1;
                }
                if (i == dataSet.Tables["tbl_main"].Rows.Count - 2)
                {
                    MergeCells(RowsToMerge[0], RowsToMerge[1], dataGrid.Columns["nume2"].Index, isSelectedCell(RowsToMerge, dataGrid.Columns["nume2"].Index) ? true : false);
                    CollectMergedRowsInFirstColumn(RowsToMerge[0], RowsToMerge[1]);
                    RowsToMerge[0] = -1;
                }
            }
            if (RowsToMerge[0] != -1)
            {
                MergeCells(RowsToMerge[0], RowsToMerge[1], dataGrid.Columns["nume2"].Index, isSelectedCell(RowsToMerge, dataGrid.Columns["nume2"].Index) ? true : false);
                RowsToMerge[0] = -1;
            }
 
            //merge all other columns
            for (int iColumn = 1; iColumn < dataSet.Tables["tbl_main"].Columns.Count - 1; iColumn++)
            {
                for (int iRow = 0; iRow < dataSet.Tables["tbl_main"].Rows.Count - 1; iRow++)
                {
                    if ((dataSet.Tables["tbl_main"].Rows[iRow][iColumn] == dataSet.Tables["tbl_main"].Rows[iRow + 1][iColumn]) &&
                         (isRowsHaveOneCellInFirstColumn(iRow, iRow + 1)))
                    {
                        if (RowsToMerge[0] == -1)
                        {
                            RowsToMerge[0] = iRow;
                            RowsToMerge[1] = iRow + 1;
                        }
                        else
                        {
                            RowsToMerge[1] = iRow + 1;
                        }
                    }
                    else
                    {
                        if (RowsToMerge[0] != -1)
                        {
                            MergeCells(RowsToMerge[0], RowsToMerge[1], iColumn, isSelectedCell(RowsToMerge, iColumn) ? true : false);
                            RowsToMerge[0] = -1;
                        }
                    }
                }
                if (RowsToMerge[0] != -1)
                {
                    MergeCells(RowsToMerge[0], RowsToMerge[1], iColumn, isSelectedCell(RowsToMerge, iColumn) ? true : false);
                    RowsToMerge[0] = -1;
                }
            }
        }
        private bool isRowsHaveOneCellInFirstColumn(int RowId1, int RowId2)
        {
 
            foreach (string rowsCollection in MergedRowsInFirstColumn)
            {
                string[] RowsNumber = rowsCollection.Split(';');
 
                if ((isStringInArray(RowsNumber,RowId1.ToString())) &&
                    (isStringInArray(RowsNumber,RowId2.ToString())))
                {
                    return true;
                }
            }
            return false;
        }
        private bool isStringInArray(string[] Array, string value)
        {
            foreach (string item in Array)
            {
                if (item == value)
                {
                    return true;
                } 
                
            }
            return false;
        }
        private void CollectMergedRowsInFirstColumn(int RowId1, int RowId2)
        {
            string MergedRows = String.Empty;
 
            for (int i = RowId1; i <= RowId2; i++)
            {
                MergedRows += i.ToString() + ";";
            }
            MergedRowsInFirstColumn.Add(MergedRows.Remove(MergedRows.Length - 1, 1));
        }
        private void MergeCells(int RowId1, int RowId2, int Column, bool isSelected)
        {
            Graphics g = dataGrid.CreateGraphics();
            Pen gridPen = new Pen(dataGrid.GridColor);
 
            //Cells Rectangles
            Rectangle CellRectangle1 = dataGrid.GetCellDisplayRectangle(Column, RowId1, true);
            Rectangle CellRectangle2 = dataGrid.GetCellDisplayRectangle(Column, RowId2, true);
 
            int rectHeight = 0;
            string MergedRows= String.Empty;
 
            for (int i = RowId1; i <= RowId2; i++)
            {
                rectHeight += dataGrid.GetCellDisplayRectangle(Column, i, false).Height;
            }
 
            Rectangle newCell = new Rectangle(CellRectangle1.X, CellRectangle1.Y, CellRectangle1.Width, rectHeight);
 
            g.FillRectangle(new SolidBrush(isSelected ? dataGrid.DefaultCellStyle.SelectionBackColor : dataGrid.DefaultCellStyle.BackColor), newCell);
 
            g.DrawRectangle(gridPen, newCell);
 
            g.DrawString(dataGrid.Rows[RowId1].Cells[Column].Value.ToString(), dataGrid.DefaultCellStyle.Font, new SolidBrush(isSelected? dataGrid.DefaultCellStyle.SelectionForeColor: dataGrid.DefaultCellStyle.ForeColor), newCell.X + newCell.Width / 3, newCell.Y + newCell.Height / 3 );
        }
        public void loadListWithApoointedTime()
        {
        	
        }
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		void PanelClick(object sender, EventArgs e)
		{
			 var panel = sender as Panel;
			 int Counter=Int32.Parse(panel.Name);
			  Point point = panel.PointToClient(Cursor.Position);
			  String pozition = point.ToString();
			 
			 AdaugaProgramare f2 = new AdaugaProgramare(panel.Name,TimpStartDoca[Counter],TimpStopDoca[Counter],TickPerDoctor[Counter],pozition,a.Text,dateTimePicker1.Value);
			f2.ShowDialog();
		}
		public static void  PanelClickModifica(object sender, EventArgs e)
		{
			
			 var panel = sender as Panel;
			 if(panel==null)
			 {
			 	var label=sender as Label;
			 	panel=label.Parent as Panel;
			 }
			 int Counter=Int32.Parse(panel.Name);
			  Point point = panel.PointToClient(Cursor.Position);
			  String pozition = point.ToString();
			 
			 ModificaProgramare f2 = new ModificaProgramare(panel.Name,TimpStartDoca[Counter],TimpStopDoca[Counter],TickPerDoctor[Counter],pozition,a.Text,MainSatic.dateTimePicker1.Value);
			f2.ShowDialog();
		}
		void Panel1Click(object sender, EventArgs e)
		{

		}
		void Panel2MouseMove(object sender, MouseEventArgs e)
		{
		
		}
		public static void MainFormMouseMoveAA(object sender, MouseEventArgs e)
		{
			string[] words = oraStart.Split(':');
			double total = (Convert.ToInt32(words[0]) * 60) + Convert.ToInt32(words[1]);
			Point point = MainForm.panel3static.PointToClient(Cursor.Position);
			double addaos=point.Y*0.6;
			total=total+addaos;
			point.X=point.X-105;
			a.Location=(point);
			a.BackColor = System.Drawing.Color.Transparent;
			var MinutesFromDB = Convert.ToInt32(total);
			TimeSpan timeSpan = TimeSpan.FromMinutes(MinutesFromDB);
			a.Text=timeSpan.ToString(@"hh\:mm");
			timp=timeSpan.ToString(@"hh\:mm");
			a.BringToFront();
			pozitionAA = point.ToString();
		}
		void MainFormMouseMove(object sender, MouseEventArgs e)
		{
			try{
			string[] words = oraStart.Split(':');
			double total = (Convert.ToInt32(words[0]) * 60) + Convert.ToInt32(words[1]);
			Point point = MainForm.panel3static.PointToClient(Cursor.Position);
			double addaos=point.Y*0.6;
			total=total+addaos;
			point.X=point.X-105;
			a.Location=(point);
			a.BackColor = System.Drawing.Color.Transparent;
			var MinutesFromDB = Convert.ToInt32(total);
			TimeSpan timeSpan = TimeSpan.FromMinutes(MinutesFromDB);
			a.Text=timeSpan.ToString(@"hh\:mm");
			timp=timeSpan.ToString(@"hh\:mm");
			a.BringToFront();
			}catch(Exception ea)
			{
				
			}
		}
		void MainFormMouseHover(object sender, EventArgs e)
		{

		}
		void Panel3MouseHover(object sender, EventArgs e)
		{
			
		}
		void Panel3MouseMove(object sender, MouseEventArgs e)
		{
			try{
			string[] words = oraStart.Split(':');
			double total = (Convert.ToInt32(words[0]) * 60) + Convert.ToInt32(words[1]);
			Point point = panel3.PointToClient(Cursor.Position);
			double addaos=point.Y*0.6;
			total=total+addaos;
			point.X=point.X-105;
			a.Location=(point);
			a.BackColor = System.Drawing.Color.Transparent;
			var MinutesFromDB = Convert.ToInt32(total);
			TimeSpan timeSpan = TimeSpan.FromMinutes(MinutesFromDB);
			a.Text=timeSpan.ToString(@"hh\:mm");
			timp=timeSpan.ToString(@"hh\:mm");
			a.BringToFront();
			}catch(Exception eas)
			{
				
			}
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
		void Panel4MouseEnter(object sender, EventArgs e)
		{
			
			 
			var panel = sender as Panel;
			if(panel==null)
			 {
				var label=sender as TextBox;
			 	panel=label.Parent as Panel;
				panel.Size= new Size(panel.Size.Width, 150);
				panel.BringToFront();
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel1.BringToFront();
				panel1.Size=new Size(panel1.Size.Width,150);
			}else
			{
				panel.Size= new Size(panel.Size.Width, 150);
				panel.BringToFront();
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel1.BringToFront();
				panel1.Size=new Size(panel1.Size.Width,150);
			}
			
		}
		void Panel5MouseClick(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if(panel==null)
			 {
				var label=sender as TextBox;
			 	panel=label.Parent as Panel;
			 	int counter=Int32.Parse(panel.Name.ToString());
			 	CurrentDoctorID=DoctorId[counter].ToString();
				
			}else
			{
				int counter=Int32.Parse(panel.Name.ToString());
				CurrentDoctorID=DoctorId[counter].ToString();
			}
				
			
		}
		void Panel5MouseEnter(object sender, EventArgs e)
		{
			
				panel2.Size= new Size(555, 1500);
				panel2.BringToFront();
			
		}
		void Panel5MouseLeave(object sender, EventArgs e)
		{
			panel2.Size= new Size(555, 39);
				panel2.BringToFront();
			
		}
		void Panel4MouseLeave(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if(panel==null)
			 {
				var label=sender as TextBox;
			 	panel=label.Parent as Panel;
				panel.Size= new Size(panel.Size.Width, 50);
				panel.BringToFront();
				panel.BorderStyle = BorderStyle.None;
				panel1.BringToFront();
				panel1.Size=new Size(panel1.Size.Width,50);
			}else
			{
				panel.Size= new Size(panel.Size.Width, 50);
				panel.BringToFront();
				panel.BorderStyle = BorderStyle.None;
				panel1.BringToFront();
				panel1.Size=new Size(panel1.Size.Width,50);
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
		void DateTimePicker1CloseUp(object sender, EventArgs e)
		{
			try{
			panel1.Controls.Clear();
			panel3.Controls.Clear();
			panel3static=panel3;
			//setString();
			LoadInterface();
			LoadDoctori();
			loadOreOcupate();
			a.Text="asdsad";
			a.AutoSize = false;    
			a.TextAlign = ContentAlignment.MiddleCenter;
			a.BackColor = System.Drawing.Color.Transparent;
			panel3.Controls.Add(a);
			}catch(Exception esd)
			{
			}
		}
		void MainFormActivated(object sender, EventArgs e)
		{
			//try{
			panel1.Controls.Clear();
	panel3.Controls.Clear();
			panel3static=panel3;
			//setString();
			LoadInterface();
			LoadDoctori();
			loadOreOcupate();
			
			a.Text="asdsad";
			a.AutoSize = false;    
			a.TextAlign = ContentAlignment.MiddleCenter;
			a.BackColor = System.Drawing.Color.Transparent;
			panel3.Controls.Add(a);
			//}catch(Exception esd)
			//{
			//}
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			//try{
			CurrentSectie=((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
			panel1.Controls.Clear();
			panel3.Controls.Clear();
			panel3static=panel3;
			//setString();
			LoadInterface();
			LoadDoctori();
			loadOreOcupate();
			a.Text="asdsad";
			a.AutoSize = false;    
			a.TextAlign = ContentAlignment.MiddleCenter;
			a.BackColor = System.Drawing.Color.Transparent;
			panel3.Controls.Add(a);
			//}catch(Exception esd)
			//{
			//}
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			if(closethis=="1"){this.Close();}
		}
	}
}
