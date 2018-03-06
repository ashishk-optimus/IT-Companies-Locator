using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace IT_Companies
{

    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        #region Variables and Objects

        private XmlDocument _xmlDoc;
        private string _baseUrl;
        private XmlNodeList _nodeListToken;
        private IList<string> _pageTokenList  = new List<string>();

        #endregion

        #region Search Button Method

        /// <summary>
        /// Code Executed When Button Search is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = ""; // Set Initially textBoxResult as Empty
            labelCount.Text = ""; // Set Initially labelCount as Empty
            
            // Get City details from the textbox named textboxCity
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


                _baseUrl = GetBaseUrl(formattedCityName);

                // calling method with city name as passed parameter 
                GetCompaniesInXml(_baseUrl);

                // Getting all the IT Companies name with tag 'name' in XML file to XmlNodeList object
                XmlNodeList nodeListName = _xmlDoc.GetElementsByTagName("name");

                // Getting all the IT Companies address with tag 'formatted_address' in XML file to XmlNodeList object
                XmlNodeList nodeListAddress = _xmlDoc.GetElementsByTagName("formatted_address");

                // Count IT Companies for provided Location
                _countCompanyName = nodeListName.Count;

                // Getting token name for returned result
                _nodeListToken = _xmlDoc.GetElementsByTagName("next_page_token");

                // Append _pageTokenList with latest token
                foreach (XmlNode xn in _nodeListToken)
                {
                    _pageTokenList.Add(_nodeListToken[0].InnerText);
                }
                    
                // nextButton method will not be called in case of no token available
                if(_pageTokenList.Count > 0)
                {
                    buttonNext.Visible = true;
                }
                

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
                    labelCount.Visible = true;
                    labelCount.Text = _countCompanyName.ToString();
                }
            }


        }

        #endregion

        #region Next Button Method

        private void buttonNext_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = ""; // Set Initially textBoxResult as Empty
            labelCount.Text = ""; // Set Initially labelCount as Empty

            // Get City details from the textbox named textboxCity
            string cityName = textboxCity.Text;


            int _countCompanyName = 0;
            string formattedCityName = string.Empty; // string to format the provided city name in reuired url
            string[] cityInfo = cityName.Split(' ');

            // format the provided city name to their respective url
            foreach (string word in cityInfo)
            {
                formattedCityName += word + "+";
            }

            int countPageToken = _pageTokenList.Count;
            _baseUrl = GetBaseUrl(formattedCityName, _pageTokenList[countPageToken - 1]);

            // calling method with city name as passed parameter 
            GetCompaniesInXml(_baseUrl);

            // Getting all the IT Companies name with tag 'name' in XML file to XmlNodeList object
            XmlNodeList nodeListName = _xmlDoc.GetElementsByTagName("name");

            // Getting all the IT Companies address with tag 'formatted_address' in XML file to XmlNodeList object
            XmlNodeList nodeListAddress = _xmlDoc.GetElementsByTagName("formatted_address");

            // Getting token name for returned result
            _nodeListToken = _xmlDoc.GetElementsByTagName("next_page_token");

            // In case of no token available, it will disable the next button
            if (_nodeListToken.Count == 0)
            {
                buttonNext.Visible = true;
            }

            // Append _pageTokenList with latest token
            foreach (XmlNode xn in _nodeListToken)
            {
                _pageTokenList.Add(_nodeListToken[0].InnerText);
            }



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
                labelCount.Visible = true;
                labelCount.Text = _countCompanyName.ToString();
            }



        }

        #endregion

        #region Methods for Getting baseUrl and response in XmlDocument

        /// <summary>
        /// Return the url for given city in string without using any token
        /// </summary>
        /// <param name="formattedCityName"></param>
        /// <returns>string</returns>
        private string GetBaseUrl(string formattedCityName)
        {
            // URL mor making request to Google Places API along with the Key
            string baseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=it+companies+in+" +
                             formattedCityName + "&types=store&hasNextPage=true&nextPage()=true&key=AIzaSyBR-JLN0PpaKA1QrT9uPgJn6BIgOZmChR8";
            return baseUrl;
        }

        /// <summary>
        /// Return the url for given city in string by using token
        /// </summary>
        /// <param name="formattedCityName"></param>
        /// <param name="nextPageToken"></param>
        /// <returns>string</returns>
        private string GetBaseUrl(string formattedCityName, string nextPageToken)
        {
            // URL mor making request to Google Places API along with the Key
            string baseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/xml?types=store&hasNextPage=true&nextPage()=true&key=AIzaSyBR-JLN0PpaKA1QrT9uPgJn6BIgOZmChR8&pagetoken=" + nextPageToken;
            return baseUrl;
        }

        /// <summary>
        /// Return the response for given city in XmlDocument object for the given baseUrl
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns>XmlDocument</returns>
        private XmlDocument GetCompaniesInXml(string baseUrl)
            { 
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

        #endregion

        
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
