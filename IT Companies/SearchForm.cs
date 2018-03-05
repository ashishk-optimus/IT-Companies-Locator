using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace IT_Companies
{

    public partial class SearchForm : Form
    {
        // hold response from google places api in Xml format
        private XmlDocument _xmlDoc;

        public SearchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Code Executed When Button Search is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {

            textBoxResult.Text = ""; // Set Initially textBoxResult as Empty
            labelCount.Text = ""; // Set Initially labelCount as Empty

            // Get City details from the textbox named t1
            string cityName = textboxCity.Text;

            // Regular Expression for special character
            Regex specialCharacterRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");
            int _result; // variable to hold int value returned by TryParse
            
            // Display Error in case of not provided city name or numbers provided
            if (cityName.Length == 0 || int.TryParse(cityName, out _result))
            {
                labelError.Visible = true;
                labelError.Text = Errors.InvalidCityInputError;
                pictureBoxLocation.Visible = true;
                labelResult.Visible = false;
                textBoxResult.Visible = false;
            }

            // To check occurence of any special character by matching it with Regular
            // Expression defined by specialCharacterRegex
            else if (specialCharacterRegex.IsMatch(cityName))
            {
                labelError.Visible = true;
                labelError.Text = Errors.SpecialCharacterError;
                pictureBoxLocation.Visible = true;
                labelResult.Visible = false;
                textBoxResult.Visible = false;
            }
            // Fetch the Companies Details and display it
            else
            {
                int _countCompanyName = 0;
                string formattedCityName = string.Empty; // string to format the provided city name in reuired url
                string[] cityInfo = cityName.Split(' ');

                // format the provided city name to their respective url
                foreach (string word in cityInfo)
                {
                    formattedCityName += word + "+";
                }

                // calling method with city name as passed parameter 
                GetCompaniesInXml(formattedCityName);

                // Getting all the IT Companies name with tag 'name' in XML file to XmlNodeList object
                XmlNodeList nodeListName = _xmlDoc.GetElementsByTagName("name");

                // Getting all the IT Companies address with tag 'formatted_address' in XML file to XmlNodeList object
                XmlNodeList nodeListAddress = _xmlDoc.GetElementsByTagName("formatted_address");

                // Count IT Companies for provided Location
                _countCompanyName = nodeListName.Count;

                // Create object for all the available IT Company
                CompanyDetails[] company = new CompanyDetails[_countCompanyName];

                // Set name and address for each company in CompanyDetails object
                for (int i = 0; i < _countCompanyName; i++)
                {
                    company[i] = new CompanyDetails();
                    company[i].set_Name(nodeListName[i].InnerText);
                    company[i].set_Address(nodeListAddress[i].InnerText);
                }

                // Dispaly Error in case of no returned Company Name
                if (_countCompanyName == 0)
                {
                    labelError.Visible = true;
                    labelError.Text = Errors.InvalidCityNameError;
                    pictureBoxLocation.Visible = true;
                    labelResult.Visible = false;
                    textBoxResult.Visible = false;
                }

                // Append Each Object to textBoxResult 
                else
                {
                    for (int i = 0; i < _countCompanyName; i++)
                    {
                        labelError.Visible = false;
                        pictureBoxLocation.Visible = false;
                        labelResult.Visible = true;
                        textBoxResult.Visible = true;
                        // Appending textBoxResult with CompanyDetails Object by calling toString() method for each object
                        textBoxResult.Text += company[i] + "\r\n-------------------------------------------------------------\r\n";
                    }

                    // Display the number of IT Companies on label named labelCount
                    labelCount.Visible = false;
                    labelCount.Text = _countCompanyName.ToString();
                }
            }


        }

        /// <summary>
        /// Return the response for given city in XmlDocument object
        /// </summary>
        /// <param name="formattedCityName"></param>
        /// <returns>XmlDocument</returns>
        public XmlDocument GetCompaniesInXml(string formattedCityName)
        {
            // URL mor making request to Google Places API along with the Key
            string baseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=it+companies+in+" + formattedCityName + "&key=AIzaSyBhN8m0tLYRr3QIiJ8a-dBefGTZNhrncnQ";

            // Making HTTP Request using baseURL 
            HttpWebRequest req = WebRequest.Create(baseUrl) as HttpWebRequest;

            // Object of XmlDocument to hold the Http Response in XML format
            _xmlDoc = new XmlDocument();
            if (req != null)
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    if (resp != null)
                    {
                        _xmlDoc.Load(resp.GetResponseStream() ?? throw new InvalidOperationException()); // Loading response to XmlDocument object
                    }
                }

            return _xmlDoc;
        }
    }
    #region Error Message
    static class Errors
    {
        public const string SpecialCharacterError = "Special characters are not allowed !!!";
        public const string InvalidCityInputError = "Type a Valid City Name..!!";
        public const string InvalidCityNameError = "Invalid City name or No IT Companies exist for such city.";
    }
    #endregion
}
