<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        GroupBox1 = New GroupBox()
        rdBtns_Intials = New RadioButton()
        rdBtn_Icons = New RadioButton()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(rdBtns_Intials)
        GroupBox1.Controls.Add(rdBtn_Icons)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(200, 100)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Iconography Settings"
        ' 
        ' rdBtns_Intials
        ' 
        rdBtns_Intials.AutoSize = True
        rdBtns_Intials.Location = New Point(12, 61)
        rdBtns_Intials.Name = "rdBtns_Intials"
        rdBtns_Intials.Size = New Size(172, 19)
        rdBtns_Intials.TabIndex = 1
        rdBtns_Intials.TabStop = True
        rdBtns_Intials.Text = "Use Intitals for Slot Machine"
        rdBtns_Intials.UseVisualStyleBackColor = True
        ' 
        ' rdBtn_Icons
        ' 
        rdBtn_Icons.AutoSize = True
        rdBtn_Icons.Location = New Point(12, 22)
        rdBtn_Icons.Name = "rdBtn_Icons"
        rdBtn_Icons.Size = New Size(165, 19)
        rdBtn_Icons.TabIndex = 0
        rdBtn_Icons.TabStop = True
        rdBtn_Icons.Text = "Use Icons for Slot Machine"
        rdBtn_Icons.UseVisualStyleBackColor = True
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(223, 450)
        Controls.Add(GroupBox1)
        Name = "Settings"
        Text = "Settings"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdBtns_Intials As RadioButton
    Friend WithEvents rdBtn_Icons As RadioButton
End Class
