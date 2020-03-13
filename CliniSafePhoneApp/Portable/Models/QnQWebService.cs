using System.ComponentModel;

namespace CliniSafePhoneApp.Portable.Models
{
    public class QnAWebService : INotifyPropertyChanged, IQnAWebSerivce
    {
        private int question_ID;

        public int Question_ID
        {
            get { return question_ID; }
            set
            {
                question_ID = value;
                OnPropertyChanged("Question_ID");
            }
        }


        private string question;

        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }

        private bool answer;

        public bool Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
