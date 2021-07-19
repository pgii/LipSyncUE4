using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Extension
{
    internal static class GraphicsExtension
    {
		private static GraphicsPath GenerateRoundedRectangle(RectangleF rectangle, float radius, RectangleEdgeFilterEnum.RectangleEdgeFilter filter)
		{
            GraphicsPath path = new GraphicsPath();

			if (radius <= 0.0F || filter == RectangleEdgeFilterEnum.RectangleEdgeFilter.None)
			{
				path.AddRectangle(rectangle);
				path.CloseFigure();
				return path;
			}

            if (radius >= Math.Min(rectangle.Width, rectangle.Height) / 2.0)
                return GenerateCapsule(rectangle);

            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rectangle.Location, sizeF);

            if ((RectangleEdgeFilterEnum.RectangleEdgeFilter.TopLeft & filter) == RectangleEdgeFilterEnum.RectangleEdgeFilter.TopLeft)
            {
                path.AddArc(arc, 180, 90);
            }
			else
            {
                path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
                path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
            }

            arc.X = rectangle.Right - diameter;

            if ((RectangleEdgeFilterEnum.RectangleEdgeFilter.TopRight & filter) == RectangleEdgeFilterEnum.RectangleEdgeFilter.TopRight)
            {
                path.AddArc(arc, 270, 90);
            }
			else
            {
                path.AddLine(arc.X, arc.Y, arc.X + arc.Width, arc.Y);
                path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X + arc.Width, arc.Y);
            }

            arc.Y = rectangle.Bottom - diameter;

            if ((RectangleEdgeFilterEnum.RectangleEdgeFilter.BottomRight & filter) == RectangleEdgeFilterEnum.RectangleEdgeFilter.BottomRight)
            {
                path.AddArc(arc, 0, 90);
            }
			else
            {
                path.AddLine(arc.X + arc.Width, arc.Y, arc.X + arc.Width, arc.Y + arc.Height);
                path.AddLine(arc.X, arc.Y + arc.Height, arc.X + arc.Width, arc.Y + arc.Height);
            }

            arc.X = rectangle.Left;

            if ((RectangleEdgeFilterEnum.RectangleEdgeFilter.BottomLeft & filter) == RectangleEdgeFilterEnum.RectangleEdgeFilter.BottomLeft)
            {
                path.AddArc(arc, 90, 90);
            }
			else
            {
                path.AddLine(arc.X + arc.Width, arc.Y + arc.Height, arc.X, arc.Y + arc.Height);
                path.AddLine(arc.X, arc.Y + arc.Height, arc.X, arc.Y);
            }

            path.CloseFigure();

            return path;
		}
		private static GraphicsPath GenerateCapsule(RectangleF rectangle)
		{
            GraphicsPath path = new GraphicsPath();
			try
            {
                float diameter;
                RectangleF arc;
                if (rectangle.Width > rectangle.Height)
				{
					diameter = rectangle.Height;
					SizeF sizeF = new SizeF(diameter, diameter);
					arc = new RectangleF(rectangle.Location, sizeF);
					path.AddArc(arc, 90, 180);
					arc.X = rectangle.Right - diameter;
					path.AddArc(arc, 270, 180);
				}
				else if (rectangle.Width < rectangle.Height)
				{
					diameter = rectangle.Width;
					SizeF sizeF = new SizeF(diameter, diameter);
					arc = new RectangleF(rectangle.Location, sizeF);
					path.AddArc(arc, 180, 180);
					arc.Y = rectangle.Bottom - diameter;
					path.AddArc(arc, 0, 180);
				}
                else
                {
                    path.AddEllipse(rectangle);
                }
			}
			catch { path.AddEllipse(rectangle); }
			finally { path.CloseFigure(); }
			return path;
		}
		public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, float x, float y, float width, float height, float radius, RectangleEdgeFilterEnum.RectangleEdgeFilter filter)
		{
			RectangleF rectangle = new RectangleF(x, y, width, height);
			GraphicsPath path = GenerateRoundedRectangle(rectangle, radius, filter);
            graphics.DrawPath(pen, path);
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, RectangleF rectangle, int radius, RectangleEdgeFilterEnum.RectangleEdgeFilter filter)
		{
			graphics.DrawRoundedRectangle(pen, rectangle.X,	rectangle.Y, rectangle.Width, rectangle.Height, radius, filter);
		}

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, float x, float y, float width, float height, float radius, RectangleEdgeFilterEnum.RectangleEdgeFilter filter)
		{
			RectangleF rectangle = new RectangleF(x, y, width, height);
			GraphicsPath path = GenerateRoundedRectangle(rectangle, radius, filter);
            graphics.FillPath(brush, path);
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, RectangleF rectangle, int radius, RectangleEdgeFilterEnum.RectangleEdgeFilter filter)
		{
			graphics.FillRoundedRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, radius, filter);
		}
    }

}
