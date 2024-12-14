<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WinForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinForm))
        pctBx_ImageOverlay = New PictureBox()
        CType(pctBx_ImageOverlay, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pctBx_ImageOverlay
        ' 
        pctBx_ImageOverlay.BackColor = Color.Transparent
        pctBx_ImageOverlay.Image = CType(resources.GetObject("pctBx_ImageOverlay.Image"), Image)
        pctBx_ImageOverlay.Location = New Point(0, 0)
        pctBx_ImageOverlay.Name = "pctBx_ImageOverlay"
        pctBx_ImageOverlay.Size = New Size(386, 361)
        pctBx_ImageOverlay.TabIndex = 0
        pctBx_ImageOverlay.TabStop = False
        pctBx_ImageOverlay.Visible = False
        ' 
        ' WinForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 361)
        Controls.Add(pctBx_ImageOverlay)
        Name = "WinForm"
        Text = "Form2"
        CType(pctBx_ImageOverlay, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pctBx_ImageOverlay As PictureBox
End Class
