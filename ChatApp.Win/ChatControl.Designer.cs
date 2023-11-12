namespace ChatApp.Win
{
    partial class ChatControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnl_Header = new Panel();
            pnl_ContactList = new Panel();
            SuspendLayout();
            // 
            // pnl_Header
            // 
            pnl_Header.BackColor = Color.FromArgb(30, 30, 30);
            pnl_Header.Dock = DockStyle.Top;
            pnl_Header.Location = new Point(0, 0);
            pnl_Header.Name = "pnl_Header";
            pnl_Header.Size = new Size(984, 56);
            pnl_Header.TabIndex = 1;
            // 
            // pnl_ContactList
            // 
            pnl_ContactList.BackColor = Color.FromArgb(30, 30, 30);
            pnl_ContactList.Dock = DockStyle.Left;
            pnl_ContactList.Location = new Point(0, 56);
            pnl_ContactList.Name = "pnl_ContactList";
            pnl_ContactList.Size = new Size(250, 472);
            pnl_ContactList.TabIndex = 2;
            // 
            // ChatControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            Controls.Add(pnl_ContactList);
            Controls.Add(pnl_Header);
            Name = "ChatControl";
            Size = new Size(984, 528);
            Load += ChatControl_Load;
            ResumeLayout(false);
        }

        #endregion
        private Panel pnl_Header;
        private Panel pnl_ContactList;
    }
}
