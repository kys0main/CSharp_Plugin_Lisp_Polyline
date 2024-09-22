namespace ClassLibrary1
{
    partial class MainForm
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
            this.SelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dxfield = new System.Windows.Forms.TextBox();
            this.dyfield = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.MainTable = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButton.Location = new System.Drawing.Point(630, 12);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(158, 47);
            this.SelectButton.TabIndex = 0;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(625, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "dX";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(625, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "dY";
            // 
            // dxfield
            // 
            this.dxfield.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dxfield.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dxfield.Location = new System.Drawing.Point(668, 105);
            this.dxfield.Name = "dxfield";
            this.dxfield.Size = new System.Drawing.Size(120, 30);
            this.dxfield.TabIndex = 3;
            // 
            // dyfield
            // 
            this.dyfield.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dyfield.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dyfield.Location = new System.Drawing.Point(667, 158);
            this.dyfield.Name = "dyfield";
            this.dyfield.Size = new System.Drawing.Size(120, 30);
            this.dyfield.TabIndex = 4;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(675, 391);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(113, 47);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MainTable
            // 
            this.MainTable.AllowUserToAddRows = false;
            this.MainTable.AllowUserToDeleteRows = false;
            this.MainTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.StartX,
            this.StartY,
            this.EndX,
            this.EndY});
            this.MainTable.Location = new System.Drawing.Point(12, 12);
            this.MainTable.Name = "MainTable";
            this.MainTable.ReadOnly = true;
            this.MainTable.RowHeadersWidth = 50;
            this.MainTable.RowTemplate.Height = 24;
            this.MainTable.Size = new System.Drawing.Size(607, 364);
            this.MainTable.TabIndex = 8;
            // 
            // Number
            // 
            this.Number.FillWeight = 30F;
            this.Number.HeaderText = "№";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // StartX
            // 
            this.StartX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StartX.HeaderText = "Start X";
            this.StartX.MinimumWidth = 6;
            this.StartX.Name = "StartX";
            this.StartX.ReadOnly = true;
            this.StartX.Width = 74;
            // 
            // StartY
            // 
            this.StartY.HeaderText = "Start Y";
            this.StartY.MinimumWidth = 6;
            this.StartY.Name = "StartY";
            this.StartY.ReadOnly = true;
            // 
            // EndX
            // 
            this.EndX.HeaderText = "End X";
            this.EndX.MinimumWidth = 6;
            this.EndX.Name = "EndX";
            this.EndX.ReadOnly = true;
            // 
            // EndY
            // 
            this.EndY.HeaderText = "End Y";
            this.EndY.MinimumWidth = 6;
            this.EndY.Name = "EndY";
            this.EndY.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.dyfield);
            this.Controls.Add(this.dxfield);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectButton);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "MainForm";
            this.Text = "Join To Polyline";
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dxfield;
        private System.Windows.Forms.TextBox dyfield;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.DataGridView MainTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartX;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartY;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndX;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndY;
    }
}