using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Kammmolch.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            OnPropertyChanged(body.Member.Name);
        }

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (field == null || !field.Equals(value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected void SetProperty<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            if (field == null || !field.Equals(value))
            {
                field = value;
                var body = propertyExpression.Body as MemberExpression;
                OnPropertyChanged(body.Member.Name);
            }
        }
    }
}
