namespace IT_Companies
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textboxCity = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.pictureBoxLocation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // textboxCity
            // 
            this.textboxCity.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textboxCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxCity.CausesValidation = false;
            this.textboxCity.Font = new System.Drawing.Font("Goudy Old Style", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxCity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textboxCity.Location = new System.Drawing.Point(51, 80);
            this.textboxCity.Name = "textboxCity";
            this.textboxCity.Size = new System.Drawing.Size(306, 33);
            this.textboxCity.TabIndex = 0;
            this.textboxCity.Text = "Type city name here";
            this.textboxCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightBlue;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.SkyBlue;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(375, 80);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(108, 33);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Banner", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 53);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search For IT Companies";
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.Color.SteelBlue;
            this.textBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResult.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResult.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxResult.Location = new System.Drawing.Point(114, 199);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(625, 242);
            this.textBoxResult.TabIndex = 3;
            this.textBoxResult.Visible = false;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.BackColor = System.Drawing.Color.Transparent;
            this.labelResult.Font = new System.Drawing.Font("Sitka Banner", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelResult.Location = new System.Drawing.Point(377, 148);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(97, 39);
            this.labelResult.TabIndex = 4;
            this.labelResult.Text = "Results";
            this.labelResult.Visible = false;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.BackColor = System.Drawing.Color.Transparent;
            this.labelCount.Font = new System.Drawing.Font("Snap ITC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.ForeColor = System.Drawing.Color.Maroon;
            this.labelCount.Location = new System.Drawing.Point(325, 199);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 35);
            this.labelCount.TabIndex = 6;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.Transparent;
            this.labelError.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.PowderBlue;
            this.labelError.Location = new System.Drawing.Point(47, 116);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(84, 21);
            this.labelError.TabIndex = 7;
            this.labelError.Text = "Show Error";
            this.labelError.Visible = false;
            // 
            // pictureBoxLocation
            // 
            this.pictureBoxLocation.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLocation.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLocation.Image")));
            this.pictureBoxLocation.Location = new System.Drawing.Point(21, 148);
            this.pictureBoxLocation.Name = "pictureBoxLocation";
            this.pictureBoxLocation.Size = new System.Drawing.Size(667, 329);
            this.pictureBoxLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLocation.TabIndex = 8;
            this.pictureBoxLocation.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(846, 481);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textboxCity);
            this.Controls.Add(this.pictureBoxLocation);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "IT Companies Locator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxCity;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.PictureBox pictureBoxLocation;
    }
}

