
namespace NaplatnaRampa.view
{
    partial class MalfunctionTable
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
            this.malfunctionGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.malfunctionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // malfunctionGridView
            // 
            this.malfunctionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malfunctionGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.malfunctionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malfunctionGridView.Location = new System.Drawing.Point(77, 46);
            this.malfunctionGridView.Name = "malfunctionGridView";
            this.malfunctionGridView.RowHeadersWidth = 51;
            this.malfunctionGridView.RowTemplate.Height = 29;
            this.malfunctionGridView.Size = new System.Drawing.Size(604, 318);
            this.malfunctionGridView.TabIndex = 0;
            this.malfunctionGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.malfunctionGridView_CellContentClick);
            // 
            // MalfunctionTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.malfunctionGridView);
            this.Name = "MalfunctionTable";
            this.Text = "ManufactionTable";
            this.Load += new System.EventHandler(this.ManufactionTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.malfunctionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView malfunctionGridView;
    }
}