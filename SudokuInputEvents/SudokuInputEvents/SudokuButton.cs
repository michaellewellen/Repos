using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace SudokuInputEvents
{
    public class SudokuButton : INotifyPropertyChanged
    {
        public SudokuButton(int? value = null)
        {
            Value = value;
            IsEditable = true;
            ButtonColor = Brushes.Blue;
            
        }
        private bool isEditable;
        public bool IsEditable
        {
            get { return isEditable; }
            set { SetField(ref isEditable, value); }
        }

        private SolidColorBrush buttonColor;
        public SolidColorBrush ButtonColor
        {
            get { return buttonColor; }
            set { SetField(ref buttonColor, value); }
        }


        private int? buttonValue;
        public int? Value
        {
            get { return buttonValue; }
            set { SetField(ref buttonValue, value); }
        }

        private RelayCommand changeValue;

        public RelayCommand ChangeValue => changeValue ?? (changeValue = new RelayCommand(
            () =>
            // Execute Funtion
            {
                if (Value == null)
                    Value = 1;
                else if (Value == 9)
                    Value = null;
                else
                    Value++;
            },
            // can Execute function
            () => IsEditable));


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
