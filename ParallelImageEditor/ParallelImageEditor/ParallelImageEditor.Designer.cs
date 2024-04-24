namespace ParallelImageEditor
{
    partial class ParallelImageEditor
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
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.FlipVerticalButton = new System.Windows.Forms.Button();
            this.HorizontalFlipButton = new System.Windows.Forms.Button();
            this.RotateButton = new System.Windows.Forms.Button();
            this.InvertButton = new System.Windows.Forms.Button();
            this.SepiaFilterButton = new System.Windows.Forms.Button();
            this.BlackAndWhiteFilterButton = new System.Windows.Forms.Button();
            this.GreenFilterButton = new System.Windows.Forms.Button();
            this.BlueFilterButton = new System.Windows.Forms.Button();
            this.BrightnessHighButton = new System.Windows.Forms.Button();
            this.Brightness = new System.Windows.Forms.Label();
            this.BrightnessLowButton = new System.Windows.Forms.Button();
            this.Contrast = new System.Windows.Forms.Label();
            this.ContrastHighButton = new System.Windows.Forms.Button();
            this.ContrastLowButton = new System.Windows.Forms.Button();
            this.Revert = new System.Windows.Forms.Button();
            this.Grayscale = new System.Windows.Forms.Label();
            this.GrayscaleHighButton = new System.Windows.Forms.Button();
            this.GrayscaleLowButton = new System.Windows.Forms.Button();
            this.ColorCorrectionButton = new System.Windows.Forms.Button();
            this.ResizeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(636, 379);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(122, 31);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(636, 416);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(122, 31);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PictureBox.Location = new System.Drawing.Point(12, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(590, 386);
            this.PictureBox.TabIndex = 3;
            this.PictureBox.TabStop = false;
            // 
            // FlipVerticalButton
            // 
            this.FlipVerticalButton.Location = new System.Drawing.Point(140, 416);
            this.FlipVerticalButton.Name = "FlipVerticalButton";
            this.FlipVerticalButton.Size = new System.Drawing.Size(122, 31);
            this.FlipVerticalButton.TabIndex = 4;
            this.FlipVerticalButton.Text = "Vertical Flip";
            this.FlipVerticalButton.UseVisualStyleBackColor = true;
            this.FlipVerticalButton.Click += new System.EventHandler(this.FlipVerticalButton_Click);
            // 
            // HorizontalFlipButton
            // 
            this.HorizontalFlipButton.Location = new System.Drawing.Point(12, 416);
            this.HorizontalFlipButton.Name = "HorizontalFlipButton";
            this.HorizontalFlipButton.Size = new System.Drawing.Size(122, 31);
            this.HorizontalFlipButton.TabIndex = 5;
            this.HorizontalFlipButton.Text = "Horizontal Flip";
            this.HorizontalFlipButton.UseVisualStyleBackColor = true;
            this.HorizontalFlipButton.Click += new System.EventHandler(this.HorizontalFlipButton_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(268, 416);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(122, 31);
            this.RotateButton.TabIndex = 6;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // InvertButton
            // 
            this.InvertButton.Location = new System.Drawing.Point(396, 416);
            this.InvertButton.Name = "InvertButton";
            this.InvertButton.Size = new System.Drawing.Size(122, 31);
            this.InvertButton.TabIndex = 7;
            this.InvertButton.Text = "Invert";
            this.InvertButton.UseVisualStyleBackColor = true;
            this.InvertButton.Click += new System.EventHandler(this.InvertButton_Click);
            // 
            // SepiaFilterButton
            // 
            this.SepiaFilterButton.Location = new System.Drawing.Point(636, 47);
            this.SepiaFilterButton.Name = "SepiaFilterButton";
            this.SepiaFilterButton.Size = new System.Drawing.Size(122, 28);
            this.SepiaFilterButton.TabIndex = 8;
            this.SepiaFilterButton.Text = "Sepia";
            this.SepiaFilterButton.UseVisualStyleBackColor = true;
            this.SepiaFilterButton.Click += new System.EventHandler(this.SepiaFilterButton_Click);
            // 
            // BlackAndWhiteFilterButton
            // 
            this.BlackAndWhiteFilterButton.Location = new System.Drawing.Point(636, 12);
            this.BlackAndWhiteFilterButton.Name = "BlackAndWhiteFilterButton";
            this.BlackAndWhiteFilterButton.Size = new System.Drawing.Size(122, 29);
            this.BlackAndWhiteFilterButton.TabIndex = 9;
            this.BlackAndWhiteFilterButton.Text = "Black && White";
            this.BlackAndWhiteFilterButton.UseVisualStyleBackColor = true;
            this.BlackAndWhiteFilterButton.Click += new System.EventHandler(this.BlackAndWhiteFilterButton_Click);
            // 
            // GreenFilterButton
            // 
            this.GreenFilterButton.Location = new System.Drawing.Point(636, 81);
            this.GreenFilterButton.Name = "GreenFilterButton";
            this.GreenFilterButton.Size = new System.Drawing.Size(122, 28);
            this.GreenFilterButton.TabIndex = 10;
            this.GreenFilterButton.Text = "Green";
            this.GreenFilterButton.UseVisualStyleBackColor = true;
            this.GreenFilterButton.Click += new System.EventHandler(this.GreenFilterButton_Click);
            // 
            // BlueFilterButton
            // 
            this.BlueFilterButton.Location = new System.Drawing.Point(636, 115);
            this.BlueFilterButton.Name = "BlueFilterButton";
            this.BlueFilterButton.Size = new System.Drawing.Size(122, 28);
            this.BlueFilterButton.TabIndex = 11;
            this.BlueFilterButton.Text = "Blue";
            this.BlueFilterButton.UseVisualStyleBackColor = true;
            this.BlueFilterButton.Click += new System.EventHandler(this.BlueFilterButton_Click);
            // 
            // BrightnessHighButton
            // 
            this.BrightnessHighButton.Location = new System.Drawing.Point(746, 196);
            this.BrightnessHighButton.Name = "BrightnessHighButton";
            this.BrightnessHighButton.Size = new System.Drawing.Size(22, 28);
            this.BrightnessHighButton.TabIndex = 12;
            this.BrightnessHighButton.Text = "+";
            this.BrightnessHighButton.UseVisualStyleBackColor = true;
            this.BrightnessHighButton.Click += new System.EventHandler(this.BrightnessHighButton_Click);
            // 
            // Brightness
            // 
            this.Brightness.AutoSize = true;
            this.Brightness.Location = new System.Drawing.Point(661, 202);
            this.Brightness.Name = "Brightness";
            this.Brightness.Size = new System.Drawing.Size(70, 16);
            this.Brightness.TabIndex = 13;
            this.Brightness.Text = "Brightness";
            // 
            // BrightnessLowButton
            // 
            this.BrightnessLowButton.Location = new System.Drawing.Point(624, 196);
            this.BrightnessLowButton.Name = "BrightnessLowButton";
            this.BrightnessLowButton.Size = new System.Drawing.Size(22, 28);
            this.BrightnessLowButton.TabIndex = 14;
            this.BrightnessLowButton.Text = "-";
            this.BrightnessLowButton.UseVisualStyleBackColor = true;
            this.BrightnessLowButton.Click += new System.EventHandler(this.BrightnessLowButton_Click);
            // 
            // Contrast
            // 
            this.Contrast.AutoSize = true;
            this.Contrast.Location = new System.Drawing.Point(661, 236);
            this.Contrast.Name = "Contrast";
            this.Contrast.Size = new System.Drawing.Size(56, 16);
            this.Contrast.TabIndex = 15;
            this.Contrast.Text = "Contrast";
            // 
            // ContrastHighButton
            // 
            this.ContrastHighButton.Location = new System.Drawing.Point(746, 230);
            this.ContrastHighButton.Name = "ContrastHighButton";
            this.ContrastHighButton.Size = new System.Drawing.Size(22, 28);
            this.ContrastHighButton.TabIndex = 16;
            this.ContrastHighButton.Text = "+";
            this.ContrastHighButton.UseVisualStyleBackColor = true;
            this.ContrastHighButton.Click += new System.EventHandler(this.ContrastHighButton_Click);
            // 
            // ContrastLowButton
            // 
            this.ContrastLowButton.Location = new System.Drawing.Point(624, 230);
            this.ContrastLowButton.Name = "ContrastLowButton";
            this.ContrastLowButton.Size = new System.Drawing.Size(22, 28);
            this.ContrastLowButton.TabIndex = 17;
            this.ContrastLowButton.Text = "-";
            this.ContrastLowButton.UseVisualStyleBackColor = true;
            this.ContrastLowButton.Click += new System.EventHandler(this.ContrastLowButton_Click);
            // 
            // Revert
            // 
            this.Revert.Location = new System.Drawing.Point(636, 311);
            this.Revert.Name = "Revert";
            this.Revert.Size = new System.Drawing.Size(122, 28);
            this.Revert.TabIndex = 18;
            this.Revert.Text = "Revert";
            this.Revert.UseVisualStyleBackColor = true;
            this.Revert.Click += new System.EventHandler(this.Revert_Click);
            // 
            // Grayscale
            // 
            this.Grayscale.AutoSize = true;
            this.Grayscale.Location = new System.Drawing.Point(661, 270);
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(69, 16);
            this.Grayscale.TabIndex = 19;
            this.Grayscale.Text = "Grayscale";
            // 
            // GrayscaleHighButton
            // 
            this.GrayscaleHighButton.Location = new System.Drawing.Point(746, 264);
            this.GrayscaleHighButton.Name = "GrayscaleHighButton";
            this.GrayscaleHighButton.Size = new System.Drawing.Size(22, 28);
            this.GrayscaleHighButton.TabIndex = 20;
            this.GrayscaleHighButton.Text = "+";
            this.GrayscaleHighButton.UseVisualStyleBackColor = true;
            this.GrayscaleHighButton.Click += new System.EventHandler(this.GrayscaleHighButton_Click);
            // 
            // GrayscaleLowButton
            // 
            this.GrayscaleLowButton.Location = new System.Drawing.Point(624, 264);
            this.GrayscaleLowButton.Name = "GrayscaleLowButton";
            this.GrayscaleLowButton.Size = new System.Drawing.Size(22, 28);
            this.GrayscaleLowButton.TabIndex = 21;
            this.GrayscaleLowButton.Text = "-";
            this.GrayscaleLowButton.UseVisualStyleBackColor = true;
            this.GrayscaleLowButton.Click += new System.EventHandler(this.GrayscaleLowButton_Click);
            // 
            // ColorCorrectionButton
            // 
            this.ColorCorrectionButton.Location = new System.Drawing.Point(636, 149);
            this.ColorCorrectionButton.Name = "ColorCorrectionButton";
            this.ColorCorrectionButton.Size = new System.Drawing.Size(122, 28);
            this.ColorCorrectionButton.TabIndex = 22;
            this.ColorCorrectionButton.Text = "Color Correction";
            this.ColorCorrectionButton.UseVisualStyleBackColor = true;
            this.ColorCorrectionButton.Click += new System.EventHandler(this.ColorCorrectionButton_Click);
            // 
            // ResizeButton
            // 
            this.ResizeButton.Location = new System.Drawing.Point(636, 345);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(122, 28);
            this.ResizeButton.TabIndex = 23;
            this.ResizeButton.Text = "Resize";
            this.ResizeButton.UseVisualStyleBackColor = true;
            this.ResizeButton.Click += new System.EventHandler(this.Resize_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 462);
            this.Controls.Add(this.ResizeButton);
            this.Controls.Add(this.ColorCorrectionButton);
            this.Controls.Add(this.GrayscaleLowButton);
            this.Controls.Add(this.GrayscaleHighButton);
            this.Controls.Add(this.Grayscale);
            this.Controls.Add(this.Revert);
            this.Controls.Add(this.ContrastLowButton);
            this.Controls.Add(this.ContrastHighButton);
            this.Controls.Add(this.Contrast);
            this.Controls.Add(this.BrightnessLowButton);
            this.Controls.Add(this.Brightness);
            this.Controls.Add(this.BrightnessHighButton);
            this.Controls.Add(this.BlueFilterButton);
            this.Controls.Add(this.GreenFilterButton);
            this.Controls.Add(this.BlackAndWhiteFilterButton);
            this.Controls.Add(this.SepiaFilterButton);
            this.Controls.Add(this.InvertButton);
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.HorizontalFlipButton);
            this.Controls.Add(this.FlipVerticalButton);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenButton);
            this.Name = "ImageEditor";
            this.Text = "ImageEditor";
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button FlipVerticalButton;
        private System.Windows.Forms.Button HorizontalFlipButton;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.Button InvertButton;
        private System.Windows.Forms.Button SepiaFilterButton;
        private System.Windows.Forms.Button BlackAndWhiteFilterButton;
        private System.Windows.Forms.Button GreenFilterButton;
        private System.Windows.Forms.Button BlueFilterButton;
        private System.Windows.Forms.Button BrightnessHighButton;
        private System.Windows.Forms.Label Brightness;
        private System.Windows.Forms.Button BrightnessLowButton;
        private System.Windows.Forms.Label Contrast;
        private System.Windows.Forms.Button ContrastHighButton;
        private System.Windows.Forms.Button ContrastLowButton;
        private System.Windows.Forms.Button Revert;
        private System.Windows.Forms.Label Grayscale;
        private System.Windows.Forms.Button GrayscaleHighButton;
        private System.Windows.Forms.Button GrayscaleLowButton;
        private System.Windows.Forms.Button ColorCorrectionButton;
        private System.Windows.Forms.Button ResizeButton;
    }
}