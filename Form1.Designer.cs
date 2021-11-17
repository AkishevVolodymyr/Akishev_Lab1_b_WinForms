
namespace Akishev_Lab1_b_WinForms
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.тестуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проДодатокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вхідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.реєстраціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестуванняToolStripMenuItem,
            this.результатToolStripMenuItem,
            this.проДодатокToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // тестуванняToolStripMenuItem
            // 
            this.тестуванняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вхідToolStripMenuItem,
            this.реєстраціяToolStripMenuItem,
            this.вихідToolStripMenuItem});
            this.тестуванняToolStripMenuItem.Name = "тестуванняToolStripMenuItem";
            this.тестуванняToolStripMenuItem.Size = new System.Drawing.Size(118, 29);
            this.тестуванняToolStripMenuItem.Text = "Тестування";
            // 
            // результатToolStripMenuItem
            // 
            this.результатToolStripMenuItem.Name = "результатToolStripMenuItem";
            this.результатToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.результатToolStripMenuItem.Text = "Результат";
            // 
            // проДодатокToolStripMenuItem
            // 
            this.проДодатокToolStripMenuItem.Name = "проДодатокToolStripMenuItem";
            this.проДодатокToolStripMenuItem.Size = new System.Drawing.Size(135, 29);
            this.проДодатокToolStripMenuItem.Text = "Про додаток";
            // 
            // вхідToolStripMenuItem
            // 
            this.вхідToolStripMenuItem.Name = "вхідToolStripMenuItem";
            this.вхідToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.вхідToolStripMenuItem.Text = "Вхід";
            this.вхідToolStripMenuItem.Click += new System.EventHandler(this.вхідToolStripMenuItem_Click);
            // 
            // реєстраціяToolStripMenuItem
            // 
            this.реєстраціяToolStripMenuItem.Name = "реєстраціяToolStripMenuItem";
            this.реєстраціяToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.реєстраціяToolStripMenuItem.Text = "Реєстрація";
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.вихідToolStripMenuItem.Text = "Вихід";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 465);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem тестуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вхідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem реєстраціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem результатToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проДодатокToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

