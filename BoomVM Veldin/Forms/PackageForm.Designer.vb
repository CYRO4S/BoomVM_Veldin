<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackageForm))
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.lblPackname = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.btnInstall = New System.Windows.Forms.Button()
        Me.txtIntro = New System.Windows.Forms.TextBox()
        Me.cbxList = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picIcon
        '
        resources.ApplyResources(Me.picIcon, "picIcon")
        Me.picIcon.Name = "picIcon"
        Me.picIcon.TabStop = False
        '
        'lblPackname
        '
        resources.ApplyResources(Me.lblPackname, "lblPackname")
        Me.lblPackname.Name = "lblPackname"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblAuthor
        '
        resources.ApplyResources(Me.lblAuthor, "lblAuthor")
        Me.lblAuthor.Name = "lblAuthor"
        '
        'btnInstall
        '
        resources.ApplyResources(Me.btnInstall, "btnInstall")
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'txtIntro
        '
        resources.ApplyResources(Me.txtIntro, "txtIntro")
        Me.txtIntro.BackColor = System.Drawing.Color.White
        Me.txtIntro.Name = "txtIntro"
        Me.txtIntro.ReadOnly = True
        '
        'cbxList
        '
        resources.ApplyResources(Me.cbxList, "cbxList")
        Me.cbxList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxList.FormattingEnabled = True
        Me.cbxList.Name = "cbxList"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'PackageForm
        '
        Me.AcceptButton = Me.btnInstall
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxList)
        Me.Controls.Add(Me.txtIntro)
        Me.Controls.Add(Me.btnInstall)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPackname)
        Me.Controls.Add(Me.picIcon)
        Me.Name = "PackageForm"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picIcon As PictureBox
    Friend WithEvents lblPackname As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents btnInstall As Button
    Friend WithEvents txtIntro As TextBox
    Friend WithEvents cbxList As ComboBox
    Friend WithEvents Label2 As Label
End Class
