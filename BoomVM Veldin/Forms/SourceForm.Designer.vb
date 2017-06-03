<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SourceForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SourceForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAddSource = New System.Windows.Forms.Button()
        Me.txtDomain = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstMain = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDomain = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.bgwValidate = New System.ComponentModel.BackgroundWorker()
        Me.bgwLoadIcon = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRemove)
        Me.Panel1.Controls.Add(Me.btnAddSource)
        Me.Panel1.Controls.Add(Me.txtDomain)
        Me.Panel1.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.BackColor = System.Drawing.Color.Red
        Me.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAddSource
        '
        resources.ApplyResources(Me.btnAddSource, "btnAddSource")
        Me.btnAddSource.BackColor = System.Drawing.Color.Lavender
        Me.btnAddSource.Name = "btnAddSource"
        Me.btnAddSource.UseVisualStyleBackColor = False
        '
        'txtDomain
        '
        resources.ApplyResources(Me.txtDomain, "txtDomain")
        Me.txtDomain.Name = "txtDomain"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lstMain
        '
        Me.lstMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colDomain})
        resources.ApplyResources(Me.lstMain, "lstMain")
        Me.lstMain.Items.AddRange(New System.Windows.Forms.ListViewItem() {CType(resources.GetObject("lstMain.Items"), System.Windows.Forms.ListViewItem)})
        Me.lstMain.LargeImageList = Me.imgMain
        Me.lstMain.Name = "lstMain"
        Me.lstMain.TileSize = New System.Drawing.Size(300, 64)
        Me.lstMain.UseCompatibleStateImageBehavior = False
        Me.lstMain.View = System.Windows.Forms.View.Tile
        '
        'imgMain
        '
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMain.Images.SetKeyName(0, "BoomVM-004.png")
        '
        'bgwValidate
        '
        Me.bgwValidate.WorkerReportsProgress = True
        '
        'SourceForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstMain)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SourceForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAddSource As Button
    Friend WithEvents txtDomain As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lstMain As ListView
    Friend WithEvents colName As ColumnHeader
    Friend WithEvents colDomain As ColumnHeader
    Friend WithEvents bgwValidate As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwLoadIcon As System.ComponentModel.BackgroundWorker
    Friend WithEvents imgMain As ImageList
End Class
