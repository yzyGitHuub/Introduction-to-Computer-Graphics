namespace BresenhamDemo
{
    partial class BresenhamDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.子菜单1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDA方法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenham方法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.错误画法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.子菜单2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDA方法ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenham算法ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.错误画法ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制圆形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenham算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正负法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空画布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多个显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.混合显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 331);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick_1);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.绘制状态ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.子菜单1ToolStripMenuItem,
            this.子菜单2ToolStripMenuItem,
            this.绘制圆形ToolStripMenuItem,
            this.清空画布ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 子菜单1ToolStripMenuItem
            // 
            this.子菜单1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDA方法ToolStripMenuItem,
            this.bresenham方法ToolStripMenuItem,
            this.错误画法ToolStripMenuItem});
            this.子菜单1ToolStripMenuItem.Name = "子菜单1ToolStripMenuItem";
            this.子菜单1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.子菜单1ToolStripMenuItem.Text = "绘制线段";
            // 
            // dDA方法ToolStripMenuItem
            // 
            this.dDA方法ToolStripMenuItem.Name = "dDA方法ToolStripMenuItem";
            this.dDA方法ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.dDA方法ToolStripMenuItem.Text = "DDA方法";
            this.dDA方法ToolStripMenuItem.Click += new System.EventHandler(this.dDA方法ToolStripMenuItem_Click);
            // 
            // bresenham方法ToolStripMenuItem
            // 
            this.bresenham方法ToolStripMenuItem.Name = "bresenham方法ToolStripMenuItem";
            this.bresenham方法ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bresenham方法ToolStripMenuItem.Text = "Bresenham方法";
            this.bresenham方法ToolStripMenuItem.Click += new System.EventHandler(this.bresenham方法ToolStripMenuItem_Click);
            // 
            // 错误画法ToolStripMenuItem
            // 
            this.错误画法ToolStripMenuItem.Name = "错误画法ToolStripMenuItem";
            this.错误画法ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.错误画法ToolStripMenuItem.Text = "错误画法";
            this.错误画法ToolStripMenuItem.Click += new System.EventHandler(this.错误画法ToolStripMenuItem_Click);
            // 
            // 子菜单2ToolStripMenuItem
            // 
            this.子菜单2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDA方法ToolStripMenuItem1,
            this.bresenham算法ToolStripMenuItem1,
            this.错误画法ToolStripMenuItem1});
            this.子菜单2ToolStripMenuItem.Name = "子菜单2ToolStripMenuItem";
            this.子菜单2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.子菜单2ToolStripMenuItem.Text = "绘制折线";
            // 
            // dDA方法ToolStripMenuItem1
            // 
            this.dDA方法ToolStripMenuItem1.Name = "dDA方法ToolStripMenuItem1";
            this.dDA方法ToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.dDA方法ToolStripMenuItem1.Text = "DDA方法";
            this.dDA方法ToolStripMenuItem1.Click += new System.EventHandler(this.dDA方法ToolStripMenuItem1_Click);
            // 
            // bresenham算法ToolStripMenuItem1
            // 
            this.bresenham算法ToolStripMenuItem1.Name = "bresenham算法ToolStripMenuItem1";
            this.bresenham算法ToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.bresenham算法ToolStripMenuItem1.Text = "Bresenham算法";
            this.bresenham算法ToolStripMenuItem1.Click += new System.EventHandler(this.bresenham算法ToolStripMenuItem1_Click);
            // 
            // 错误画法ToolStripMenuItem1
            // 
            this.错误画法ToolStripMenuItem1.Name = "错误画法ToolStripMenuItem1";
            this.错误画法ToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.错误画法ToolStripMenuItem1.Text = "错误画法";
            this.错误画法ToolStripMenuItem1.Click += new System.EventHandler(this.错误画法ToolStripMenuItem1_Click);
            // 
            // 绘制圆形ToolStripMenuItem
            // 
            this.绘制圆形ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.正负法ToolStripMenuItem,
            this.bresenham算法ToolStripMenuItem});
            this.绘制圆形ToolStripMenuItem.Name = "绘制圆形ToolStripMenuItem";
            this.绘制圆形ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.绘制圆形ToolStripMenuItem.Text = "绘制圆形";
            // 
            // bresenham算法ToolStripMenuItem
            // 
            this.bresenham算法ToolStripMenuItem.Name = "bresenham算法ToolStripMenuItem";
            this.bresenham算法ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bresenham算法ToolStripMenuItem.Text = "Bresenham算法";
            this.bresenham算法ToolStripMenuItem.Click += new System.EventHandler(this.bresenham算法ToolStripMenuItem_Click);
            // 
            // 正负法ToolStripMenuItem
            // 
            this.正负法ToolStripMenuItem.Name = "正负法ToolStripMenuItem";
            this.正负法ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.正负法ToolStripMenuItem.Text = "正负法";
            this.正负法ToolStripMenuItem.Click += new System.EventHandler(this.正负法ToolStripMenuItem_Click);
            // 
            // 清空画布ToolStripMenuItem
            // 
            this.清空画布ToolStripMenuItem.Enabled = false;
            this.清空画布ToolStripMenuItem.Name = "清空画布ToolStripMenuItem";
            this.清空画布ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.清空画布ToolStripMenuItem.Text = "清空画布";
            this.清空画布ToolStripMenuItem.Click += new System.EventHandler(this.清空画布ToolStripMenuItem_Click);
            // 
            // 绘制状态ToolStripMenuItem
            // 
            this.绘制状态ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.多个显示ToolStripMenuItem,
            this.实时显示ToolStripMenuItem,
            this.混合显示ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.绘制状态ToolStripMenuItem.Name = "绘制状态ToolStripMenuItem";
            this.绘制状态ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.绘制状态ToolStripMenuItem.Text = "绘制状态";
            // 
            // 多个显示ToolStripMenuItem
            // 
            this.多个显示ToolStripMenuItem.Name = "多个显示ToolStripMenuItem";
            this.多个显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.多个显示ToolStripMenuItem.Text = "多个显示";
            this.多个显示ToolStripMenuItem.Click += new System.EventHandler(this.多个显示ToolStripMenuItem_Click);
            // 
            // 实时显示ToolStripMenuItem
            // 
            this.实时显示ToolStripMenuItem.Name = "实时显示ToolStripMenuItem";
            this.实时显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.实时显示ToolStripMenuItem.Text = "实时显示";
            this.实时显示ToolStripMenuItem.Click += new System.EventHandler(this.实时显示ToolStripMenuItem_Click);
            // 
            // 混合显示ToolStripMenuItem
            // 
            this.混合显示ToolStripMenuItem.Enabled = false;
            this.混合显示ToolStripMenuItem.Name = "混合显示ToolStripMenuItem";
            this.混合显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.混合显示ToolStripMenuItem.Text = "混合显示";
            this.混合显示ToolStripMenuItem.Click += new System.EventHandler(this.混合显示ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Checked = true;
            this.关闭ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭ToolStripMenuItem.Text = "辅助显示";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用说明ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用说明ToolStripMenuItem
            // 
            this.使用说明ToolStripMenuItem.Name = "使用说明ToolStripMenuItem";
            this.使用说明ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.使用说明ToolStripMenuItem.Text = "使用说明";
            this.使用说明ToolStripMenuItem.Click += new System.EventHandler(this.使用说明ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // BresenhamDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 371);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BresenhamDemo";
            this.Text = "BresenhamDemo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 子菜单1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 子菜单2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDA方法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenham方法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 错误画法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制圆形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenham算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正负法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空画布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多个显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实时显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 混合显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDA方法ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bresenham算法ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 错误画法ToolStripMenuItem1;
    }
}

