namespace GameCanvas
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.canvas1 = new GameCanvas.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this.canvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas1.Image = ((System.Drawing.Image)(resources.GetObject("canvas1.Image")));
            this.canvas1.Location = new System.Drawing.Point(0, 0);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(810, 476);
            this.canvas1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.canvas1.TabIndex = 0;
            this.canvas1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(810, 476);
            this.Controls.Add(this.canvas1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Canvas canvas1;
    }
}

