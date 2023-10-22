namespace KassDungeonGUI
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
            this.myOutput = new System.Windows.Forms.TextBox();
            this.myInput = new System.Windows.Forms.TextBox();
            this.mySender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myOutput
            // 
            this.myOutput.BackColor = System.Drawing.Color.Black;
            this.myOutput.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myOutput.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.myOutput.Location = new System.Drawing.Point(0, 0);
            this.myOutput.Multiline = true;
            this.myOutput.Name = "myOutput";
            this.myOutput.ReadOnly = true;
            this.myOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.myOutput.Size = new System.Drawing.Size(284, 213);
            this.myOutput.TabIndex = 2;
            this.myOutput.TabStop = false;
            this.myOutput.WordWrap = false;
            // 
            // myInput
            // 
            this.myInput.Location = new System.Drawing.Point(0, 219);
            this.myInput.Name = "myInput";
            this.myInput.Size = new System.Drawing.Size(184, 20);
            this.myInput.TabIndex = 0;
            this.myInput.WordWrap = false;
            this.myInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myInput_KeyPress);
            // 
            // mySender
            // 
            this.mySender.Location = new System.Drawing.Point(215, 217);
            this.mySender.Name = "mySender";
            this.mySender.Size = new System.Drawing.Size(69, 22);
            this.mySender.TabIndex = 1;
            this.mySender.Text = " Send";
            this.mySender.UseVisualStyleBackColor = true;
            this.mySender.Click += new System.EventHandler(this.mySender_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.mySender;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 448);
            this.Controls.Add(this.mySender);
            this.Controls.Add(this.myInput);
            this.Controls.Add(this.myOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Init);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox myOutput;
        private System.Windows.Forms.TextBox myInput;
        private System.Windows.Forms.Button mySender;
    }
}

