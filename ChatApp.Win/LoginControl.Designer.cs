namespace ChatApp.Win
{
    partial class LoginControl
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
            pnl_Left = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            btn_Login = new Button();
            tb_PinCode = new TextBox();
            tb_UserName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_Left
            // 
            pnl_Left.BackColor = Color.FromArgb(255, 209, 0);
            pnl_Left.Dock = DockStyle.Left;
            pnl_Left.Location = new Point(0, 0);
            pnl_Left.Name = "pnl_Left";
            pnl_Left.Size = new Size(340, 471);
            pnl_Left.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(340, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 471);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(30, 30, 30);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btn_Login);
            panel2.Controls.Add(tb_PinCode);
            panel2.Controls.Add(tb_UserName);
            panel2.Location = new Point(107, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(370, 289);
            panel2.TabIndex = 0;
            // 
            // btn_Login
            // 
            btn_Login.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Login.BackColor = Color.FromArgb(255, 209, 0);
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Login.Location = new Point(39, 193);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(297, 39);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // tb_PinCode
            // 
            tb_PinCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_PinCode.BackColor = Color.FromArgb(120, 120, 120);
            tb_PinCode.BorderStyle = BorderStyle.FixedSingle;
            tb_PinCode.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tb_PinCode.ForeColor = Color.FromArgb(30, 30, 30);
            tb_PinCode.Location = new Point(39, 125);
            tb_PinCode.Name = "tb_PinCode";
            tb_PinCode.PasswordChar = '●';
            tb_PinCode.Size = new Size(297, 29);
            tb_PinCode.TabIndex = 1;
            // 
            // tb_UserName
            // 
            tb_UserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_UserName.BackColor = Color.FromArgb(120, 120, 120);
            tb_UserName.BorderStyle = BorderStyle.FixedSingle;
            tb_UserName.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tb_UserName.ForeColor = Color.FromArgb(30, 30, 30);
            tb_UserName.Location = new Point(39, 65);
            tb_UserName.Name = "tb_UserName";
            tb_UserName.Size = new Size(297, 29);
            tb_UserName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 209, 0);
            label1.Location = new Point(39, 43);
            label1.Name = "label1";
            label1.Size = new Size(90, 19);
            label1.TabIndex = 3;
            label1.Text = "UserName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(255, 209, 0);
            label2.Location = new Point(39, 103);
            label2.Name = "label2";
            label2.Size = new Size(75, 19);
            label2.TabIndex = 4;
            label2.Text = "PinCode";
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            Controls.Add(panel1);
            Controls.Add(pnl_Left);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "LoginControl";
            Size = new Size(906, 471);
            Paint += LoginControl_Paint;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_Left;
        private Panel panel1;
        private Panel panel2;
        private TextBox tb_UserName;
        private TextBox tb_PinCode;
        private Button btn_Login;
        private Label label2;
        private Label label1;
    }
}
