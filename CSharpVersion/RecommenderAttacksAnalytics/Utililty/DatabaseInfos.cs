using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using RecommenderAttacksAnalytics.Utility;

namespace RecommenderAttacksAnalytics.Utililty
{
    public class DatabaseInfos : DependencyObject
    {
        private const string ENCRYPTION_KEY = "d466e0d2a62a6d6f0617ad517040fc8cd155477a6fcd7720bd0f50c2c174459b";

        public string HostName
        {
            get { return (string)GetValue(HostNameProperty); }
            set { SetValue(HostNameProperty, value); }
        }

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public int Port
        {
            get { return (int)GetValue(PortProperty); }
            set { SetValue(PortProperty, value); }
        }

        public string Schema
        {
            get { return (string)GetValue(SchemaProperty); }
            set { SetValue(SchemaProperty, value); }
        }

        public static readonly DependencyProperty SchemaProperty =
            DependencyProperty.Register("Schema", typeof(string), typeof(DatabaseInfos), new UIPropertyMetadata(""));

        public static readonly DependencyProperty PortProperty =
            DependencyProperty.Register("Port", typeof(int), typeof(DatabaseInfos), new UIPropertyMetadata(3306));
        
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(DatabaseInfos), new UIPropertyMetadata(""));

        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(DatabaseInfos), new UIPropertyMetadata(""));

        public static readonly DependencyProperty HostNameProperty =
            DependencyProperty.Register("HostName", typeof(string), typeof(DatabaseInfos), new UIPropertyMetadata(""));


        public void loadFromFile(string filePath)
        {
            
        }

        private XElement parseToXml()
        {
            var root = new XElement("root");
            root.Add(new XElement(HostNameProperty.Name, Schema));
            root.Add(new XElement(UsernameProperty.Name, Username));
            root.Add(new XElement(PasswordProperty.Name, Util.encrypt(Password,ENCRYPTION_KEY)));
            root.Add(new XElement(PortProperty.Name, Port));
            root.Add(new XElement(SchemaProperty.Name, Schema));

            return root;
        }


        public void saveAsXml(string filePath)
        {
            var xmlRoot = parseToXml();
            xmlRoot.Save(filePath);
        }

        public string getConnectionString()
        {
            return String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", HostName , Port, Schema, Username, Password);
        }
    }
}
