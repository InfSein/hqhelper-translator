namespace hqhelper_translator
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
            MainMenuStrip = new MenuStrip();
            版本信息ToolStripMenuItem = new ToolStripMenuItem();
            hqHelper仓库目录ToolStripMenuItem = new ToolStripMenuItem();
            帮助文档ToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            label4 = new Label();
            BtnPosiRepo = new Button();
            TbxPosiRepo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            OpenFileDialogPosiRepo = new OpenFileDialog();
            groupBox2 = new GroupBox();
            label6 = new Label();
            BtnResolveToExcel = new Button();
            label5 = new Label();
            groupBox3 = new GroupBox();
            linkLabel3 = new LinkLabel();
            label10 = new Label();
            linkLabel2 = new LinkLabel();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            groupBox4 = new GroupBox();
            label12 = new Label();
            BtnRegroupToJson = new Button();
            label11 = new Label();
            label13 = new Label();
            工具ToolStripMenuItem = new ToolStripMenuItem();
            导入国服拆包ToolStripMenuItem = new ToolStripMenuItem();
            MainMenuStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.ImageScalingSize = new Size(32, 32);
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { 版本信息ToolStripMenuItem, 工具ToolStripMenuItem, hqHelper仓库目录ToolStripMenuItem, 帮助文档ToolStripMenuItem });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size(1101, 42);
            MainMenuStrip.TabIndex = 0;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // 版本信息ToolStripMenuItem
            // 
            版本信息ToolStripMenuItem.Name = "版本信息ToolStripMenuItem";
            版本信息ToolStripMenuItem.Size = new Size(130, 38);
            版本信息ToolStripMenuItem.Text = "版本信息";
            // 
            // hqHelper仓库目录ToolStripMenuItem
            // 
            hqHelper仓库目录ToolStripMenuItem.Name = "hqHelper仓库目录ToolStripMenuItem";
            hqHelper仓库目录ToolStripMenuItem.Size = new Size(248, 38);
            hqHelper仓库目录ToolStripMenuItem.Text = "HqHelper 仓库目录";
            hqHelper仓库目录ToolStripMenuItem.Click += hqHelper仓库目录ToolStripMenuItem_Click;
            // 
            // 帮助文档ToolStripMenuItem
            // 
            帮助文档ToolStripMenuItem.Name = "帮助文档ToolStripMenuItem";
            帮助文档ToolStripMenuItem.Size = new Size(130, 38);
            帮助文档ToolStripMenuItem.Text = "帮助文档";
            帮助文档ToolStripMenuItem.Click += 帮助文档ToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(BtnPosiRepo);
            groupBox1.Controls.Add(TbxPosiRepo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1077, 255);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "第1步：定位HqHelper目录";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 141);
            label4.Name = "label4";
            label4.Size = new Size(974, 93);
            label4.TabIndex = 6;
            label4.Text = "在定位成功之后，上方输入框会显示本地仓库的路径。\r\n路径会被记录，以便您每次打开程序后不需要重新选择。\r\n但如果您发现输入框没有显示路径，或是您更改了本地仓库的存放位置，请重新定位一次。";
            // 
            // BtnPosiRepo
            // 
            BtnPosiRepo.Location = new Point(50, 99);
            BtnPosiRepo.Name = "BtnPosiRepo";
            BtnPosiRepo.Size = new Size(177, 39);
            BtnPosiRepo.TabIndex = 5;
            BtnPosiRepo.Text = "定位...";
            BtnPosiRepo.UseVisualStyleBackColor = true;
            BtnPosiRepo.Click += BtnPosiRepo_Click;
            // 
            // TbxPosiRepo
            // 
            TbxPosiRepo.Location = new Point(233, 100);
            TbxPosiRepo.Name = "TbxPosiRepo";
            TbxPosiRepo.ReadOnly = true;
            TbxPosiRepo.Size = new Size(788, 38);
            TbxPosiRepo.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 65);
            label3.Name = "label3";
            label3.Size = new Size(891, 31);
            label3.TabIndex = 3;
            label3.Text = "之后，点击下方的定位按钮，在资源管理器中选择本地仓库的 README.md 文件。";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(382, 34);
            label2.Name = "label2";
            label2.Size = new Size(448, 31);
            label2.TabIndex = 2;
            label2.Text = "仓库，然后将Fork后的仓库拉取到本地。";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(157, 34);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(232, 31);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "hqhelper-dawntrail";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 34);
            label1.Name = "label1";
            label1.Size = new Size(112, 31);
            label1.TabIndex = 0;
            label1.Text = "请先Fork";
            // 
            // OpenFileDialogPosiRepo
            // 
            OpenFileDialogPosiRepo.Filter = "仓库的说明文档|README.md";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(BtnResolveToExcel);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(12, 303);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1077, 288);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "第2步：将HqHelper的JSON文件解析成Excel文件";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 202);
            label6.Name = "label6";
            label6.Size = new Size(805, 62);
            label6.TabIndex = 2;
            label6.Text = "请注意：点击这个按钮之后会提取 HqHelper 仓库的当前数据。\r\n之前的 Excel 文件将会被覆盖。请在处理之前确认您已经提交上次的更改。";
            // 
            // BtnResolveToExcel
            // 
            BtnResolveToExcel.Location = new Point(50, 130);
            BtnResolveToExcel.Name = "BtnResolveToExcel";
            BtnResolveToExcel.Size = new Size(210, 69);
            BtnResolveToExcel.TabIndex = 1;
            BtnResolveToExcel.Text = "开始处理";
            BtnResolveToExcel.UseVisualStyleBackColor = true;
            BtnResolveToExcel.Click += BtnResolveToExcel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 34);
            label5.Name = "label5";
            label5.Size = new Size(816, 93);
            label5.TabIndex = 0;
            label5.Text = "请首先确保您已经在第1步正确地定位了 HqHelper 仓库目录。\r\n如果没有问题，请点击下方的处理按钮。\r\n这将会把 HqHelper 中待翻译的 JSON 文件处理成可供编辑的 Excel 文件。";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(linkLabel3);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(linkLabel2);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(12, 597);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1077, 150);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "第3步：翻译生成的Excel文件";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(539, 96);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(110, 31);
            linkLabel3.TabIndex = 5;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "帮助文档";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(50, 96);
            label10.Name = "label10";
            label10.Size = new Size(493, 31);
            label10.TabIndex = 4;
            label10.Text = "各个 Excel 文件的翻译注意事项请参阅我们的";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(203, 65);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(62, 31);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "这里";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(258, 65);
            label9.Name = "label9";
            label9.Size = new Size(397, 31);
            label9.TabIndex = 3;
            label9.Text = "来手动打开 Excel 文件的存放目录。";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(50, 65);
            label8.Name = "label8";
            label8.Size = new Size(158, 31);
            label8.TabIndex = 1;
            label8.Text = "您也可以点击";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(50, 34);
            label7.Name = "label7";
            label7.Size = new Size(710, 31);
            label7.TabIndex = 0;
            label7.Text = "在上一步处理结束之后，此工具会自动打开生成文件所在的目录。";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(BtnRegroupToJson);
            groupBox4.Controls.Add(label11);
            groupBox4.Location = new Point(12, 753);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1077, 286);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "第4步：将翻译好的Excel文件重组为项目JSON文件";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(50, 171);
            label12.Name = "label12";
            label12.Size = new Size(932, 93);
            label12.TabIndex = 3;
            label12.Text = "在重组成功之后，您就可以将本地更改通过 GIT 管理工具推送，\r\n然后在 HqHelper 仓库发起 Pull Request。\r\n请注意审查具体的 JSON 文件更改，如果发现异常的大面积文本删除，请及时联系我。";
            // 
            // BtnRegroupToJson
            // 
            BtnRegroupToJson.Location = new Point(50, 99);
            BtnRegroupToJson.Name = "BtnRegroupToJson";
            BtnRegroupToJson.Size = new Size(210, 69);
            BtnRegroupToJson.TabIndex = 2;
            BtnRegroupToJson.Text = "开始重组";
            BtnRegroupToJson.UseVisualStyleBackColor = true;
            BtnRegroupToJson.Click += BtnRegroupToJson_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(50, 34);
            label11.Name = "label11";
            label11.Size = new Size(946, 62);
            label11.TabIndex = 0;
            label11.Text = "在您翻译完需要的 Excel 文件之后，请点击下方按钮。\r\n这将会把存放目录下的 Excel 文件依次翻译回 JSON文件，并保存到 HqHelper目录下。";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 1042);
            label13.Name = "label13";
            label13.Size = new Size(192, 31);
            label13.TabIndex = 5;
            label13.Text = "© InfSein, 2024";
            // 
            // 工具ToolStripMenuItem
            // 
            工具ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 导入国服拆包ToolStripMenuItem });
            工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            工具ToolStripMenuItem.Size = new Size(82, 38);
            工具ToolStripMenuItem.Text = "工具";
            // 
            // 导入国服拆包ToolStripMenuItem
            // 
            导入国服拆包ToolStripMenuItem.Name = "导入国服拆包ToolStripMenuItem";
            导入国服拆包ToolStripMenuItem.Size = new Size(359, 44);
            导入国服拆包ToolStripMenuItem.Text = "导入国服拆包";
            导入国服拆包ToolStripMenuItem.Click += 导入国服拆包ToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 1088);
            Controls.Add(label13);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(MainMenuStrip);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HqHelper 本地化协作工具";
            Load += MainForm_Load;
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenuStrip;
        private ToolStripMenuItem 帮助文档ToolStripMenuItem;
        private GroupBox groupBox1;
        private Label label1;
        private Label label4;
        private Button BtnPosiRepo;
        private TextBox TbxPosiRepo;
        private Label label3;
        private Label label2;
        private LinkLabel linkLabel1;
        private OpenFileDialog OpenFileDialogPosiRepo;
        private GroupBox groupBox2;
        private Label label6;
        private Button BtnResolveToExcel;
        private Label label5;
        private GroupBox groupBox3;
        private LinkLabel linkLabel3;
        private Label label10;
        private LinkLabel linkLabel2;
        private Label label9;
        private Label label8;
        private Label label7;
        private GroupBox groupBox4;
        private Label label12;
        private Button BtnRegroupToJson;
        private Label label11;
        private Label label13;
        private ToolStripMenuItem hqHelper仓库目录ToolStripMenuItem;
        private ToolStripMenuItem 版本信息ToolStripMenuItem;
        private ToolStripMenuItem 工具ToolStripMenuItem;
        private ToolStripMenuItem 导入国服拆包ToolStripMenuItem;
    }
}