namespace SteamOnline;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lbl_status = new Label();
        btn_change = new Button();
        pnl_statusColor = new Panel();
        tableLayoutPanel1 = new TableLayoutPanel();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // lbl_status
        // 
        lbl_status.AutoSize = true;
        lbl_status.Dock = DockStyle.Fill;
        lbl_status.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
        lbl_status.Location = new Point(3, 0);
        lbl_status.Name = "lbl_status";
        lbl_status.Size = new Size(250, 51);
        lbl_status.TabIndex = 0;
        lbl_status.Text = "Steam Online";
        lbl_status.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btn_change
        // 
        btn_change.Dock = DockStyle.Fill;
        btn_change.Location = new Point(3, 105);
        btn_change.Name = "btn_change";
        btn_change.Size = new Size(250, 45);
        btn_change.TabIndex = 1;
        btn_change.Text = "Kapat";
        btn_change.UseVisualStyleBackColor = true;
        btn_change.Click += btn_change_Click;
        // 
        // pnl_statusColor
        // 
        pnl_statusColor.BackColor = Color.Lime;
        pnl_statusColor.Dock = DockStyle.Fill;
        pnl_statusColor.ForeColor = Color.Lime;
        pnl_statusColor.Location = new Point(3, 54);
        pnl_statusColor.Name = "pnl_statusColor";
        pnl_statusColor.Size = new Size(250, 45);
        pnl_statusColor.TabIndex = 2;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(btn_change, 0, 2);
        tableLayoutPanel1.Controls.Add(lbl_status, 0, 0);
        tableLayoutPanel1.Controls.Add(pnl_statusColor, 0, 1);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.Size = new Size(256, 153);
        tableLayoutPanel1.TabIndex = 3;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(256, 153);
        Controls.Add(tableLayoutPanel1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximizeBox = false;
        MdiChildrenMinimizedAnchorBottom = false;
        Name = "MainForm";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Steam Engelleyici";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Label lbl_status;
    private Button btn_change;
    private Panel pnl_statusColor;
    private TableLayoutPanel tableLayoutPanel1;
}
