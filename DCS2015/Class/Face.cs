using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DCS2015.Class
{
    static class Face
    {
        public static bool CheckDistance(double width, double height, double minimumWidth, double maximumWidth, ref string returnMessage)
        {
            if (width < minimumWidth || height < minimumWidth)
            {
                returnMessage = "Subject is too far";
                return false;
            }
            else if (width > maximumWidth || height > maximumWidth)
            {
                returnMessage = "Subject is too close";
                return false;
            }
           
                return true;
        }


        public static bool CheckFaceCentering(double x, double y, Image sourceImage, ref string returnMessage)
        {
            double sourceImageWidth = System.Convert.ToDouble(sourceImage.Width / 4);
            double SourceImageHeight = System.Convert.ToDouble(sourceImage.Height / 4);

            if (x < sourceImageWidth)
            {
                returnMessage = "Move to Left";
                return false;
            }
            else if (x > ((sourceImageWidth * 2) + (sourceImageWidth / 3)))
            {
                returnMessage = "Move to Right";
                return false;
            }

            if (y < SourceImageHeight)
            {
                returnMessage = "face is too high";
                return false;
            }
            else if (y > (SourceImageHeight + (SourceImageHeight / 2) + (SourceImageHeight / 3)))
            {
                returnMessage = "Face is too low";
                return false;
            }

            return true;
        }
    }
}
