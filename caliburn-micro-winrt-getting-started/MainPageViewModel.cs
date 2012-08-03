using Caliburn.Micro;

namespace caliburn_micro_winrt_getting_started
{
    public class MainPageViewModel : Screen
    {
        private string helloText;
        public string HelloText
        {
            get { return helloText; }
            set { helloText = value; NotifyOfPropertyChange(() => HelloText); }
        }

        public void SayHello()
        {
            this.HelloText = "Hi from the Caliburn.Micro for WinRT!";
        }
    }
}
