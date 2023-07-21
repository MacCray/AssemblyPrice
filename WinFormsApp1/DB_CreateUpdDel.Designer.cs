
namespace AssemblyPrice
{
    partial class DB_CreateUpdDel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DB_CreateUpdDel));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbProductCompany = new System.Windows.Forms.RadioButton();
            this.rbSpc = new System.Windows.Forms.RadioButton();
            this.rbProduct = new System.Windows.Forms.RadioButton();
            this.rbCompany = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.rbSpcProduct = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StdProdDrowDownList = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CompanyDrowDownList = new System.Windows.Forms.ComboBox();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel.SetColumnSpan(this.dataGridView, 5);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(3, 393);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 64;
            this.dataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.Size = new System.Drawing.Size(1000, 297);
            this.dataGridView.TabIndex = 20;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.SizeChanged += new System.EventHandler(this.dataGridView1_SizeChanged);
            // 
            // btnDelete
            // 
            this.tableLayoutPanel.SetColumnSpan(this.btnDelete, 2);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Image = global::AssemblyPrice.Properties.Resources.remove;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(606, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(397, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Удаление записи из БД";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.tableLayoutPanel.SetColumnSpan(this.btnUpdate, 2);
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Image = global::AssemblyPrice.Properties.Resources.edit;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.Location = new System.Drawing.Point(606, 119);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(397, 40);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Редактирование записи";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.textBox3, 2);
            this.textBox3.Location = new System.Drawing.Point(204, 165);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(396, 27);
            this.textBox3.TabIndex = 15;
            this.textBox3.Visible = false;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.decimalInput);
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(0, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(396, 27);
            this.textBox2.TabIndex = 7;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(0, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 27);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel.SetColumnSpan(this.btnCreate, 2);
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.Image = global::AssemblyPrice.Properties.Resources.add;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.Location = new System.Drawing.Point(606, 198);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(397, 40);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Добавление записи в БД";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // rbProductCompany
            // 
            this.rbProductCompany.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbProductCompany.AutoSize = true;
            this.rbProductCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbProductCompany.Image = global::AssemblyPrice.Properties.Resources.price_tag;
            this.rbProductCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbProductCompany.Location = new System.Drawing.Point(606, 3);
            this.rbProductCompany.Name = "rbProductCompany";
            this.rbProductCompany.Size = new System.Drawing.Size(195, 64);
            this.rbProductCompany.TabIndex = 3;
            this.rbProductCompany.TabStop = true;
            this.rbProductCompany.Text = "Стоимость изделий у компаний";
            this.rbProductCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbProductCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbProductCompany.UseVisualStyleBackColor = true;
            this.rbProductCompany.CheckedChanged += new System.EventHandler(this.rbProductCompany_CheckedChanged);
            // 
            // rbSpc
            // 
            this.rbSpc.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSpc.AutoSize = true;
            this.rbSpc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSpc.Image = global::AssemblyPrice.Properties.Resources.Спецификация;
            this.rbSpc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbSpc.Location = new System.Drawing.Point(405, 3);
            this.rbSpc.Name = "rbSpc";
            this.rbSpc.Size = new System.Drawing.Size(195, 64);
            this.rbSpc.TabIndex = 2;
            this.rbSpc.TabStop = true;
            this.rbSpc.Text = "Спецификации";
            this.rbSpc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSpc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbSpc.UseVisualStyleBackColor = true;
            this.rbSpc.CheckedChanged += new System.EventHandler(this.rbSpc_CheckedChanged);
            // 
            // rbProduct
            // 
            this.rbProduct.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbProduct.AutoSize = true;
            this.rbProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbProduct.Image = global::AssemblyPrice.Properties.Resources.nut;
            this.rbProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbProduct.Location = new System.Drawing.Point(204, 3);
            this.rbProduct.Name = "rbProduct";
            this.rbProduct.Size = new System.Drawing.Size(195, 64);
            this.rbProduct.TabIndex = 1;
            this.rbProduct.TabStop = true;
            this.rbProduct.Text = "Стандартные изделия";
            this.rbProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbProduct.UseVisualStyleBackColor = true;
            this.rbProduct.CheckedChanged += new System.EventHandler(this.rbProduct_CheckedChanged);
            // 
            // rbCompany
            // 
            this.rbCompany.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCompany.AutoSize = true;
            this.rbCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbCompany.Image = global::AssemblyPrice.Properties.Resources.comapny;
            this.rbCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbCompany.Location = new System.Drawing.Point(3, 3);
            this.rbCompany.Name = "rbCompany";
            this.rbCompany.Size = new System.Drawing.Size(195, 64);
            this.rbCompany.TabIndex = 1;
            this.rbCompany.TabStop = true;
            this.rbCompany.Text = "Компании";
            this.rbCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbCompany.UseVisualStyleBackColor = true;
            this.rbCompany.CheckedChanged += new System.EventHandler(this.rbCompany_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.textBox4, 2);
            this.textBox4.Location = new System.Drawing.Point(204, 204);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(396, 27);
            this.textBox4.TabIndex = 16;
            this.textBox4.Visible = false;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.decimalInput);
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // rbSpcProduct
            // 
            this.rbSpcProduct.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSpcProduct.AutoSize = true;
            this.rbSpcProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSpcProduct.Image = global::AssemblyPrice.Properties.Resources.Спецификация_Info;
            this.rbSpcProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbSpcProduct.Location = new System.Drawing.Point(807, 3);
            this.rbSpcProduct.Name = "rbSpcProduct";
            this.rbSpcProduct.Size = new System.Drawing.Size(196, 64);
            this.rbSpcProduct.TabIndex = 17;
            this.rbSpcProduct.TabStop = true;
            this.rbSpcProduct.Text = "Количество изделий в спецификациях";
            this.rbSpcProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSpcProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rbSpcProduct.UseVisualStyleBackColor = true;
            this.rbSpcProduct.CheckedChanged += new System.EventHandler(this.rbSpcProduct_CheckedChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.textBox5, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.rbSpcProduct, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.textBox4, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.rbCompany, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.rbProduct, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.rbSpc, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.rbProductCompany, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnOpenFile, 3, 6);
            this.tableLayoutPanel.Controls.Add(this.btnCreate, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.textBox3, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.btnUpdate, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.btnDelete, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.dataGridView, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.imgBox, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 8;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1006, 693);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.textBox5, 2);
            this.textBox5.Location = new System.Drawing.Point(204, 244);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(396, 27);
            this.textBox5.TabIndex = 21;
            this.textBox5.Visible = false;
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // btnOpenFile
            // 
            this.tableLayoutPanel.SetColumnSpan(this.btnOpenFile, 2);
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenFile.Image = global::AssemblyPrice.Properties.Resources.open_file;
            this.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.Location = new System.Drawing.Point(606, 277);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(397, 110);
            this.btnOpenFile.TabIndex = 9;
            this.btnOpenFile.Text = "Открыть изображение для добавления";
            this.btnOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Visible = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel.SetColumnSpan(this.imgBox, 2);
            this.imgBox.Location = new System.Drawing.Point(309, 277);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(186, 110);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox.TabIndex = 12;
            this.imgBox.TabStop = false;
            this.imgBox.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.StdProdDrowDownList);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(204, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 31);
            this.panel1.TabIndex = 23;
            // 
            // StdProdDrowDownList
            // 
            this.StdProdDrowDownList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StdProdDrowDownList.FormattingEnabled = true;
            this.StdProdDrowDownList.Location = new System.Drawing.Point(0, 2);
            this.StdProdDrowDownList.Name = "StdProdDrowDownList";
            this.StdProdDrowDownList.Size = new System.Drawing.Size(396, 28);
            this.StdProdDrowDownList.TabIndex = 5;
            this.StdProdDrowDownList.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.CompanyDrowDownList);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(204, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 32);
            this.panel2.TabIndex = 24;
            // 
            // CompanyDrowDownList
            // 
            this.CompanyDrowDownList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyDrowDownList.FormattingEnabled = true;
            this.CompanyDrowDownList.Location = new System.Drawing.Point(0, 2);
            this.CompanyDrowDownList.Name = "CompanyDrowDownList";
            this.CompanyDrowDownList.Size = new System.Drawing.Size(396, 28);
            this.CompanyDrowDownList.TabIndex = 8;
            this.CompanyDrowDownList.Visible = false;
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHelp});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1006, 28);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "Menu";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::AssemblyPrice.Properties.Resources.information;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(103, 24);
            this.btnHelp.Text = "Помощь";
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHelp.ToolTipText = "Отображает дополнительную информацию по работе с текущей таблицей";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // DB_CreateUpdDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "DB_CreateUpdDel";
            this.Text = "Работа с базой данных";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton rbCompany;
        private System.Windows.Forms.RadioButton rbProduct;
        private System.Windows.Forms.RadioButton rbSpc;
        private System.Windows.Forms.RadioButton rbProductCompany;
        private System.Windows.Forms.RadioButton rbSpcProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox StdProdDrowDownList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CompanyDrowDownList;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
    }
}