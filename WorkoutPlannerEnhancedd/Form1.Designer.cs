using System.Drawing;
using System.Windows.Forms;
using System;

namespace WorkoutPlannerEnhancedd
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGenerate;
        private System.Windows.Forms.TabPage tabSaved;
        private System.Windows.Forms.ComboBox cmbDays;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.FlowLayoutPanel panelPlan;
        private System.Windows.Forms.Button btnConfirm;
        private TextBox txtStats;  // dichiara a livello globale


        private System.Windows.Forms.ComboBox cmbSavedDays;
        private System.Windows.Forms.ListBox lstSaved;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.RichTextBox richTextStats;

        private System.Windows.Forms.FlowLayoutPanel panelSavedPlan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGenerate = new System.Windows.Forms.TabPage();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panelPlan = new System.Windows.Forms.FlowLayoutPanel();
            this.tabSaved = new System.Windows.Forms.TabPage();
            this.txtStats = new System.Windows.Forms.TextBox();
            this.cmbSavedDays = new System.Windows.Forms.ComboBox();
            this.lstSaved = new System.Windows.Forms.ListBox();
            this.btnStats = new System.Windows.Forms.Button();
            this.panelSavedPlan = new System.Windows.Forms.FlowLayoutPanel();
            this.richTextStats = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GI = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabGenerate.SuspendLayout();
            this.tabSaved.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGenerate);
            this.tabControl.Controls.Add(this.tabSaved);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1337, 800);
            this.tabControl.TabIndex = 0;
            // 
            // tabGenerate
            // 
            this.tabGenerate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabGenerate.Controls.Add(this.cmbDays);
            this.tabGenerate.Controls.Add(this.btnGenerate);
            this.tabGenerate.Controls.Add(this.btnConfirm);
            this.tabGenerate.Controls.Add(this.panelPlan);
            this.tabGenerate.Location = new System.Drawing.Point(4, 26);
            this.tabGenerate.Name = "tabGenerate";
            this.tabGenerate.Padding = new System.Windows.Forms.Padding(10);
            this.tabGenerate.Size = new System.Drawing.Size(1329, 770);
            this.tabGenerate.TabIndex = 0;
            this.tabGenerate.Text = "⚙ Genera Scheda";
            // 
            // cmbDays
            // 
            this.cmbDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDays.Location = new System.Drawing.Point(20, 20);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(80, 25);
            this.cmbDays.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(120, 20);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(160, 40);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "🎯 Genera Scheda";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Enabled = false;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(300, 20);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(180, 40);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "✔ Conferma Scheda";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panelPlan
            // 
            this.panelPlan.AutoScroll = true;
            this.panelPlan.BackColor = System.Drawing.Color.White;
            this.panelPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlan.Location = new System.Drawing.Point(20, 80);
            this.panelPlan.Name = "panelPlan";
            this.panelPlan.Padding = new System.Windows.Forms.Padding(10);
            this.panelPlan.Size = new System.Drawing.Size(1198, 660);
            this.panelPlan.TabIndex = 3;
            // 
            // tabSaved
            // 
            this.tabSaved.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabSaved.Controls.Add(this.panel2);
            this.tabSaved.Controls.Add(this.panel1);
            this.tabSaved.Controls.Add(this.txtStats);
            this.tabSaved.Controls.Add(this.cmbSavedDays);
            this.tabSaved.Controls.Add(this.lstSaved);
            this.tabSaved.Controls.Add(this.btnStats);
            this.tabSaved.Controls.Add(this.panelSavedPlan);
            this.tabSaved.Controls.Add(this.richTextStats);
            this.tabSaved.Location = new System.Drawing.Point(4, 26);
            this.tabSaved.Name = "tabSaved";
            this.tabSaved.Padding = new System.Windows.Forms.Padding(10);
            this.tabSaved.Size = new System.Drawing.Size(1329, 770);
            this.tabSaved.TabIndex = 1;
            this.tabSaved.Text = "📁 Scheda Confermata";
            // 
            // txtStats
            // 
            this.txtStats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStats.Location = new System.Drawing.Point(20, 380);
            this.txtStats.Multiline = true;
            this.txtStats.Name = "txtStats";
            this.txtStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStats.Size = new System.Drawing.Size(540, 320);
            this.txtStats.TabIndex = 0;
            // 
            // cmbSavedDays
            // 
            this.cmbSavedDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSavedDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSavedDays.Location = new System.Drawing.Point(149, 16);
            this.cmbSavedDays.Name = "cmbSavedDays";
            this.cmbSavedDays.Size = new System.Drawing.Size(250, 25);
            this.cmbSavedDays.TabIndex = 0;
            this.cmbSavedDays.SelectedIndexChanged += new System.EventHandler(this.cmbSavedDays_SelectedIndexChanged);
            // 
            // lstSaved
            // 
            this.lstSaved.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstSaved.ItemHeight = 17;
            this.lstSaved.Location = new System.Drawing.Point(20, 103);
            this.lstSaved.Name = "lstSaved";
            this.lstSaved.Size = new System.Drawing.Size(540, 225);
            this.lstSaved.TabIndex = 2;
            // 
            // btnStats
            // 
            this.btnStats.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnStats.ForeColor = System.Drawing.Color.White;
            this.btnStats.Location = new System.Drawing.Point(173, 334);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(200, 40);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "📈 Statistiche";
            this.btnStats.UseVisualStyleBackColor = false;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // panelSavedPlan
            // 
            this.panelSavedPlan.AutoScroll = true;
            this.panelSavedPlan.BackColor = System.Drawing.Color.White;
            this.panelSavedPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSavedPlan.Location = new System.Drawing.Point(580, 20);
            this.panelSavedPlan.Name = "panelSavedPlan";
            this.panelSavedPlan.Padding = new System.Windows.Forms.Padding(10);
            this.panelSavedPlan.Size = new System.Drawing.Size(712, 700);
            this.panelSavedPlan.TabIndex = 4;
            // 
            // richTextStats
            // 
            this.richTextStats.BackColor = System.Drawing.Color.White;
            this.richTextStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.richTextStats.Location = new System.Drawing.Point(20, 380);
            this.richTextStats.Name = "richTextStats";
            this.richTextStats.ReadOnly = true;
            this.richTextStats.Size = new System.Drawing.Size(540, 300);
            this.richTextStats.TabIndex = 5;
            this.richTextStats.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.GI);
            this.panel1.Location = new System.Drawing.Point(36, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 31);
            this.panel1.TabIndex = 6;
            // 
            // GI
            // 
            this.GI.AutoSize = true;
            this.GI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GI.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GI.Location = new System.Drawing.Point(10, 7);
            this.GI.Name = "GI";
            this.GI.Size = new System.Drawing.Size(94, 21);
            this.GI.TabIndex = 0;
            this.GI.Text = "GIORNATA:";
            //            this.GI.Click += new System.EventHandler(this.GI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(23, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "GIORNI DELLA SCHEDA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(149, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 30);
            this.panel2.TabIndex = 7;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1337, 800);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "Form1";
            this.Text = "🏋️ Workout Planner Enhanced";
            this.tabControl.ResumeLayout(false);
            this.tabGenerate.ResumeLayout(false);
            this.tabSaved.ResumeLayout(false);
            this.tabSaved.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        private Panel panel1;
        private Label GI;
        private Panel panel2;
        private Label label1;
    }
}