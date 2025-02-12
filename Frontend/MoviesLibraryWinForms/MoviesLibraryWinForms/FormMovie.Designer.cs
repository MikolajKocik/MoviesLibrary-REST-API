namespace MoviesLibraryWinForms
{
    partial class FormMovie
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
            txtTitle = new TextBox();
            txtYear = new TextBox();
            lblTitle = new Label();
            lblYear = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(30, 71);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(356, 23);
            txtTitle.TabIndex = 2;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(30, 164);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(73, 23);
            txtYear.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(60, 32);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Title";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblYear.Location = new Point(30, 117);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(58, 32);
            lblYear.TabIndex = 5;
            lblYear.Text = "Year";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(30, 229);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(140, 229);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormMovie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 283);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblYear);
            Controls.Add(lblTitle);
            Controls.Add(txtYear);
            Controls.Add(txtTitle);
            Name = "FormMovie";
            Text = "FormMovie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTitle;
        private TextBox txtYear;
        private Label lblTitle;
        private Label lblYear;
        private Button btnOk;
        private Button btnCancel;
    }
}