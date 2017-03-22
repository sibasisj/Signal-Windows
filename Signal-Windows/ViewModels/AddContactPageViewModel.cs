﻿using GalaSoft.MvvmLight;
using Signal_Windows.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using System.Xml.Linq;
using Signal_Windows.Storage;

namespace Signal_Windows.ViewModels
{
    public class AddContactPageViewModel : ViewModelBase
    {
        private string _ContactName = "";
        public string ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; RaisePropertyChanged("ContactName"); }
        }

        private string _ContactNumber = "";
        public string ContactNumber
        {
            get { return _ContactNumber; }
            set { _ContactNumber = value; RaisePropertyChanged("ContactNumber"); }
        }

        private bool _UIEnabled = true;
        public bool UIEnabled
        {
            get { return _UIEnabled; }
            set { _UIEnabled = value; RaisePropertyChanged("UIEnabled"); }
        }

        public static Windows.Data.Xml.Dom.XmlDocument CreateToast()
        {
            var xDoc = new XDocument(
               new XElement("toast",
               new XElement("visual",
               new XElement("binding", new XAttribute("template", "ToastGeneric"),
               new XElement("text", "C# Corner"),
               new XElement("text", "Do you got MVP award?")
            )
            ),// actions  
            new XElement("actions",
            new XElement("action", new XAttribute("activationType", "background"),
            new XAttribute("content", "Yes"), new XAttribute("arguments", "yes")),
            new XElement("action", new XAttribute("activationType", "background"),
            new XAttribute("content", "No"), new XAttribute("arguments", "no"))
            )
            )
            );

            var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            xmlDoc.LoadXml(xDoc.ToString());
            return xmlDoc;
        }

        internal void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            UIEnabled = false;
            Debug.WriteLine("creating contact {0} ({1})", ContactName, ContactNumber);
            SignalContact contact = new SignalContact()
            {
                ContactDisplayName = ContactName,
                UserName = ContactNumber
            };
            ContactName = "";
            ContactNumber = "";
            SignalDBContext.UpdateContact(contact, true);
            UIEnabled = true;
        }
    }
}