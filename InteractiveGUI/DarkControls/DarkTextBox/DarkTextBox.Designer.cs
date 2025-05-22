
namespace InteractiveGUI {
    partial class DarkTextBox {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TextBox = new System.Windows.Forms.TextBox();
            this.HintLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TextBox.Location = new System.Drawing.Point(5, 5);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(80, 16);
            this.TextBox.TabIndex = 0;
            this.TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.TextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            this.TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseDown);
            // 
            // HintLabel
            // 
            this.HintLabel.AutoSize = true;
            this.HintLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HintLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HintLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HintLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HintLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.HintLabel.Location = new System.Drawing.Point(5, 3);
            this.HintLabel.Margin = new System.Windows.Forms.Padding(0);
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(31, 15);
            this.HintLabel.TabIndex = 1;
            this.HintLabel.Text = "Path";
            this.HintLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HintLabel_MouseDown);
            // 
            // DarkTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.TextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DarkTextBox";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(90, 25);
            this.SizeChanged += new System.EventHandler(this.CustomTextBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Label HintLabel;
    }
}
