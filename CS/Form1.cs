using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace HideGrouped
{
	public class Form1 : System.Windows.Forms.Form
	{

	#region  Windows Form Designer generated code 

		public Form1() : base()
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call

		}

		//Form overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		internal DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		internal DevExpress.XtraGrid.GridControl gridControl1;
		internal DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
			((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.advBandedGridView1).BeginInit();
			this.SuspendLayout();
			//
			//gridBand1
			//
			this.gridBand1.Caption = "gridBand1";
			this.gridBand1.Name = "gridBand1";
			//
			//gridControl1
			//
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.advBandedGridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(821, 513);
			this.gridControl1.TabIndex = 7;
			this.gridControl1.UseEmbeddedNavigator = true;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {this.advBandedGridView1});
			//
			//advBandedGridView1
			//
			this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {this.gridBand1});
			this.advBandedGridView1.GridControl = this.gridControl1;
			this.advBandedGridView1.Name = "advBandedGridView1";
			//
			//Form1
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(821, 513);
			this.Controls.Add(this.gridControl1);
			this.Name = "Form1";
			this.Text = "How to hide the grid columns displayed in the bands when grouping is applied";
			((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.advBandedGridView1).EndInit();
			this.ResumeLayout(false);
			advBandedGridView1.EndGrouping += new System.EventHandler(advBandedGridView1_EndGrouping);
			base.Load += new System.EventHandler(Form1_Load);

		}

	#endregion
	#region  Init 
		private void InitData()
		{
			string DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\\Cars.xml");
			if (DBFileName != "")
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(DBFileName);
				gridControl1.DataSource = dataSet.Tables[0].DefaultView;
			}
		}

		private void InitViewLayout()
		{
			string LayoutFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\\Layouts\\cars_AdvBandedView.xml");
			if (LayoutFileName != "")
			{
				InitEditors();
				advBandedGridView1.RestoreLayoutFromXml(LayoutFileName);
			}
		}

		private void InitEditors()
		{
			RepositoryItemPictureEdit itemPictureEdit = new RepositoryItemPictureEdit();
			RepositoryItemRadioGroup itemRadioGroup = new RepositoryItemRadioGroup();
			RepositoryItemSpinEdit itemSpinEdit = new RepositoryItemSpinEdit();
			RepositoryItemCalcEdit itemCalcEdit = new RepositoryItemCalcEdit();
			RepositoryItemImageComboBox itemImageComboBox = new RepositoryItemImageComboBox();
			itemPictureEdit.Name = "repositoryItemPictureEdit1";
			itemSpinEdit.Name = "repositoryItemSpinEdit1";
			itemCalcEdit.Name = "repositoryItemCalcEdit1";
			itemRadioGroup.Name = "repositoryItemRadioGroup1";
			itemImageComboBox.Name = "repositoryItemImageComboBox1";
			itemImageComboBox.Items.AddRange(new object[] { new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Sports", "SPORTS", -1), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Saloon", "SALOON", -1), new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Truck", "TRUCK", -1)});
			itemRadioGroup.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] { new DevExpress.XtraEditors.Controls.RadioGroupItem("Yes", "Yes"), new DevExpress.XtraEditors.Controls.RadioGroupItem("No", "No")});
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { itemPictureEdit, itemRadioGroup, itemSpinEdit, itemCalcEdit, itemImageComboBox});
		}
	#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{
			InitData();
			InitViewLayout();
		}

		private void advBandedGridView1_EndGrouping(object sender, System.EventArgs e)
		{
			AdvBandedGridView View = null;
			View = (AdvBandedGridView)sender;
			foreach (BandedGridColumn Column in View.GroupedColumns)
			{
				Column.OwnerBand = null;
			}
		}

		[STAThread]
		static void Main()
		{
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

	}

} //end of root namespace