﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MegaCastings.DBLib;
using System.Xml;
using System.Xml.Linq;

namespace MegaCastings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitGridView();
            
        }

        /// <summary>
        /// Initialise le GrigView avec la liste des clients
        /// </summary>
        private void InitGridView()
        {
            MainGroupBox.Header = "Clients";
            MegaCastingsEntities db = new MegaCastingsEntities();
            List<Client> ClientsList = db.Clients.ToList();
            foreach (var client in ClientsList)
            {
                client.FormatPhoneNumberForDisplay();
            }
            MainListView.ItemsSource = ClientsList;


        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Ouvre une fenêtre modale pour ajouter un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if(MainGroupBox.Header.Equals("Clients"))
            {
                //AjouterPersonne fenetreAjoutPersonne = new AjouterPersonne();
                //fenetreAjoutPersonne.ShowDialog();
                //DBLib.MegaCastingsEntities db = new MegaCastingsEntities();
            }
            else if(MainGroupBox.Header.Equals("Partenaires"))
            {

            }

            else if(MainGroupBox.Equals("Castings"))
            {

            }
        }

        /// <summary>
        /// /// Ouvre une fenêtre modale pour modifier un client ou bien une offre de casting, ou encore un partenaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Manage(object sender, RoutedEventArgs e)
        {
            if (MainGroupBox.Header.Equals("Clients"))
            {
                
            }
            else if (MainGroupBox.Header.Equals("Partenaires"))
            {

            }

            else if (MainGroupBox.Equals("Castings"))
            {

            }
        }

        /// Ouvre une fenêtre modale pour supprimer un client ou bien une offre de casting, ou encore un partenaire
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (MainGroupBox.Header.Equals("Clients"))
            {
               
            }
            else if (MainGroupBox.Header.Equals("Partenaires"))
            {

            }

            else if (MainGroupBox.Equals("Castings"))
            {

            }
        }

        /// <summary>
        /// /// Affiche via le GridView la liste des clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayClients(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Clients";
            //MainGridView.Columns.Clear();
            //MainGridView.Columns.Add(new GridViewColumn());
            //MainGridView.Columns[0].Header = "Test";
            //MainGridView.Columns[0].Width = 50;

            if (StackPanelButtons.Children.Count == 0)
            {
                // Button b_ajouter = new Button();
                // b_ajouter.Content = "Ajouter";
                // b_ajouter.Click += new System.Windows.RoutedEventHandler(this.Button_Click_AjouterClient);
                //StackPanelButtons.Children.Add(b_ajouter);
            }

        }

        /// <summary>
        /// Affiche via le GridView la liste des castings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayCastings(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Castings";
        }

        /// <summary>
        /// /// Affiche via le GridView la liste des partenaires
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DisplayPartenaires(object sender, RoutedEventArgs e)
        {
            MainGroupBox.Header = "Partenaires";
        }

        private void MenuItemXML_Click(object sender, RoutedEventArgs e)
        {
           // MegaCastingsEntities db = new MegaCastingsEntities();
           //Client test =  db.Clients.First();

           // XmlWriter rdr = XmlWriter.Create(@"../../../flux/offres.xml", new XmlWriterSettings() {Indent = true});
           // rdr.WriteProcessingInstruction("xml-stylesheet","type=\"text/xsl\" href=\"style.xsl\"");
           // XElement offres = new XElement("rss", new XAttribute("version", "2.0"));
           // XElement channel = new XElement("channel", new XElement("title", "MegaCastings : liste des offres"), new XElement("description", "Retrouvez en temps réel les propositions d'offres de MégaCastings !"), new XElement("lastBuildDate", DateTime.Now.ToLongTimeString()), new XElement("link", "www.megacastings.fr/rss"));
           // try
           // {
           //     foreach (OffreCasting casting in db.OffreCastings)
           //     {
           //         channel.Add(new XElement("offre", new XElement("title", casting.Intitule +" ("+casting.Reference+")"), new XElement("description",casting.DescriptionPoste+"\n"+casting.DescriptionProfil), new XElement("pubDate", casting.DateDebut), new XElement("link", "www.megacasting.fr/"+casting.Identifiant+".html")));
           //     }

           // }
           // catch(Exception ex)
           // {
           // }

           // offres.Add(channel);

           // offres.WriteTo(rdr);

           // rdr.Flush();
           // rdr.Close();

        }
    }
}
