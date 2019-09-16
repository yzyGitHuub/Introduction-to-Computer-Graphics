namespace ProjectionAndRotation
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.startEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.xCordinateToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.yCordinateToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.zCordinateToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.selectToolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.applyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.roateToolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.roateDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roateStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roateSpeedToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.roateSpeedToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.startToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxDown = new System.Windows.Forms.PictureBox();
            this.pictureBoxUp = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.inputTextBox1 = new System.Windows.Forms.TextBox();
            this.inputButton1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolsMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolsMenuItem
            // 
            this.mainToolsMenuItem.Name = "mainToolsMenuItem";
            this.mainToolsMenuItem.Size = new System.Drawing.Size(68, 21);
            this.mainToolsMenuItem.Text = "主要工具";
            this.mainToolsMenuItem.Click += new System.EventHandler(this.mainToolsMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripSubMenuItem,
            this.aboutToolStripSubMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.helpToolStripMenuItem.Text = "帮助";
            // 
            // helpToolStripSubMenuItem
            // 
            this.helpToolStripSubMenuItem.Name = "helpToolStripSubMenuItem";
            this.helpToolStripSubMenuItem.Size = new System.Drawing.Size(100, 22);
            this.helpToolStripSubMenuItem.Text = "帮助";
            this.helpToolStripSubMenuItem.Click += new System.EventHandler(this.helpToolStripSubMenuItem_Click);
            // 
            // aboutToolStripSubMenuItem
            // 
            this.aboutToolStripSubMenuItem.Name = "aboutToolStripSubMenuItem";
            this.aboutToolStripSubMenuItem.Size = new System.Drawing.Size(100, 22);
            this.aboutToolStripSubMenuItem.Text = "关于";
            this.aboutToolStripSubMenuItem.Click += new System.EventHandler(this.aboutToolStripSubMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.xCordinateToolStripTextBox,
            this.toolStripLabel2,
            this.yCordinateToolStripTextBox,
            this.toolStripLabel3,
            this.zCordinateToolStripTextBox,
            this.selectToolStripComboBox1,
            this.applyToolStripButton,
            this.toolStripButton1,
            this.roateToolStrip,
            this.roateSpeedToolStripLabel,
            this.roateSpeedToolStripTextBox,
            this.startToolStripButton2,
            this.stopToolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(625, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEditToolStripMenuItem,
            this.endEditToolStripMenuItem,
            this.saveEditToolStripMenuItem,
            this.importToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "编辑";
            // 
            // startEditToolStripMenuItem
            // 
            this.startEditToolStripMenuItem.Name = "startEditToolStripMenuItem";
            this.startEditToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startEditToolStripMenuItem.Text = "开始编辑";
            this.startEditToolStripMenuItem.Click += new System.EventHandler(this.startEditToolStripMenuItem_Click);
            // 
            // endEditToolStripMenuItem
            // 
            this.endEditToolStripMenuItem.Enabled = false;
            this.endEditToolStripMenuItem.Name = "endEditToolStripMenuItem";
            this.endEditToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.endEditToolStripMenuItem.Text = "结束编辑";
            this.endEditToolStripMenuItem.Click += new System.EventHandler(this.endEditToolStripMenuItem_Click);
            // 
            // saveEditToolStripMenuItem
            // 
            this.saveEditToolStripMenuItem.Name = "saveEditToolStripMenuItem";
            this.saveEditToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveEditToolStripMenuItem.Text = "保存编辑";
            this.saveEditToolStripMenuItem.Click += new System.EventHandler(this.saveEditToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "导入";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel1.Text = "投影方向 x:";
            // 
            // xCordinateToolStripTextBox
            // 
            this.xCordinateToolStripTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.xCordinateToolStripTextBox.Enabled = false;
            this.xCordinateToolStripTextBox.Name = "xCordinateToolStripTextBox";
            this.xCordinateToolStripTextBox.Size = new System.Drawing.Size(40, 25);
            this.xCordinateToolStripTextBox.Text = "20";
            this.xCordinateToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xCordinateToolStripTextBox_KeyPress);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(17, 22);
            this.toolStripLabel2.Text = "y:";
            // 
            // yCordinateToolStripTextBox
            // 
            this.yCordinateToolStripTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.yCordinateToolStripTextBox.Enabled = false;
            this.yCordinateToolStripTextBox.Name = "yCordinateToolStripTextBox";
            this.yCordinateToolStripTextBox.Size = new System.Drawing.Size(40, 25);
            this.yCordinateToolStripTextBox.Text = "20";
            this.yCordinateToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yCordinateToolStripTextBox_KeyPress);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(17, 22);
            this.toolStripLabel3.Text = "z:";
            // 
            // zCordinateToolStripTextBox
            // 
            this.zCordinateToolStripTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.zCordinateToolStripTextBox.Enabled = false;
            this.zCordinateToolStripTextBox.Name = "zCordinateToolStripTextBox";
            this.zCordinateToolStripTextBox.Size = new System.Drawing.Size(40, 25);
            this.zCordinateToolStripTextBox.Text = "200";
            this.zCordinateToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zCordinateToolStripTextBox_KeyPress);
            // 
            // selectToolStripComboBox1
            // 
            this.selectToolStripComboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.selectToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectToolStripComboBox1.Items.AddRange(new object[] {
            "请选择",
            "平行投影",
            "透视投影"});
            this.selectToolStripComboBox1.Name = "selectToolStripComboBox1";
            this.selectToolStripComboBox1.Size = new System.Drawing.Size(80, 25);
            this.selectToolStripComboBox1.ToolTipText = "投影方式选择\r\n在下拉菜单中选择想要的投影方式。";
            this.selectToolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.selectToolStripComboBox1_SelectedIndexChanged);
            // 
            // applyToolStripButton
            // 
            this.applyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.applyToolStripButton.Enabled = false;
            this.applyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("applyToolStripButton.Image")));
            this.applyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.applyToolStripButton.Name = "applyToolStripButton";
            this.applyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.applyToolStripButton.Text = "单击以确认修改";
            this.applyToolStripButton.ToolTipText = "确认修改\r\n单击以使修改生效。";
            this.applyToolStripButton.Click += new System.EventHandler(this.applyTtripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // roateToolStrip
            // 
            this.roateToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.roateToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roateDefaultToolStripMenuItem,
            this.roateStopToolStripMenuItem});
            this.roateToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("roateToolStrip.Image")));
            this.roateToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.roateToolStrip.Name = "roateToolStrip";
            this.roateToolStrip.Size = new System.Drawing.Size(45, 22);
            this.roateToolStrip.Text = "旋转";
            // 
            // roateDefaultToolStripMenuItem
            // 
            this.roateDefaultToolStripMenuItem.Name = "roateDefaultToolStripMenuItem";
            this.roateDefaultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.roateDefaultToolStripMenuItem.Text = "开始自动旋转";
            this.roateDefaultToolStripMenuItem.Click += new System.EventHandler(this.roateDefaultToolStripMenuItem_Click);
            // 
            // roateStopToolStripMenuItem
            // 
            this.roateStopToolStripMenuItem.Enabled = false;
            this.roateStopToolStripMenuItem.Name = "roateStopToolStripMenuItem";
            this.roateStopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.roateStopToolStripMenuItem.Text = "停止自动旋转";
            this.roateStopToolStripMenuItem.Click += new System.EventHandler(this.roateStopToolStripMenuItem_Click);
            // 
            // roateSpeedToolStripLabel
            // 
            this.roateSpeedToolStripLabel.Name = "roateSpeedToolStripLabel";
            this.roateSpeedToolStripLabel.Size = new System.Drawing.Size(59, 22);
            this.roateSpeedToolStripLabel.Text = "旋转速度:";
            // 
            // roateSpeedToolStripTextBox
            // 
            this.roateSpeedToolStripTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.roateSpeedToolStripTextBox.Enabled = false;
            this.roateSpeedToolStripTextBox.Name = "roateSpeedToolStripTextBox";
            this.roateSpeedToolStripTextBox.Size = new System.Drawing.Size(53, 25);
            this.roateSpeedToolStripTextBox.Text = "100";
            this.roateSpeedToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roateSpeedToolStripTextBox_KeyPress);
            // 
            // startToolStripButton2
            // 
            this.startToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startToolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripButton2.Image")));
            this.startToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startToolStripButton2.Name = "startToolStripButton2";
            this.startToolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.startToolStripButton2.Text = "toolStripButton2";
            this.startToolStripButton2.ToolTipText = "开始旋转\r\n单击开始自动旋转。";
            this.startToolStripButton2.Click += new System.EventHandler(this.startToolStripButton2_Click);
            // 
            // stopToolStripButton3
            // 
            this.stopToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripButton3.Enabled = false;
            this.stopToolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("stopToolStripButton3.Image")));
            this.stopToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton3.Name = "stopToolStripButton3";
            this.stopToolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripButton3.Text = "toolStripButton3";
            this.stopToolStripButton3.ToolTipText = "停止自动旋转\r\n单击以停止自动旋转。";
            this.stopToolStripButton3.Click += new System.EventHandler(this.stopToolStripButton3_Click);
            // 
            // pictureBoxDown
            // 
            this.pictureBoxDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDown.Location = new System.Drawing.Point(12, 53);
            this.pictureBoxDown.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxDown.Name = "pictureBoxDown";
            this.pictureBoxDown.Size = new System.Drawing.Size(601, 371);
            this.pictureBoxDown.TabIndex = 2;
            this.pictureBoxDown.TabStop = false;
            this.pictureBoxDown.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDown_Paint);
            // 
            // pictureBoxUp
            // 
            this.pictureBoxUp.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxUp.InitialImage = null;
            this.pictureBoxUp.Location = new System.Drawing.Point(0, 50);
            this.pictureBoxUp.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxUp.Name = "pictureBoxUp";
            this.pictureBoxUp.Size = new System.Drawing.Size(625, 386);
            this.pictureBoxUp.TabIndex = 3;
            this.pictureBoxUp.TabStop = false;
            this.pictureBoxUp.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxUp_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // inputTextBox1
            // 
            this.inputTextBox1.Location = new System.Drawing.Point(45, 64);
            this.inputTextBox1.Multiline = true;
            this.inputTextBox1.Name = "inputTextBox1";
            this.inputTextBox1.Size = new System.Drawing.Size(190, 161);
            this.inputTextBox1.TabIndex = 4;
            this.inputTextBox1.Text = resources.GetString("inputTextBox1.Text");
            this.inputTextBox1.Visible = false;
            // 
            // inputButton1
            // 
            this.inputButton1.Location = new System.Drawing.Point(45, 231);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Size = new System.Drawing.Size(75, 23);
            this.inputButton1.TabIndex = 5;
            this.inputButton1.Text = "确认";
            this.inputButton1.UseVisualStyleBackColor = true;
            this.inputButton1.Visible = false;
            this.inputButton1.Click += new System.EventHandler(this.inputButton1_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 436);
            this.Controls.Add(this.inputButton1);
            this.Controls.Add(this.inputTextBox1);
            this.Controls.Add(this.pictureBoxUp);
            this.Controls.Add(this.pictureBoxDown);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.Text = "投影和旋转";
            this.Resize += new System.EventHandler(this.Editor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripSubMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem startEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox xCordinateToolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox yCordinateToolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox zCordinateToolStripTextBox;
        private System.Windows.Forms.ToolStripComboBox selectToolStripComboBox1;
        private System.Windows.Forms.ToolStripButton applyToolStripButton;
        private System.Windows.Forms.PictureBox pictureBoxDown;
        private System.Windows.Forms.PictureBox pictureBoxUp;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripDropDownButton roateToolStrip;
        private System.Windows.Forms.ToolStripMenuItem roateDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roateStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel roateSpeedToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox roateSpeedToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton startToolStripButton2;
        private System.Windows.Forms.ToolStripButton stopToolStripButton3;
        private System.Windows.Forms.TextBox inputTextBox1;
        private System.Windows.Forms.Button inputButton1;
    }
}