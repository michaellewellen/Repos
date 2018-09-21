using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asteroids
{
    public class Astroid : INotifyPropertyChanged
    {
        private Point locationAsteroid;
        private Point delta;
        private double height;
          
        public Astroid(double _height)
        {
            height = _height;
            Random rand= new Random();
            double ranx = rand.NextDouble() * 800;
            double rany = rand.NextDouble() * 800;

            locationAsteroid = new Point(ranx, rany);

            double deltax = 2 * rand.NextDouble() - 1;
            double deltay = 2 * rand.NextDouble() - 1;
            delta = new Point(deltax, deltay);
        }
        
        public Point Delta
        {
            get { return delta; }
            set { SetField(ref delta, value); }
        }
       
        public Point LocationAsteroid{
    get { return locationAsteroid; }
            set { SetField(ref locationAsteroid, value); }
}

public double Height{
    get { return height; }
            set { SetField(ref height, value); }
}

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
