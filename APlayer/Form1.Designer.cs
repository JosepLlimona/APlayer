using System.Windows.Forms;

namespace APlayer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pathLabel = new System.Windows.Forms.Label();
            this.episodesList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.continueBtn = new System.Windows.Forms.Button();
            this.seriesList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(12, 12);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(119, 55);
            this.btnDir.TabIndex = 0;
            this.btnDir.Text = "Select Directory";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(138, 31);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(35, 13);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "label1";
            this.pathLabel.Visible = false;
            // 
            // episodesList
            // 
            this.episodesList.HideSelection = false;
            this.episodesList.Location = new System.Drawing.Point(12, 109);
            this.episodesList.Name = "episodesList";
            this.episodesList.Size = new System.Drawing.Size(776, 309);
            this.episodesList.TabIndex = 3;
            this.episodesList.UseCompatibleStateImageBehavior = false;
            this.episodesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.episodeList_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Episodes";
            // 
            // continueBtn
            // 
            this.continueBtn.Location = new System.Drawing.Point(653, 31);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(125, 23);
            this.continueBtn.TabIndex = 5;
            this.continueBtn.Text = "Continue: ";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // seriesList
            // 
            this.seriesList.FormattingEnabled = true;
            this.seriesList.Location = new System.Drawing.Point(340, 31);
            this.seriesList.Name = "seriesList";
            this.seriesList.Size = new System.Drawing.Size(121, 21);
            this.seriesList.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Serie:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seriesList);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.episodesList);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.btnDir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label pathLabel;
        public System.Windows.Forms.ListView episodesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button continueBtn;
        private ComboBox seriesList;
        private Label label2;
    }
}

