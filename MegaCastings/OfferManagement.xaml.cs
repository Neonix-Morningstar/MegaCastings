﻿using MegaCastings.Entities;
using NHibernate;
using System;
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
using System.Windows.Shapes;

namespace MegaCastings
{
    /// <summary>
    /// Interaction logic for OfferManagement.xaml
    /// </summary>
    public partial class OfferManagement : Window
    {

        #region Attributes & Properties

        private CastingOffer _CurrentOffer;
        private string generatedRef;

        /// <summary>
        /// Affecte ou obtient le partenaire en cours de modification
        /// </summary>
        public CastingOffer CurrentOffer
        {
            get { return _CurrentOffer; }
            set { _CurrentOffer = value; }
        }

        #endregion

        #region Constructors

        public OfferManagement()
        {
            CurrentOffer = new CastingOffer() { PostNumber = 1};
            InitializeComponent();
            tbRef.Text = generatedRef;
            DTPDu.Value = DateTime.Now;
            DTPAu.Value = DateTime.Now.AddMonths(1);
        }



        public OfferManagement(CastingOffer toModify)
        {
            CurrentOffer = toModify;
            InitializeComponent();
            Loading();
        }
        #endregion

        #region Events
        /// <summary>
        /// Evènement click bouton "Annuler"
        /// </summary>
        private void b_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Evènement click bouton "Ok"
        /// </summary>
        private void b_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbTitle.Text) && !string.IsNullOrEmpty(tbProfil.Text) && !string.IsNullOrEmpty(tbDescription.Text) && cbClient.SelectedItem != null && !string.IsNullOrEmpty(cbProfession.Text) && !string.IsNullOrEmpty(cbType.Text))
            {
                try
                {
                    ISessionFactory isessionfactory = MainWindow.CreateSessionFactory();
                    using (ISession session = isessionfactory.OpenSession())//ouverture
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                if (CurrentOffer.Id == 0)
                                {
                                    session.SaveOrUpdate(CurrentOffer);
                                }

                                else
                                {
                                    session.Flush();
                                }

                                transaction.Commit();

                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                        session.Close();
                    }
                    MessageBox.Show("Effectué avec succès ! ");
                    isessionfactory.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.DialogResult = true;
                this.Close();
            }

            else
            {
                MessageBox.Show("Merci de remplir tous les champs.");
            }
        }
        #endregion

        private void Loading()
        {
            IList<Client> ClientList;
            IList<Profession> ProfList;
            IList<ContractType> TypeList;
            string DateTodayTransformed = (DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString("D2") + "." + DateTime.Now.Year.ToString().Substring(2));

            this.DataContext = this;

            ISessionFactory isessionfactory = MainWindow.CreateSessionFactory();
            using (ISession session = isessionfactory.OpenSession())//ouverture
            {
                ClientList = session.QueryOver<Client>().List();
                ProfList = session.QueryOver<Profession>().List();
                TypeList = session.QueryOver<ContractType>().List();
                generatedRef = DateTodayTransformed + "-" + (session.QueryOver<CastingOffer>().WhereRestrictionOn(c => c.Reference).IsLike(DateTodayTransformed + "%").RowCount() + 1);
                session.Close();
            }
            isessionfactory.Close();
            cbClient.ItemsSource = ClientList;
            cbProfession.ItemsSource = ProfList;
            cbType.ItemsSource = TypeList;
        }
    }
}
