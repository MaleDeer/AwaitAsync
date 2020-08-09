namespace AwaitAsync
{
    partial class Desktop
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
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnAsync2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(13, 13);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(235, 28);
            this.btnAsync.TabIndex = 0;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnAsync2
            // 
            this.btnAsync2.Location = new System.Drawing.Point(13, 57);
            this.btnAsync2.Name = "btnAsync2";
            this.btnAsync2.Size = new System.Drawing.Size(235, 28);
            this.btnAsync2.TabIndex = 0;
            this.btnAsync2.Text = "Async2";
            this.btnAsync2.UseVisualStyleBackColor = true;
            this.btnAsync2.Click += new System.EventHandler(this.btnAsync2_Click);
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 100);
            this.Controls.Add(this.btnAsync2);
            this.Controls.Add(this.btnAsync);
            this.Name = "Desktop";
            this.Text = "Desktop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnAsync2;
        private System.Windows.Forms.Button btnAsync;
    }
}