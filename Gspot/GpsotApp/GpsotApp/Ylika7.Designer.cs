namespace GpsotApp
{
    partial class Ylika7
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ylika7));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.evotsis_gspotDataSet27 = new GpsotApp.evotsis_gspotDataSet27();
            this.ylika7BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.evotsis_gspotDataSet26 = new GpsotApp.evotsis_gspotDataSet26();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ylika7TableAdapter = new GpsotApp.evotsis_gspotDataSet26TableAdapters.Ylika7TableAdapter();
            this.suppliersTableAdapter = new GpsotApp.evotsis_gspotDataSet27TableAdapters.SuppliersTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.aADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPTIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pASSWORDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOLORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUPPLIERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fIRSTDIMENSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUTDIMENSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOSTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evotsis_gspotDataSet27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ylika7BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evotsis_gspotDataSet26)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aADataGridViewTextBoxColumn,
            this.dESCRIPTIONDataGridViewTextBoxColumn,
            this.pASSWORDDataGridViewTextBoxColumn,
            this.cOLORDataGridViewTextBoxColumn,
            this.sUPPLIERDataGridViewTextBoxColumn,
            this.fIRSTDIMENSIONDataGridViewTextBoxColumn,
            this.cUTDIMENSIONDataGridViewTextBoxColumn,
            this.cOSTDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ylika7BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1070, 436);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataMember = "Suppliers";
            this.suppliersBindingSource.DataSource = this.evotsis_gspotDataSet27;
            // 
            // evotsis_gspotDataSet27
            // 
            this.evotsis_gspotDataSet27.DataSetName = "evotsis_gspotDataSet27";
            this.evotsis_gspotDataSet27.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ylika7BindingSource
            // 
            this.ylika7BindingSource.DataMember = "Ylika7";
            this.ylika7BindingSource.DataSource = this.evotsis_gspotDataSet26;
            // 
            // evotsis_gspotDataSet26
            // 
            this.evotsis_gspotDataSet26.DataSetName = "evotsis_gspotDataSet26";
            this.evotsis_gspotDataSet26.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(142, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 47);
            this.button2.TabIndex = 36;
            this.button2.Text = "ΑΝΑΝΕΩΣΗ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(677, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 47);
            this.button1.TabIndex = 37;
            this.button1.Text = "ΔΙΑΓΡΑΦΗ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ylika7TableAdapter
            // 
            this.ylika7TableAdapter.ClearBeforeFill = true;
            // 
            // suppliersTableAdapter
            // 
            this.suppliersTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.27068F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.72932F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 532);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 445);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1070, 84);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // aADataGridViewTextBoxColumn
            // 
            this.aADataGridViewTextBoxColumn.DataPropertyName = "AA";
            this.aADataGridViewTextBoxColumn.HeaderText = "AA";
            this.aADataGridViewTextBoxColumn.Name = "aADataGridViewTextBoxColumn";
            // 
            // dESCRIPTIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPTIONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dESCRIPTIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPTION";
            this.dESCRIPTIONDataGridViewTextBoxColumn.HeaderText = "ΠΕΡΙΓΡΑΦΗ";
            this.dESCRIPTIONDataGridViewTextBoxColumn.Name = "dESCRIPTIONDataGridViewTextBoxColumn";
            // 
            // pASSWORDDataGridViewTextBoxColumn
            // 
            this.pASSWORDDataGridViewTextBoxColumn.DataPropertyName = "PASSWORD";
            this.pASSWORDDataGridViewTextBoxColumn.HeaderText = "ΚΩΔΙΚΟΣ";
            this.pASSWORDDataGridViewTextBoxColumn.Name = "pASSWORDDataGridViewTextBoxColumn";
            // 
            // cOLORDataGridViewTextBoxColumn
            // 
            this.cOLORDataGridViewTextBoxColumn.DataPropertyName = "COLOR";
            this.cOLORDataGridViewTextBoxColumn.HeaderText = "ΧΡΩΜΑ";
            this.cOLORDataGridViewTextBoxColumn.Name = "cOLORDataGridViewTextBoxColumn";
            // 
            // sUPPLIERDataGridViewTextBoxColumn
            // 
            this.sUPPLIERDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sUPPLIERDataGridViewTextBoxColumn.DataPropertyName = "SUPPLIER";
            this.sUPPLIERDataGridViewTextBoxColumn.DataSource = this.suppliersBindingSource;
            this.sUPPLIERDataGridViewTextBoxColumn.DisplayMember = "NAME";
            this.sUPPLIERDataGridViewTextBoxColumn.HeaderText = "ΠΡΟΜΗΘΕΥΤΗΣ";
            this.sUPPLIERDataGridViewTextBoxColumn.Name = "sUPPLIERDataGridViewTextBoxColumn";
            this.sUPPLIERDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sUPPLIERDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fIRSTDIMENSIONDataGridViewTextBoxColumn
            // 
            this.fIRSTDIMENSIONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fIRSTDIMENSIONDataGridViewTextBoxColumn.DataPropertyName = "FIRSTDIMENSION";
            this.fIRSTDIMENSIONDataGridViewTextBoxColumn.HeaderText = "ΑΡΧΙΚΗ ΔΙΑΣΤΑΣΗ";
            this.fIRSTDIMENSIONDataGridViewTextBoxColumn.Name = "fIRSTDIMENSIONDataGridViewTextBoxColumn";
            // 
            // cUTDIMENSIONDataGridViewTextBoxColumn
            // 
            this.cUTDIMENSIONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cUTDIMENSIONDataGridViewTextBoxColumn.DataPropertyName = "CUTDIMENSION";
            this.cUTDIMENSIONDataGridViewTextBoxColumn.HeaderText = "ΔΙΑΣΤΑΣΗ ΚΟΠΗΣ";
            this.cUTDIMENSIONDataGridViewTextBoxColumn.Name = "cUTDIMENSIONDataGridViewTextBoxColumn";
            // 
            // cOSTDataGridViewTextBoxColumn
            // 
            this.cOSTDataGridViewTextBoxColumn.DataPropertyName = "COST";
            this.cOSTDataGridViewTextBoxColumn.HeaderText = "ΚΟΣΤΟΣ";
            this.cOSTDataGridViewTextBoxColumn.Name = "cOSTDataGridViewTextBoxColumn";
            // 
            // Ylika7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 532);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ylika7";
            this.Text = "Υλικά created by Stathis Votsis software engineer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ylika7_FormClosing);
            this.Load += new System.EventHandler(this.Ylika7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evotsis_gspotDataSet27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ylika7BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evotsis_gspotDataSet26)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private evotsis_gspotDataSet26 evotsis_gspotDataSet26;
        private System.Windows.Forms.BindingSource ylika7BindingSource;
        private evotsis_gspotDataSet26TableAdapters.Ylika7TableAdapter ylika7TableAdapter;
        private evotsis_gspotDataSet27 evotsis_gspotDataSet27;
        private System.Windows.Forms.BindingSource suppliersBindingSource;
        private evotsis_gspotDataSet27TableAdapters.SuppliersTableAdapter suppliersTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn aADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPTIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pASSWORDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sUPPLIERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIRSTDIMENSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUTDIMENSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOSTDataGridViewTextBoxColumn;
    }
}