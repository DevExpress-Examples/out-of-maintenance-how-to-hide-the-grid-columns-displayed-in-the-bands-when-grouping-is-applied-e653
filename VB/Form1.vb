Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms

Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid

Namespace HideGrouped
	Public Class Form1
		Inherits System.Windows.Forms.Form

	#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call

		End Sub

		'Form overrides dispose to clean up the component list.
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		Friend gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
		Friend gridControl1 As DevExpress.XtraGrid.GridControl
		Friend WithEvents advBandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.advBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.advBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'gridBand1
			'
			Me.gridBand1.Caption = "gridBand1"
			Me.gridBand1.Name = "gridBand1"
			'
			'gridControl1
			'
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.advBandedGridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(821, 513)
			Me.gridControl1.TabIndex = 7
			Me.gridControl1.UseEmbeddedNavigator = True
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.advBandedGridView1})
			'
			'advBandedGridView1
			'
			Me.advBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand1})
			Me.advBandedGridView1.GridControl = Me.gridControl1
			Me.advBandedGridView1.Name = "advBandedGridView1"
			'
			'Form1
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(821, 513)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "How to hide the grid columns displayed in the bands when grouping is applied"
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.advBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
'			advBandedGridView1.EndGrouping += New System.EventHandler(advBandedGridView1_EndGrouping);
'			MyBase.Load += New System.EventHandler(Form1_Load);

		End Sub

	#End Region
	#Region " Init "
		Private Sub InitData()
			Dim DBFileName As String = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\Cars.xml")
			If DBFileName <> "" Then
				Dim dataSet As New DataSet()
				dataSet.ReadXml(DBFileName)
				gridControl1.DataSource = dataSet.Tables(0).DefaultView
			End If
		End Sub

		Private Sub InitViewLayout()
			Dim LayoutFileName As String = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\Layouts\cars_AdvBandedView.xml")
			If LayoutFileName <> "" Then
				InitEditors()
				advBandedGridView1.RestoreLayoutFromXml(LayoutFileName)
			End If
		End Sub

		Private Sub InitEditors()
			Dim itemPictureEdit As New RepositoryItemPictureEdit()
			Dim itemRadioGroup As New RepositoryItemRadioGroup()
			Dim itemSpinEdit As New RepositoryItemSpinEdit()
			Dim itemCalcEdit As New RepositoryItemCalcEdit()
			Dim itemImageComboBox As New RepositoryItemImageComboBox()
			itemPictureEdit.Name = "repositoryItemPictureEdit1"
			itemSpinEdit.Name = "repositoryItemSpinEdit1"
			itemCalcEdit.Name = "repositoryItemCalcEdit1"
			itemRadioGroup.Name = "repositoryItemRadioGroup1"
			itemImageComboBox.Name = "repositoryItemImageComboBox1"
			itemImageComboBox.Items.AddRange(New Object() { New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Sports", "SPORTS", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Saloon", "SALOON", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Truck", "TRUCK", -1)})
			itemRadioGroup.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() { New DevExpress.XtraEditors.Controls.RadioGroupItem("Yes", "Yes"), New DevExpress.XtraEditors.Controls.RadioGroupItem("No", "No")})
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { itemPictureEdit, itemRadioGroup, itemSpinEdit, itemCalcEdit, itemImageComboBox})
		End Sub
	#End Region

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			InitData()
			InitViewLayout()
		End Sub

		Private Sub advBandedGridView1_EndGrouping(ByVal sender As Object, ByVal e As System.EventArgs) Handles advBandedGridView1.EndGrouping
			Dim View As AdvBandedGridView = Nothing
			View = CType(sender, AdvBandedGridView)
			For Each Column As BandedGridColumn In View.GroupedColumns
				Column.OwnerBand = Nothing
			Next Column
		End Sub

		<STAThread> _
		Shared Sub Main()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub

	End Class

End Namespace 'end of root namespace