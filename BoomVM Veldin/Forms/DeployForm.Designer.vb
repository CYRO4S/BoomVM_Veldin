<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeployForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeployForm))
        Me.proMain = New System.Windows.Forms.ProgressBar()
        Me.txtMain = New System.Windows.Forms.TextBox()
        Me.bgwInstallFromLocal = New System.ComponentModel.BackgroundWorker()
        Me.bgwInstallFromSource = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'proMain
        '
        resources.ApplyResources(Me.proMain, "proMain")
        Me.proMain.Name = "proMain"
        '
        'txtMain
        '
        resources.ApplyResources(Me.txtMain, "txtMain")
        Me.txtMain.BackColor = System.Drawing.Color.White
        Me.txtMain.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMain.Name = "txtMain"
        Me.txtMain.ReadOnly = True
        '
        'bgwInstallFromLocal
        '
        Me.bgwInstallFromLocal.WorkerReportsProgress = True
        '
        'bgwInstallFromSource
        '
        Me.bgwInstallFromSource.WorkerReportsProgress = True
        '
        'DeployForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtMain)
        Me.Controls.Add(Me.proMain)
        Me.Name = "DeployForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents proMain As ProgressBar
    Friend WithEvents txtMain As TextBox
    Friend WithEvents bgwInstallFromLocal As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwInstallFromSource As System.ComponentModel.BackgroundWorker
End Class
