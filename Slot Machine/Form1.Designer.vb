﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btn_SpinSlotMachine = New Button()
        RichTextBox1 = New RichTextBox()
        RichTextBox2 = New RichTextBox()
        RichTextBox3 = New RichTextBox()
        GroupBox1 = New GroupBox()
        MenuStrip1 = New MenuStrip()
        ToolStrp_Settings = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btn_SpinSlotMachine
        ' 
        btn_SpinSlotMachine.Location = New Point(427, 415)
        btn_SpinSlotMachine.Name = "btn_SpinSlotMachine"
        btn_SpinSlotMachine.Size = New Size(160, 89)
        btn_SpinSlotMachine.TabIndex = 3
        btn_SpinSlotMachine.Text = "Spin Slot Machine"
        btn_SpinSlotMachine.UseVisualStyleBackColor = True
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Font = New Font("Times New Roman", 48F)
        RichTextBox1.Location = New Point(229, 218)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox1.Size = New Size(100, 96)
        RichTextBox1.TabIndex = 4
        RichTextBox1.Text = ""
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Font = New Font("Times New Roman", 48F)
        RichTextBox2.Location = New Point(457, 218)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.ReadOnly = True
        RichTextBox2.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox2.Size = New Size(100, 96)
        RichTextBox2.TabIndex = 5
        RichTextBox2.Text = ""
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.Font = New Font("Times New Roman", 48F)
        RichTextBox3.Location = New Point(685, 218)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.ReadOnly = True
        RichTextBox3.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox3.Size = New Size(100, 96)
        RichTextBox3.TabIndex = 6
        RichTextBox3.Text = ""
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Location = New Point(185, 168)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(644, 206)
        GroupBox1.TabIndex = 7
        GroupBox1.TabStop = False
        GroupBox1.Text = "Slot Machine Reels"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolStrp_Settings})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1014, 24)
        MenuStrip1.TabIndex = 8
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ToolStrp_Settings
        ' 
        ToolStrp_Settings.Name = "ToolStrp_Settings"
        ToolStrp_Settings.Size = New Size(61, 20)
        ToolStrp_Settings.Text = "Settings"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1014, 609)
        Controls.Add(RichTextBox3)
        Controls.Add(RichTextBox2)
        Controls.Add(RichTextBox1)
        Controls.Add(btn_SpinSlotMachine)
        Controls.Add(GroupBox1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Form1"
        Text = "Slot Machine!"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btn_SpinSlotMachine As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStrp_Settings As ToolStripMenuItem

End Class
