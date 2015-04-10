using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PremiumMigration
{
    partial class PremiumMigrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PremiumMigrationForm));
            this.environmentCbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.migrationTypeCbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.messageTypeCbox = new System.Windows.Forms.ComboBox();
            this.migrateBtn = new System.Windows.Forms.Button();
            this.usernameTbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // environmentCbox
            // 
            this.environmentCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.environmentCbox.FormattingEnabled = true;
            this.environmentCbox.Location = new System.Drawing.Point(12, 56);
            this.environmentCbox.Name = "environmentCbox";
            this.environmentCbox.Size = new System.Drawing.Size(174, 21);
            this.environmentCbox.TabIndex = 0;
            this.environmentCbox.SelectedIndexChanged += new System.EventHandler(this.Environment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Environment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Migration type";
            // 
            // migrationTypeCbox
            // 
            this.migrationTypeCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.migrationTypeCbox.FormattingEnabled = true;
            this.migrationTypeCbox.Location = new System.Drawing.Point(12, 101);
            this.migrationTypeCbox.Name = "migrationTypeCbox";
            this.migrationTypeCbox.Size = new System.Drawing.Size(174, 21);
            this.migrationTypeCbox.TabIndex = 3;
            this.migrationTypeCbox.SelectedIndexChanged += new System.EventHandler(this.MigrationType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message type";
            // 
            // messageTypeCbox
            // 
            this.messageTypeCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.messageTypeCbox.FormattingEnabled = true;
            this.messageTypeCbox.Location = new System.Drawing.Point(12, 149);
            this.messageTypeCbox.Name = "messageTypeCbox";
            this.messageTypeCbox.Size = new System.Drawing.Size(174, 21);
            this.messageTypeCbox.TabIndex = 5;
            // 
            // migrateBtn
            // 
            this.migrateBtn.Location = new System.Drawing.Point(12, 238);
            this.migrateBtn.Name = "migrateBtn";
            this.migrateBtn.Size = new System.Drawing.Size(80, 23);
            this.migrateBtn.TabIndex = 7;
            this.migrateBtn.Text = "Migrate user";
            this.migrateBtn.UseVisualStyleBackColor = true;
            this.migrateBtn.Click += new System.EventHandler(this.Migrate_Click);
            // 
            // usernameTbox
            // 
            this.usernameTbox.Location = new System.Drawing.Point(12, 196);
            this.usernameTbox.Name = "usernameTbox";
            this.usernameTbox.Size = new System.Drawing.Size(174, 20);
            this.usernameTbox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Account Name (include frontend id)";
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(110, 238);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(76, 23);
            this.checkBtn.TabIndex = 10;
            this.checkBtn.Text = "Check user";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.Check_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "created by -=Tj=-";
            // 
            // PremiumMigrationForm
            // 
            this.ClientSize = new System.Drawing.Size(204, 274);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.usernameTbox);
            this.Controls.Add(this.migrateBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.messageTypeCbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.migrationTypeCbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.environmentCbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(220, 312);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(220, 312);
            this.Name = "PremiumMigrationForm";
            this.Text = "Premium Migration v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox environmentCbox;
        private Label label1;
        private Label label2;
        private ComboBox migrationTypeCbox;
        private Label label3;
        private ComboBox messageTypeCbox;
        private Button migrateBtn;
        private TextBox usernameTbox;
        private Label label4;
        private Button checkBtn;
        private Label label5;
    }
}

