namespace LoginSystem
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
            this.btnHash = new System.Windows.Forms.Button();
            this.txtHashOutput = new System.Windows.Forms.TextBox();
            this.txtHashInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(50, 106);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(127, 23);
            this.btnHash.TabIndex = 0;
            this.btnHash.Text = "Hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // txtHashOutput
            // 
            this.txtHashOutput.Location = new System.Drawing.Point(50, 67);
            this.txtHashOutput.Name = "txtHashOutput";
            this.txtHashOutput.Size = new System.Drawing.Size(468, 22);
            this.txtHashOutput.TabIndex = 1;
            // 
            // txtHashInput
            // 
            this.txtHashInput.Location = new System.Drawing.Point(50, 39);
            this.txtHashInput.Name = "txtHashInput";
            this.txtHashInput.Size = new System.Drawing.Size(468, 22);
            this.txtHashInput.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "CheckPassword";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtHashInput);
            this.Controls.Add(this.txtHashOutput);
            this.Controls.Add(this.btnHash);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.TextBox txtHashOutput;
        private System.Windows.Forms.TextBox txtHashInput;
        private System.Windows.Forms.Button button1;
    }
}

