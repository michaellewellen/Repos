using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SudokuInputEvents
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Buttons = new SudokuButton[88];
            Buttons[0] = new SudokuButton(4);
            Buttons[1] = new SudokuButton(7);
            Buttons[1].IsEditable = false;
            Buttons[1].ButtonColor = Brushes.Red;

        }

        public SudokuButton[] Buttons { get; private set; }
        
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
