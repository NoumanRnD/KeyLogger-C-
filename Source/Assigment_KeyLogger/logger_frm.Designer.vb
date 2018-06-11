<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class logger_frm
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
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Switchclear = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblAbout = New System.Windows.Forms.Label()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOutput
        '
        Me.txtOutput.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtOutput.Location = New System.Drawing.Point(0, 68)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(601, 304)
        Me.txtOutput.TabIndex = 1
        '
        'Switchclear
        '
        Me.Switchclear.BackColor = System.Drawing.Color.Linen
        Me.Switchclear.Location = New System.Drawing.Point(0, 12)
        Me.Switchclear.Name = "Switchclear"
        Me.Switchclear.Size = New System.Drawing.Size(75, 28)
        Me.Switchclear.TabIndex = 2
        Me.Switchclear.Text = "clear"
        Me.Switchclear.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 375)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(607, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(121, 17)
        Me.status.Text = "ToolStripStatusLabel1"
        '
        'lblAbout
        '
        Me.lblAbout.AutoSize = True
        Me.lblAbout.Location = New System.Drawing.Point(8, 52)
        Me.lblAbout.Name = "lblAbout"
        Me.lblAbout.Size = New System.Drawing.Size(29, 13)
        Me.lblAbout.TabIndex = 5
        Me.lblAbout.Text = "keys"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.CheckFileExists = False
        Me.OpenFileDialog.CheckPathExists = False
        Me.OpenFileDialog.FileName = "C:\ntklr.sys"
        Me.OpenFileDialog.ValidateNames = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Linen
        Me.Button1.Location = New System.Drawing.Point(81, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Make File"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Linen
        Me.Button2.Location = New System.Drawing.Point(520, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 28)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "desktop"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'logger_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(607, 397)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Switchclear)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblAbout)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtOutput)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "logger_frm"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents Switchclear As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblAbout As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
