
namespace InteractiveGUI {
    partial class ObjectCreatorForm {
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
            this.ConstructorLabel = new InteractiveGUI.DarkLabel();
            this.ConstructorComboBox = new InteractiveGUI.DarkComboBox();
            this.GlobalContainer = new System.Windows.Forms.TableLayoutPanel();
            this.ChooseConstructorPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DoneButton = new InteractiveGUI.DarkButton();
            this.GlobalContainer.SuspendLayout();
            this.ChooseConstructorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConstructorLabel
            // 
            this.ConstructorLabel.AutoSize = true;
            this.ConstructorLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConstructorLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ConstructorLabel.Location = new System.Drawing.Point(0, 4);
            this.ConstructorLabel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.ConstructorLabel.Name = "ConstructorLabel";
            this.ConstructorLabel.Size = new System.Drawing.Size(111, 15);
            this.ConstructorLabel.TabIndex = 0;
            this.ConstructorLabel.Text = "Choose constructor";
            // 
            // ConstructorComboBox
            // 
            this.ConstructorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ConstructorComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConstructorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConstructorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConstructorComboBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ConstructorComboBox.FormattingEnabled = true;
            this.ConstructorComboBox.Location = new System.Drawing.Point(114, 0);
            this.ConstructorComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.ConstructorComboBox.Name = "ConstructorComboBox";
            this.ConstructorComboBox.Size = new System.Drawing.Size(326, 23);
            this.ConstructorComboBox.TabIndex = 1;
            this.ConstructorComboBox.SelectedIndexChanged += new System.EventHandler(this.ConstructorComboBox_SelectedIndexChanged);
            // 
            // GlobalContainer
            // 
            this.GlobalContainer.ColumnCount = 1;
            this.GlobalContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GlobalContainer.Controls.Add(this.ChooseConstructorPanel, 0, 0);
            this.GlobalContainer.Controls.Add(this.DoneButton, 0, 2);
            this.GlobalContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GlobalContainer.Location = new System.Drawing.Point(0, 0);
            this.GlobalContainer.Margin = new System.Windows.Forms.Padding(0);
            this.GlobalContainer.Name = "GlobalContainer";
            this.GlobalContainer.Padding = new System.Windows.Forms.Padding(13);
            this.GlobalContainer.RowCount = 3;
            this.GlobalContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.GlobalContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.GlobalContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GlobalContainer.Size = new System.Drawing.Size(466, 264);
            this.GlobalContainer.TabIndex = 2;
            // 
            // ChooseConstructorPanel
            // 
            this.ChooseConstructorPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChooseConstructorPanel.ColumnCount = 2;
            this.ChooseConstructorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.ChooseConstructorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.ChooseConstructorPanel.Controls.Add(this.ConstructorComboBox, 1, 0);
            this.ChooseConstructorPanel.Controls.Add(this.ConstructorLabel, 0, 0);
            this.ChooseConstructorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseConstructorPanel.Location = new System.Drawing.Point(13, 13);
            this.ChooseConstructorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ChooseConstructorPanel.Name = "ChooseConstructorPanel";
            this.ChooseConstructorPanel.RowCount = 1;
            this.ChooseConstructorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ChooseConstructorPanel.Size = new System.Drawing.Size(440, 35);
            this.ChooseConstructorPanel.TabIndex = 3;
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.DoneButton.BorderColor = System.Drawing.SystemColors.HighlightText;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DoneButton.Location = new System.Drawing.Point(13, 226);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 25);
            this.DoneButton.TabIndex = 5;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // ObjectCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(466, 264);
            this.Controls.Add(this.GlobalContainer);
            this.MaximizeBox = false;
            this.Name = "ObjectCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ObjectCreatorForm";
            this.GlobalContainer.ResumeLayout(false);
            this.ChooseConstructorPanel.ResumeLayout(false);
            this.ChooseConstructorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkLabel ConstructorLabel;
        private DarkComboBox ConstructorComboBox;
        private System.Windows.Forms.TableLayoutPanel GlobalContainer;
        private DarkButton DoneButton;
        private System.Windows.Forms.TableLayoutPanel ChooseConstructorPanel;
    }
}