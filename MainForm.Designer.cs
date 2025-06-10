namespace template
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnViewInfo = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnFond = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewInfo
            // 
            this.btnViewInfo.Location = new System.Drawing.Point(310, 72);
            this.btnViewInfo.Name = "btnViewInfo";
            this.btnViewInfo.Size = new System.Drawing.Size(178, 75);
            this.btnViewInfo.TabIndex = 0;
            this.btnViewInfo.Text = "Посмотреть какую то инфу о клиенте";
            this.btnViewInfo.UseVisualStyleBackColor = true;
            this.btnViewInfo.Click += new System.EventHandler(this.btnViewInfo_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(310, 170);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(178, 45);
            this.btnManageUsers.TabIndex = 1;
            this.btnManageUsers.Text = "Пользователи";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(310, 321);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(178, 51);
            this.btnChangeUser.TabIndex = 2;
            this.btnChangeUser.Text = "Сменить пользователя";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // btnFond
            // 
            this.btnFond.Location = new System.Drawing.Point(310, 246);
            this.btnFond.Name = "btnFond";
            this.btnFond.Size = new System.Drawing.Size(178, 46);
            this.btnFond.TabIndex = 3;
            this.btnFond.Text = "Номерной фонд";
            this.btnFond.UseVisualStyleBackColor = true;
            this.btnFond.Click += new System.EventHandler(this.btnFond_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFond);
            this.Controls.Add(this.btnChangeUser);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnViewInfo);
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewInfo;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnFond;
    }
}