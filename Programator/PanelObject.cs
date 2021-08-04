/*
 * Created by SharpDevelop.
 * User: TheRedLord
 * Date: 12/19/2017
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Programator
{
	/// <summary>
	/// Description of PanelObject.
	/// </summary>
	public class PanelObject
	{
		private String OraConsultatie;
		private String NumePacient;
		private String PrenumePacient;
		private int Stare;
		public PanelObject(String NumePacientIn,String PrenumePacientIn,String OraConsultatieIn,int StareIN)
		{
			this.OraConsultatie=OraConsultatieIn;
			this.NumePacient=NumePacientIn;
			this.PrenumePacient=PrenumePacientIn;
			this.Stare=StareIN;
		}
		
	}
}
