using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CliniSafePhoneApp.Portable.Models
{
    [XmlRoot("NewDataSet")]
    public class GenericDrugsFound : INotifyPropertyChanged, IGenericDrugsFound
    {

        private int drug_Id;

        public int Drug_ID
        {
            get { return drug_Id; }
            set
            {
                drug_Id = value;
                OnPropertyChanged("Drug_ID");
            }
        }

        private string drugName;

        public string DrugName
        {
            get { return drugName; }
            set
            {
                drugName = value;
                OnPropertyChanged("DrugName");
            }
        }


        private bool select;

        public bool Select
        {
            get { return select; }
            set
            {
                select = value;
                OnPropertyChanged("Select");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns Generic Drugs for User based on Trial and Searched Drug from the Web Service Proxy Class.
        /// </summary>
        /// <param name="trialID"></param>
        /// <param name="genericDrugNameToFind"></param>
        /// <returns></returns>
        public static async Task<List<GenericDrugsFound>> FindGenericDrugNameListAsync(int trialID, string genericDrugNameToFind)
        {
            List<GenericDrugsFound> result = await App.PhoneAppSoapService.FindGenericDrugNameListAsync(trialID, genericDrugNameToFind);
            return result;
        }

    }
}
