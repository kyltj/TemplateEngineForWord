namespace Oleg
{
    partial class Identytay
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Имя_Поля = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Значение_Поля = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Идентификатор_Поля = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Имя_Поля,
            this.Значение_Поля,
            this.Идентификатор_Поля});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(633, 261);
            this.dataGridView1.TabIndex = 0;
            // 
            // Имя_Поля
            // 
            this.Имя_Поля.HeaderText = "Имя_Поля";
            this.Имя_Поля.Name = "Имя_Поля";
            // 
            // Значение_Поля
            // 
            this.Значение_Поля.HeaderText = "Значение_Поля";
            this.Значение_Поля.Name = "Значение_Поля";
            // 
            // Идентификатор_Поля
            // 
            this.Идентификатор_Поля.HeaderText = "Идентификатор_Поля";
            this.Идентификатор_Поля.Name = "Идентификатор_Поля";
            // 
            // Identytay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 261);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Identytay";
            this.Text = "Identytay";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Имя_Поля;
        private System.Windows.Forms.DataGridViewTextBoxColumn Значение_Поля;
        private System.Windows.Forms.DataGridViewTextBoxColumn Идентификатор_Поля;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}