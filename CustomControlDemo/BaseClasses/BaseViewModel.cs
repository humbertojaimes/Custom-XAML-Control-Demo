using System;
namespace CustomControlDemo.BaseClasses
{
    public class BaseViewModel : ObservableObject
	{
		string title = string.Empty;

		public string Title
		{
			get => title;
			set => SetProperty(ref title, value);
		}

		
		bool isBusy;

		public bool IsBusy
		{
			get => isBusy;
			set
			{
				if (SetProperty(ref isBusy, value))
					IsNotBusy = !isBusy;
			}
		}

		bool isNotBusy = true;

		public bool IsNotBusy
		{
			get => isNotBusy;
			set
			{
				if (SetProperty(ref isNotBusy, value))
					IsBusy = !isNotBusy;
			}
		}

	}
}
