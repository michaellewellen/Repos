using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class AsteroidViewModel
    {
        private Astroid rock = new Astroid(100);

        public AsteroidViewModel()
        {
            
            while (true)
            {
                MainWindow.RoidSizeProperty = rock.Height;
                MainWindow.XCoordinateProperty = rock.LocationAsteroid.X;
                MainWindow.YCoordinateProperty = rock.LocationAsteroid.Y;
            }
        }

    }
}
