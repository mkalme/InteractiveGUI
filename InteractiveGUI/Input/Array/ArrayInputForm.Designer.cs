
namespace InteractiveGUI {
    partial class ArrayInputForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LengthLabel = new InteractiveGUI.DarkLabel();
            this.GoToButton = new InteractiveGUI.DarkButton();
            this.TypeLabel = new InteractiveGUI.DarkLabel();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.SetForAllCheckBox = new InteractiveGUI.DarkCheckBox();
            this.CloseButton = new InteractiveGUI.DarkButton();
            this.SetValueButton = new InteractiveGUI.DarkButton();
            this.LengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.GoToUpDown = new System.Windows.Forms.NumericUpDown();
            this.FormContainer = new System.Windows.Forms.TableLayoutPanel();
            this.LinePanel = new System.Windows.Forms.Panel();
            this.LengthPanel = new System.Windows.Forms.Panel();
            this.SetValuePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoToUpDown)).BeginInit();
            this.FormContainer.SuspendLayout();
            this.LengthPanel.SuspendLayout();
            this.SetValuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LengthLabel.Location = new System.Drawing.Point(-1, 12);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(44, 15);
            this.LengthLabel.TabIndex = 0;
            this.LengthLabel.Text = "Length";
            // 
            // GoToButton
            // 
            this.GoToButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.GoToButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.GoToButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoToButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GoToButton.Location = new System.Drawing.Point(150, 7);
            this.GoToButton.Margin = new System.Windows.Forms.Padding(0);
            this.GoToButton.Name = "GoToButton";
            this.GoToButton.Size = new System.Drawing.Size(62, 25);
            this.GoToButton.TabIndex = 2;
            this.GoToButton.Text = "Go to";
            this.GoToButton.UseVisualStyleBackColor = false;
            this.GoToButton.Click += new System.EventHandler(this.GoToButton_Click);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TypeLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TypeLabel.Location = new System.Drawing.Point(15, 15);
            this.TypeLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(47, 20);
            this.TypeLabel.TabIndex = 4;
            this.TypeLabel.Text = "Int32";
            // 
            // InputPanel
            // 
            this.InputPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.InputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputPanel.Location = new System.Drawing.Point(15, 79);
            this.InputPanel.Margin = new System.Windows.Forms.Padding(0);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(300, 31);
            this.InputPanel.TabIndex = 6;
            // 
            // SetForAllCheckBox
            // 
            this.SetForAllCheckBox.AutoSize = true;
            this.SetForAllCheckBox.FlatAppearance.BorderSize = 0;
            this.SetForAllCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetForAllCheckBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SetForAllCheckBox.Location = new System.Drawing.Point(8, 7);
            this.SetForAllCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.SetForAllCheckBox.Name = "SetForAllCheckBox";
            this.SetForAllCheckBox.Size = new System.Drawing.Size(72, 19);
            this.SetForAllCheckBox.TabIndex = 7;
            this.SetForAllCheckBox.Text = "Set for all";
            this.SetForAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.CloseButton.BorderColor = System.Drawing.SystemColors.HighlightText;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CloseButton.Location = new System.Drawing.Point(15, 193);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 25);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SetValueButton
            // 
            this.SetValueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.SetValueButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.SetValueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetValueButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.SetValueButton.Location = new System.Drawing.Point(82, 4);
            this.SetValueButton.Margin = new System.Windows.Forms.Padding(0);
            this.SetValueButton.Name = "SetValueButton";
            this.SetValueButton.Size = new System.Drawing.Size(75, 25);
            this.SetValueButton.TabIndex = 9;
            this.SetValueButton.Text = "Set value";
            this.SetValueButton.UseVisualStyleBackColor = false;
            this.SetValueButton.Click += new System.EventHandler(this.SetValueButton_Click);
            // 
            // LengthUpDown
            // 
            this.LengthUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LengthUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LengthUpDown.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LengthUpDown.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LengthUpDown.Location = new System.Drawing.Point(46, 7);
            this.LengthUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.LengthUpDown.Name = "LengthUpDown";
            this.LengthUpDown.Size = new System.Drawing.Size(79, 25);
            this.LengthUpDown.TabIndex = 10;
            this.LengthUpDown.Leave += new System.EventHandler(this.LengthUpDown_Leave);
            // 
            // GoToUpDown
            // 
            this.GoToUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.GoToUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GoToUpDown.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GoToUpDown.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.GoToUpDown.Location = new System.Drawing.Point(221, 7);
            this.GoToUpDown.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.GoToUpDown.Name = "GoToUpDown";
            this.GoToUpDown.Size = new System.Drawing.Size(79, 25);
            this.GoToUpDown.TabIndex = 11;
            // 
            // FormContainer
            // 
            this.FormContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormContainer.ColumnCount = 1;
            this.FormContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormContainer.Controls.Add(this.LinePanel, 0, 1);
            this.FormContainer.Controls.Add(this.CloseButton, 0, 5);
            this.FormContainer.Controls.Add(this.TypeLabel, 0, 0);
            this.FormContainer.Controls.Add(this.InputPanel, 0, 3);
            this.FormContainer.Controls.Add(this.LengthPanel, 0, 2);
            this.FormContainer.Controls.Add(this.SetValuePanel, 0, 4);
            this.FormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormContainer.Location = new System.Drawing.Point(0, 0);
            this.FormContainer.Name = "FormContainer";
            this.FormContainer.Padding = new System.Windows.Forms.Padding(15);
            this.FormContainer.RowCount = 6;
            this.FormContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.FormContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.FormContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.FormContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FormContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.FormContainer.Size = new System.Drawing.Size(330, 233);
            this.FormContainer.TabIndex = 12;
            // 
            // LinePanel
            // 
            this.LinePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LinePanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinePanel.Location = new System.Drawing.Point(15, 38);
            this.LinePanel.Margin = new System.Windows.Forms.Padding(0);
            this.LinePanel.Name = "LinePanel";
            this.LinePanel.Size = new System.Drawing.Size(300, 1);
            this.LinePanel.TabIndex = 12;
            // 
            // LengthPanel
            // 
            this.LengthPanel.AutoSize = true;
            this.LengthPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LengthPanel.Controls.Add(this.GoToUpDown);
            this.LengthPanel.Controls.Add(this.LengthLabel);
            this.LengthPanel.Controls.Add(this.GoToButton);
            this.LengthPanel.Controls.Add(this.LengthUpDown);
            this.LengthPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LengthPanel.Location = new System.Drawing.Point(15, 39);
            this.LengthPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LengthPanel.Name = "LengthPanel";
            this.LengthPanel.Size = new System.Drawing.Size(300, 40);
            this.LengthPanel.TabIndex = 10;
            // 
            // SetValuePanel
            // 
            this.SetValuePanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SetValuePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetValuePanel.Controls.Add(this.SetValueButton);
            this.SetValuePanel.Controls.Add(this.SetForAllCheckBox);
            this.SetValuePanel.Location = new System.Drawing.Point(157, 113);
            this.SetValuePanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.SetValuePanel.Name = "SetValuePanel";
            this.SetValuePanel.Size = new System.Drawing.Size(158, 29);
            this.SetValuePanel.TabIndex = 9;
            // 
            // ArrayInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(330, 233);
            this.Controls.Add(this.FormContainer);
            this.Name = "ArrayInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ArrayInputForm";
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoToUpDown)).EndInit();
            this.FormContainer.ResumeLayout(false);
            this.FormContainer.PerformLayout();
            this.LengthPanel.ResumeLayout(false);
            this.LengthPanel.PerformLayout();
            this.SetValuePanel.ResumeLayout(false);
            this.SetValuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkLabel LengthLabel;
        private DarkButton GoToButton;
        private DarkLabel TypeLabel;
        private System.Windows.Forms.Panel InputPanel;
        private DarkCheckBox SetForAllCheckBox;
        private DarkButton CloseButton;
        private DarkButton SetValueButton;
        private System.Windows.Forms.NumericUpDown LengthUpDown;
        private System.Windows.Forms.NumericUpDown GoToUpDown;
        private System.Windows.Forms.TableLayoutPanel FormContainer;
        private System.Windows.Forms.Panel SetValuePanel;
        private System.Windows.Forms.Panel LengthPanel;
        private System.Windows.Forms.Panel LinePanel;
    }
}