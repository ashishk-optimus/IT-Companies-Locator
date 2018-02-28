using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IT_Companies
{

    public partial class Form1 : Form
    {
        // hold response from google places api in Xml format
        XmlDocument xmlDoc;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Code Executed When Button Search is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
        
            int _countName = 0; // variable to count number of IT Companies returned by API 
            textBoxResult.Text = ""; // Set Initially textBoxResult as Empty
            labelCount.Text = ""; // Set Initially labelCount as Empty

            // Get City details from the textbox named t1
            string _cityName = t1.Text;
            string _countryName = tc.Text;
            int _result; // variable to hold int value returned by TryParse

            // Display Error in case of not provided city name or numbers provided
            if (_cityName.Length == 0 || int.TryParse(_cityName, out _result))
            {
                textBoxResult.Text = Errors.invalidCityInputError;
            }

            // Fetch the Companies Details and display it
            else
            {
                string formattedCityName = string.Empty; // string to format the provided city name in reuired url
                string[] cityInfo = _cityName.Split(' '); 

                // format the provided city name to their respective url
                foreach (string word in cityInfo)
                {
                    formattedCityName += word + "+";
                }

                formattedCityName += _countryName;

                // calling method with city name as passed parameter 
                GetCompaniesInXml(formattedCityName);

                // Getting all the IT Companies name with tag 'name' in XML file to XmlNodeList object
                XmlNodeList nodeListName = xmlDoc.GetElementsByTagName("name");

                // Getting all the IT Companies address with tag 'formatted_address' in XML file to XmlNodeList object
                XmlNodeList nodeListAddress = xmlDoc.GetElementsByTagName("formatted_address");

                // Count IT Companies for provided Location
                _countName = nodeListName.Count;

                // Create object for all the available IT Company
                CompanyDetails[] _company = new CompanyDetails[_countName];

                // Set name and address for each company in CompanyDetails object
                for(int i = 0; i<_countName; i++)
                {
                    _company[i] = new CompanyDetails();
                    _company[i].setName(nodeListName[i].InnerText);
                    _company[i].setAddress(nodeListAddress[i].InnerText);
                }

                // Dispaly Error in case of no returned Company Name
                if (_countName == 0)
                {
                    textBoxResult.Text = Errors.invalidCityNameError;
                }

                // Append Each Object to textBoxResult 
                else
                {
                    for(int i = 0; i< _countName; i++)
                    {

                        // Appending textBoxResult with CompanyDetails Object by calling toString() method for each object
                        textBoxResult.Text += _company[i] + "\r\n-------------------------------------------------------------\r\n";
                    }

                    // Display the number of IT Companies on label named labelCount
                    labelCount.Text = _countName.ToString();
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
            string baseURL = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=it+companies+in+" + formattedCityName + "&key=AIzaSyBhN8m0tLYRr3QIiJ8a-dBefGTZNhrncnQ";

            // Making HTTP Request using baseURL 
            HttpWebRequest req = WebRequest.Create(baseURL) as HttpWebRequest;

            // Object of XmlDocument to hold the Http Response in XML format
            xmlDoc = new XmlDocument();
            using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
            {
                xmlDoc.Load(resp.GetResponseStream()); // Loading response to XmlDocument object
            }

            return xmlDoc;
        }

        /// <summary>
        /// Code Executed When Button Exit is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }

    static class Errors
    {
        public const string invalidCityInputError = "Type a Valid City Name..!!";
        public const string invalidCityNameError = "Invalid City or no IT Companies exist for such city.";
    }
}
