using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace SimplePhotoGallery.GalleryModule.Util
{
    public class ImageUtility : IImageUtility
    {
        public string CreateVenueImageStorage(int venueId)
        {
            if (venueId < 1)
                throw new ArgumentException("Property id can not be less than 1");

            string serverPath = string.Empty;  //System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[""] AppSetting.PropertyImageStoragePath);
            string fullPath = string.Format("{0}/{1}", serverPath, venueId);

            DirectoryInfo directoryInfo;

            if (!Directory.Exists(fullPath))
            {
                directoryInfo = Directory.CreateDirectory(fullPath);
                return directoryInfo.FullName;
            }
            return fullPath;
        }

        public bool SavePostedFile(HttpPostedFileBase httpPostedFileBase, string path, string fileName, bool multiSize)
        {
            if (httpPostedFileBase != null && httpPostedFileBase.ContentLength != 0)
            {
                string extension = Regex.Match(httpPostedFileBase.FileName, @".+\.([^.]+)$").Groups[1].Value;

                if (string.IsNullOrEmpty(extension))
                    throw new Exception("Invalid extension of image");

                string serverPath = HttpContext.Current.Server.MapPath(string.Format(@"{0}\{1}.{2}", path, fileName, extension));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                }
                httpPostedFileBase.SaveAs(serverPath);

                #region Resize and save

                if (multiSize)
                {
                    Image picture = Image.FromFile(serverPath);
                    HardResizeImage(48, 48, picture).Save(HttpContext.Current.Server.MapPath(string.Format(@"{0}\{1}{2}.{3}", path, fileName, "-48X48", extension)));
                    HardResizeImage(128, 128, picture).Save(HttpContext.Current.Server.MapPath(string.Format(@"{0}\{1}{2}.{3}", path, fileName, "-128X128", extension)));
                    HardResizeImage(420, 500, picture).Save(HttpContext.Current.Server.MapPath(string.Format(@"{0}\{1}{2}.{3}", path, fileName, "-420", extension)));
                }

                #endregion

                return true;
            }
            else
                return false;
        }

        public Image HardResizeImage(int Width, int Height, Image Image)
        {
            Image resized = null;
            if (Width > Height)
            {
                resized = ResizeImage(Width, Width, Image);
            }
            else
            {
                resized = ResizeImage(Height, Height, Image);
            }
            Image output = CropImage(resized, Height, Width);
            return output;
        }

        public Image ResizeImage(int maxWidth, int maxHeight, Image Image)
        {
            int width = Image.Width;
            int height = Image.Height;
            if (width > maxWidth || height > maxHeight)
            {
                Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                Image.RotateFlip(RotateFlipType.Rotate180FlipX);

                float ratio = 0;
                if (width > height)
                {
                    ratio = (float)width / (float)height;
                    width = maxWidth;
                    height = Convert.ToInt32(Math.Round((float)width / ratio));
                }
                else
                {
                    ratio = (float)width / (float)height;
                    width = maxWidth;
                    height = Convert.ToInt32(Math.Round((float)width / ratio));
                }
                return Image.GetThumbnailImage(width, height, null, IntPtr.Zero);
            }
            return Image;
        }


        public Image CropImage(Image Image, int Height, int Width)
        {
            return CropImage(Image, Height, Width, 0, 0);
        }

        public Image CropImage(Image Image, int Height, int Width, int StartAtX, int StartAtY)
        {
            Image outimage;
            MemoryStream mm = null;
            try
            {
                //check the image height against our desired image height
                if (Image.Height < Height)
                {
                    Height = Image.Height;
                }

                if (Image.Width < Width)
                {
                    Width = Image.Width;
                }

                //create a bitmap window for cropping
                Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(72, 72);
                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

                //do the crop
                grPhoto.DrawImage(Image, new Rectangle(0, 0, Width, Height), StartAtX, StartAtY, Width, Height, GraphicsUnit.Pixel);

                // Save out to memory and get an image from it to send back out the method.
                mm = new MemoryStream();
                bmPhoto.Save(mm, ImageFormat.Jpeg);
                Image.Dispose();
                bmPhoto.Dispose();
                grPhoto.Dispose();
                outimage = Image.FromStream(mm);

                return outimage;
            }
            catch (Exception ex)
            {
                throw new Exception("Error cropping image, the error was: " + ex.Message);
            }
        }

    }
}
