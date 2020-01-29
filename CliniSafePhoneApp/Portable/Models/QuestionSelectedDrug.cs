using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Models
{
    public class QuestionSelectedDrug : INotifyPropertyChanged, IQuestionSelectedDrug
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


        private bool yes;

        public bool Yes
        {
            get { return yes; }
            set
            {
                yes = value;
                OnPropertyChanged("Yes");
            }
        }


        private bool no;

        public bool No
        {
            get { return no; }
            set
            {
                no = value;
                OnPropertyChanged("No");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns Questions for User based on Trial from the Web Service Proxy Class.
        /// </summary>
        /// <param name="trialID"></param>
        /// <returns></returns>
        public static async Task<List<QuestionSelectedDrug>> GetQuestionSelectedDrugsListAysnc(int trialID)
        {
            List<QuestionSelectedDrug> result = await App.PhoneAppSoapService.GetQuestionSelectedDrugsListAsync(trialID);
            return result;
        }
    }
}
