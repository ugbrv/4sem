using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters.Transformations
{
    public class RightSkewTransformer : ITransformer<RightSkewParameters>
    {
        double alpha;
        Size oldSize;

        public Size ResultSize { get; private set; }

        public void Initialize(Size oldSize, RightSkewParameters parameters)
        {
            this.oldSize = oldSize;
            alpha = parameters.AngleInDegrees * Math.PI / 180;

            ResultSize = new Size(
                (int)(oldSize.Width + 2*oldSize.Height * Math.Tan(alpha)),
                oldSize.Height
            );
        }

        public Point? MapPoint(Point newPoint)
        {
            var p = new Point(newPoint.X - oldSize.Width / 2, newPoint.Y - oldSize.Height / 2);

            int x = (int)(p.X + 2 * p.Y * Math.Tan(alpha));
            int y = p.Y;

            x += (int)(oldSize.Width / 2- oldSize.Height * Math.Tan(alpha));
            y += oldSize.Height / 2;

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}
