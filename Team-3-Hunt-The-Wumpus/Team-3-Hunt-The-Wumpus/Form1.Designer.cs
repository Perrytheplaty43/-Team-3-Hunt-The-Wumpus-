
using System.Drawing;
using System.Windows.Forms;

namespace Team_3_Hunt_The_Wumpus
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.richTextBoxWarn = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxTrivia = new System.Windows.Forms.RichTextBox();
            this.labelArrows = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1287, 134);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hunt the Wumpus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.BackColor = System.Drawing.Color.Black;
            this.textBoxCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxCommand.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCommand.ForeColor = System.Drawing.Color.Lime;
            this.textBoxCommand.Location = new System.Drawing.Point(0, 678);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.PlaceholderText = "enter command...";
            this.textBoxCommand.Size = new System.Drawing.Size(1287, 50);
            this.textBoxCommand.TabIndex = 1;
            this.textBoxCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCommand_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(452, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 500);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBoxOutput.BackColor = System.Drawing.Color.Black;
            this.richTextBoxOutput.Location = new System.Drawing.Point(181, 576);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(960, 96);
            this.richTextBoxOutput.TabIndex = 2;
            this.richTextBoxOutput.Text = "";
            // 
            // richTextBoxWarn
            // 
            this.richTextBoxWarn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBoxWarn.BackColor = System.Drawing.Color.Black;
            this.richTextBoxWarn.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxWarn.Location = new System.Drawing.Point(-91, 86);
            this.richTextBoxWarn.Name = "richTextBoxWarn";
            this.richTextBoxWarn.ReadOnly = true;
            this.richTextBoxWarn.Size = new System.Drawing.Size(326, 306);
            this.richTextBoxWarn.TabIndex = 3;
            this.richTextBoxWarn.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(-73, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 50);
            this.label2.TabIndex = 4;
            this.label2.Text = "Warnings:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(979, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 50);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trivia:";
            // 
            // richTextBoxTrivia
            // 
            this.richTextBoxTrivia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBoxTrivia.BackColor = System.Drawing.Color.Black;
            this.richTextBoxTrivia.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxTrivia.Location = new System.Drawing.Point(961, 96);
            this.richTextBoxTrivia.Name = "richTextBoxTrivia";
            this.richTextBoxTrivia.ReadOnly = true;
            this.richTextBoxTrivia.Size = new System.Drawing.Size(326, 306);
            this.richTextBoxTrivia.TabIndex = 5;
            this.richTextBoxTrivia.Text = "";
            // 
            // labelArrows
            // 
            this.labelArrows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelArrows.AutoSize = true;
            this.labelArrows.BackColor = System.Drawing.Color.Transparent;
            this.labelArrows.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelArrows.ForeColor = System.Drawing.Color.Lime;
            this.labelArrows.Location = new System.Drawing.Point(-73, 96);
            this.labelArrows.Name = "labelArrows";
            this.labelArrows.Size = new System.Drawing.Size(175, 50);
            this.labelArrows.TabIndex = 7;
            this.labelArrows.Text = "Arrows: 3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 728);
            this.Controls.Add(this.labelArrows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxTrivia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxWarn);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Hunt the Wumpus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Panel panel1;
        private RichTextBox richTextBoxOutput;
        private RichTextBox richTextBoxWarn;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBoxTrivia;
        private Label labelArrows;
    }
}

