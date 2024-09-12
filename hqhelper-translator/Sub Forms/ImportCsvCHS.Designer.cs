namespace hqhelper_translator.Sub_Forms
{
    partial class ImportCsvCHS
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            BtnPosiCSV = new Button();
            TbxPosiCSV = new TextBox();
            groupBox2 = new GroupBox();
            groupBox5 = new GroupBox();
            CbxOutputCompares = new CheckBox();
            groupBox4 = new GroupBox();
            LabelOperateModeDesc = new Label();
            groupBox3 = new GroupBox();
            CbOperateMode = new ComboBox();
            groupBox6 = new GroupBox();
            BtnSubmit = new Button();
            OpenFileDialogPosiCSV = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(BtnPosiCSV);
            groupBox1.Controls.Add(TbxPosiCSV);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1016, 127);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "国服拆包文件路径";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 79);
            label1.Name = "label1";
            label1.Size = new Size(741, 31);
            label1.TabIndex = 8;
            label1.Text = "应确保CSV格式为：第1列道具ID、第2列中文名、第10列道具描述。";
            // 
            // BtnPosiCSV
            // 
            BtnPosiCSV.Location = new Point(24, 37);
            BtnPosiCSV.Name = "BtnPosiCSV";
            BtnPosiCSV.Size = new Size(177, 39);
            BtnPosiCSV.TabIndex = 7;
            BtnPosiCSV.Text = "定位...";
            BtnPosiCSV.UseVisualStyleBackColor = true;
            BtnPosiCSV.Click += BtnPosiCSV_Click;
            // 
            // TbxPosiCSV
            // 
            TbxPosiCSV.Location = new Point(207, 38);
            TbxPosiCSV.Name = "TbxPosiCSV";
            TbxPosiCSV.ReadOnly = true;
            TbxPosiCSV.Size = new Size(788, 38);
            TbxPosiCSV.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(12, 145);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1016, 250);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "操作选项";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(CbxOutputCompares);
            groupBox5.Location = new Point(24, 137);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(971, 95);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "其他";
            // 
            // CbxOutputCompares
            // 
            CbxOutputCompares.AutoSize = true;
            CbxOutputCompares.Checked = true;
            CbxOutputCompares.CheckState = CheckState.Checked;
            CbxOutputCompares.Location = new Point(23, 37);
            CbxOutputCompares.Name = "CbxOutputCompares";
            CbxOutputCompares.Size = new Size(190, 35);
            CbxOutputCompares.TabIndex = 0;
            CbxOutputCompares.Text = "输出前后对比";
            CbxOutputCompares.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(LabelOperateModeDesc);
            groupBox4.Location = new Point(385, 37);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(610, 94);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "模式说明";
            // 
            // LabelOperateModeDesc
            // 
            LabelOperateModeDesc.AutoSize = true;
            LabelOperateModeDesc.Location = new Point(22, 45);
            LabelOperateModeDesc.Name = "LabelOperateModeDesc";
            LabelOperateModeDesc.Size = new Size(134, 31);
            LabelOperateModeDesc.TabIndex = 0;
            LabelOperateModeDesc.Text = "说明文本。";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(CbOperateMode);
            groupBox3.Location = new Point(24, 37);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(355, 94);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "模式";
            // 
            // CbOperateMode
            // 
            CbOperateMode.DropDownStyle = ComboBoxStyle.DropDownList;
            CbOperateMode.FormattingEnabled = true;
            CbOperateMode.Items.AddRange(new object[] { "预检模式", "正式执行" });
            CbOperateMode.Location = new Point(23, 37);
            CbOperateMode.Name = "CbOperateMode";
            CbOperateMode.Size = new Size(308, 39);
            CbOperateMode.TabIndex = 0;
            CbOperateMode.SelectedIndexChanged += CbOperateMode_SelectedIndexChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(BtnSubmit);
            groupBox6.Location = new Point(12, 401);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(1016, 135);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            groupBox6.Text = "执行";
            // 
            // BtnSubmit
            // 
            BtnSubmit.Location = new Point(773, 37);
            BtnSubmit.Name = "BtnSubmit";
            BtnSubmit.Size = new Size(222, 75);
            BtnSubmit.TabIndex = 0;
            BtnSubmit.Text = "开始";
            BtnSubmit.UseVisualStyleBackColor = true;
            BtnSubmit.Click += BtnSubmit_Click;
            // 
            // OpenFileDialogPosiCSV
            // 
            OpenFileDialogPosiCSV.FileName = "openFileDialog1";
            // 
            // ImportCsvCHS
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 548);
            Controls.Add(groupBox6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportCsvCHS";
            StartPosition = FormStartPosition.CenterParent;
            Text = "导入国服拆包文件";
            Load += ImportCsvCHS_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button BtnPosiCSV;
        private TextBox TbxPosiCSV;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox5;
        private CheckBox CbxOutputCompares;
        private GroupBox groupBox4;
        private Label LabelOperateModeDesc;
        private GroupBox groupBox3;
        private ComboBox CbOperateMode;
        private GroupBox groupBox6;
        private Button BtnSubmit;
        private OpenFileDialog OpenFileDialogPosiCSV;
    }
}