using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Class1 : INotifyPropertyChanged
{
	public Class1()
	{
	}
	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	public event PropertyChangedEventHandler PropertyChanged;
	RaisePropertyChanged(nameof(MyProperty));
    protected bool Set<T>(
    ref T field,
    T newValue,
    [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
        {
            return false;
        }

        field = newValue;
        RaisePropertyChanged(propertyName);
        return true;
    }
}
