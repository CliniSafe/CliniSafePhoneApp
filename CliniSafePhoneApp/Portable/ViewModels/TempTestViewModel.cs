using CliniSafePhoneApp.Portable.ViewModels.Commands;
using System.ComponentModel;

namespace CliniSafePhoneApp.Portable.ViewModels
{
    public class TempTestViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Declares private members.
        /// </summary>
        public HelloCommand HelloCommand { get; set; }
        public EchoCommand EchoCommand { get; set; }
        public HelloErrorCommand HelloErrorCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Initialise Command properties in constructor.
        /// </summary>
        public TempTestViewModel()
        {
            HelloCommand = new HelloCommand(this);
            EchoCommand = new EchoCommand(this);
            HelloErrorCommand = new HelloErrorCommand(this);
        }


        private string tempTest;

        public string TempTest
        {
            get { return tempTest; }
            set
            {
                tempTest = value;
                OnPropertyChanged("TempTest");
            }
        }


        private string echoInput;

        public string EchoInput
        {
            get { return echoInput; }
            set
            {
                echoInput = value;
                OnPropertyChanged("EchoInput");
            }
        }


        /// <summary>
        /// Returns Hello World string from Web Service
        /// </summary>

        public async void HelloAsync()
        {
            TempTest = await App.PhoneAppSoapService.HelloWorldAsync();
        }

        /// <summary>
        /// Returns Hello Error value.
        /// </summary>
        /// <returns></returns>
        public async void HelloErrorAsync()
        {
            try
            {
                await App.PhoneAppSoapService.HelloErrorAsync();
            }
            catch (System.Exception ex)
            {

                TempTest = ex.Message;
            }
        }

        /// <summary>
        /// Returns the input text from the entry box.
        /// </summary>
        public async void EchoAsync()
        {
            TempTest = await App.PhoneAppSoapService.EchoAsync(EchoInput);
        }
    }
}
