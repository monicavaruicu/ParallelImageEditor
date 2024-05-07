using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelImageEditor
{
    public partial class ParallelImageEditor : Form
    {
        private readonly object imageLock = new object();
        private Stack<Bitmap> previousStates;
        private int revertCounter;


        public ParallelImageEditor()
        {
            InitializeComponent();
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            previousStates = new Stack<Bitmap>();
            revertCounter = 0;
        }

        private void AddState(Bitmap state)
        {
            previousStates.Push(state);
            revertCounter++;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Imagini|*.jpg;*.jpeg;*.png;*.bmp|Toate fișierele|*.*" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = Image.FromFile(openFileDialog.FileName);
                PictureBox.Image = ScaleImage(PictureBox.Image, PictureBox.Size);
                AddState(new Bitmap(PictureBox.Image));
            }
        }

        private Image ScaleImage(Image image, Size pictureBoxSize)
        {
            int width = image.Width;
            int height = image.Height;
            int newWidth, newHeight;

            if ((float)width / pictureBoxSize.Width > (float)height / pictureBoxSize.Height)
            {
                newWidth = pictureBoxSize.Width;
                newHeight = (int)((float)height / width * newWidth);
            }
            else
            {
                newHeight = pictureBoxSize.Height;
                newWidth = (int)((float)width / height * newHeight);
            }

            Bitmap scaledImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(scaledImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return scaledImage;
        }

        private void FlipVerticalButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                PictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                PictureBox.Refresh();
            }
        }

        private void HorizontalFlipButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                PictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                PictureBox.Refresh();
            }
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap bmp = new Bitmap(PictureBox.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                PictureBox.Image = bmp;
            }
        }

        private void InvertButton_Click(object sender, EventArgs e)
        {
            InvertImage(PictureBox.Image);
        }

        private void InvertImage(Image image)
        {
            if (image != null)
            {
                Bitmap bmp = new Bitmap(image);

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixelColor = bmp.GetPixel(x, y);
                        Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        bmp.SetPixel(x, y, invertedColor);
                    }
                }

                PictureBox.Image = bmp;
            }
        }

        private async Task<Bitmap> ApplyBlackAndWhiteFilterAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int avgColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        Color newColor = Color.FromArgb(avgColor, avgColor, avgColor);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private async void BlackAndWhiteFilterButton_Click(object sender, EventArgs e)
        {
            if (PictureBox != null)
            {
                Bitmap filteredImage = await ApplyBlackAndWhiteFilterAsync(PictureBox.Image);
                PictureBox.Image = filteredImage;
            }
        }

        private async void SepiaFilterButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap filteredImage = await ApplySepiaFilterAsync(PictureBox.Image);
                PictureBox.Image = filteredImage;
            }
        }

        private async Task<Bitmap> ApplySepiaFilterAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        Color newColor = CalculateSepia(pixelColor);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private Color CalculateSepia(Color color)
        {
            int r = (int)(color.R * 0.393 + color.G * 0.769 + color.B * 0.189);
            int g = (int)(color.R * 0.349 + color.G * 0.686 + color.B * 0.168);
            int b = (int)(color.R * 0.272 + color.G * 0.534 + color.B * 0.131);

            r = Math.Min(255, r);
            g = Math.Min(255, g);
            b = Math.Min(255, b);

            return Color.FromArgb(r, g, b);
        }

        private async void GreenFilterButton_Click(object sender, EventArgs e)
        {
            Bitmap filteredImage = await ApplyGreenFilterAsync(PictureBox.Image);
            PictureBox.Image = filteredImage;
        }

        private async Task<Bitmap> ApplyGreenFilterAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int r = pixelColor.R;
                        int g = Math.Min(255, (int)(pixelColor.G * 1.5));
                        int b = pixelColor.B;
                        Color newColor = Color.FromArgb(r, g, b);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private async void BlueFilterButton_Click(object sender, EventArgs e)
        {
            Bitmap filteredImage = await ApplyBlueFilterAsync(PictureBox.Image);
            PictureBox.Image = filteredImage;
        }

        private async Task<Bitmap> ApplyBlueFilterAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int r = pixelColor.R / 2;
                        int g = pixelColor.G / 2;
                        int b = pixelColor.B;
                        Color newColor = Color.FromArgb(r, g, b);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private async void BrightnessHighButton_Click(object sender, EventArgs e)
        {
            Bitmap filteredImage = await ApplyBrightnessHighAsync(PictureBox.Image);
            PictureBox.Image = filteredImage;
        }

        private async Task<Bitmap> ApplyBrightnessHighAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                int brightness = 5;

                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int r = Math.Max(0, Math.Min(255, pixelColor.R + brightness));
                        int g = Math.Max(0, Math.Min(255, pixelColor.G + brightness));
                        int b = Math.Max(0, Math.Min(255, pixelColor.B + brightness));
                        Color newColor = Color.FromArgb(r, g, b);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private async void BrightnessLowButton_Click(object sender, EventArgs e)
        {
            Bitmap filteredImage = await ApplyBrightnessLowAsync(PictureBox.Image);
            PictureBox.Image = filteredImage;
        }

        private async Task<Bitmap> ApplyBrightnessLowAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                int brightness = 5;

                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int r = Math.Max(0, Math.Min(255, pixelColor.R - brightness));
                        int g = Math.Max(0, Math.Min(255, pixelColor.G - brightness));
                        int b = Math.Max(0, Math.Min(255, pixelColor.B - brightness));
                        Color newColor = Color.FromArgb(r, g, b);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private async void ContrastHighButton_Click(object sender, EventArgs e)
        {
            Bitmap filteredImage = await ApplyContrastHighAsync(PictureBox.Image);
            PictureBox.Image = filteredImage;
        }

        private async Task<Bitmap> ApplyContrastHighAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                double averageIntensity = CalculateAverageIntensity(filteredImage);
                double factor = 1.1;

                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int r = CalculateNewIntensity(pixelColor.R, averageIntensity, factor);
                        int g = CalculateNewIntensity(pixelColor.G, averageIntensity, factor);
                        int b = CalculateNewIntensity(pixelColor.B, averageIntensity, factor);
                        Color newColor = Color.FromArgb(r, g, b);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        static double CalculateAverageIntensity(Bitmap image)
        {
            double totalIntensity = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    totalIntensity += (pixelColor.R + pixelColor.G + pixelColor.B) / 3.0;
                }
            }

            return totalIntensity / (image.Width * image.Height);
        }

        static int CalculateNewIntensity(int originalIntensity, double averageIntensity, double factor)
        {
            int newIntensity = (int)((originalIntensity - averageIntensity) * factor + averageIntensity);
            return Math.Min(255, Math.Max(0, newIntensity));
        }

        private async void ContrastLowButton_Click(object sender, EventArgs e)
        {
            Bitmap filteredImage = await ApplyContrastLowAsync(PictureBox.Image);
            PictureBox.Image = filteredImage;
        }

        private async Task<Bitmap> ApplyContrastLowAsync(Image image)
        {
            return await Task.Run(() =>
            {
                Bitmap filteredImage = new Bitmap(image.Width, image.Height);
                double averageIntensity = CalculateAverageIntensity(filteredImage);
                double factor = 0.9;

                lock (imageLock)
                {
                    using (Graphics g = Graphics.FromImage(filteredImage))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                Parallel.For(0, image.Width, x =>
                {
                    Parallel.For(0, image.Height, y =>
                    {
                        Color pixelColor;
                        lock (imageLock)
                        {
                            pixelColor = filteredImage.GetPixel(x, y);
                        }

                        int r = CalculateNewIntensity(pixelColor.R, averageIntensity, factor);
                        int g = CalculateNewIntensity(pixelColor.G, averageIntensity, factor);
                        int b = CalculateNewIntensity(pixelColor.B, averageIntensity, factor);
                        Color newColor = Color.FromArgb(r, g, b);

                        lock (imageLock)
                        {
                            filteredImage.SetPixel(x, y, newColor);
                        }
                    });
                });

                return filteredImage;
            });
        }

        private void Revert_Click(object sender, EventArgs e)
        {
            if (previousStates.Count >= revertCounter)
            {
                Bitmap desiredState = null;
                for (int i = 0; i < revertCounter; i++)
                {
                    desiredState = previousStates.Pop();
                }

                PictureBox.Image = desiredState;
                AddState(desiredState);
                revertCounter = previousStates.Count;

                if (revertCounter < 3)
                {
                    ContrastLowButton.Enabled = true;
                }
            }
        }

        private void GrayscaleHighButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap grayImage = ApplyHighGrayscaleFilter(PictureBox.Image);
                PictureBox.Image = grayImage;
            }
        }

        private Bitmap ApplyHighGrayscaleFilter(Image image)
        {
            Bitmap grayImage = new Bitmap(image);
            double factor = 1.1;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = grayImage.GetPixel(x, y);
                    int avgColor = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                    avgColor = Math.Min(255, (int)(avgColor * factor));
                    Color newColor = Color.FromArgb(avgColor, avgColor, avgColor);
                    grayImage.SetPixel(x, y, newColor);
                }
            }

            return grayImage;
        }

        private void GrayscaleLowButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap grayImage = ApplyLowGrayscaleFilter(PictureBox.Image);
                PictureBox.Image = grayImage;
                AddState(new Bitmap(PictureBox.Image));
            }
        }

        private Bitmap ApplyLowGrayscaleFilter(Image image)
        {
            Bitmap grayImage = new Bitmap(image);
            double factor = 0.9;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = grayImage.GetPixel(x, y);
                    int avgColor = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                    avgColor = (int)(avgColor * factor);
                    avgColor = Math.Min(255, avgColor);
                    Color newColor = Color.FromArgb(avgColor, avgColor, avgColor);
                    grayImage.SetPixel(x, y, newColor);
                }
            }

            return grayImage;
        }

        private void ColorCorrectionButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap correctedImage = ApplyColorCorrection(PictureBox.Image);
                PictureBox.Image = correctedImage;
                AddState(new Bitmap(PictureBox.Image));
            }
        }

        private Bitmap ApplyColorCorrection(Image image)
        {
            Bitmap correctedImage = new Bitmap(image);

            int redAdjustment = 20;
            int greenAdjustment = 10;
            int blueAdjustment = 5;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = correctedImage.GetPixel(x, y);

                    int correctedR = Clamp(pixelColor.R + redAdjustment, 0, 255);
                    int correctedG = Clamp(pixelColor.G + greenAdjustment, 0, 255);
                    int correctedB = Clamp(pixelColor.B + blueAdjustment, 0, 255);

                    Color newColor = Color.FromArgb(correctedR, correctedG, correctedB);

                    correctedImage.SetPixel(x, y, newColor);
                }
            }

            return correctedImage;
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }

        private void Resize_Click(object sender, EventArgs e)
        {
            int newWidth = 200;
            int newHeight = 200;

            if (PictureBox.Image != null)
            {
                Bitmap resizedImage = new Bitmap(PictureBox.Image, newWidth, newHeight);
                PictureBox.Image = resizedImage;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                SaveImage();
            }
        }

        private void SaveImage()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                            PictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            MessageBox.Show("Image successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case ".bmp":
                            PictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            MessageBox.Show("Image successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case ".png":
                            PictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            MessageBox.Show("Image successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            MessageBox.Show("Unsupported format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }

    }
}
