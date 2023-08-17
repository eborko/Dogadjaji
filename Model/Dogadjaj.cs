using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Dogadjaji.Model
{
    class Dogadjaj : INotifyPropertyChanged
    {
        #region Fields
        private Guid _id;
        private string _naziv;
        private Grad _gradOdrzavanja;
        private DateAndTime _datumIVrijemePocetka;
        private int _trajanjeUMinutima;
        #endregion

        #region Constructors
        public Dogadjaj(string naziv, Grad gradOdrzavanja, DateAndTime datumIVrijemePocetka, int trajanjeUMinutima)
        {
            _naziv = naziv;
            _id = Guid.NewGuid();
            _gradOdrzavanja = gradOdrzavanja;
            _datumIVrijemePocetka = datumIVrijemePocetka;
            _trajanjeUMinutima = trajanjeUMinutima;
        }
        #endregion

        /// <summary>
        /// Dogadjaj (misli se na jezicki Event u C# a ne na nas Dogadjaj u Modelu)
        /// uvezen je iz INotifyPropertyChanged interfejsa
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Uvijek se poziva prilikom promjene nekog od Property-ja
        /// </summary>
        /// <param name="propertyName">Naziv Property-ja</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Properties
        public Guid Id { get { return _id; } }

        public string Naziv
        {
            get { return _naziv; }
            set
            {
                if (_naziv != value) { _naziv = value; NotifyPropertyChanged(); }
            }
        }

        public Grad GradOdrzavanja
        {
            get { return GradOdrzavanja; }
            set
            {
                if (value != null && value.Id != _gradOdrzavanja.Id)
                {
                    _gradOdrzavanja = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateAndTime DatumIVrijemePocetka 
        {
            get { return _datumIVrijemePocetka; }
            set
            {
                if (value != null && !DateAndTime.Equals(value, _datumIVrijemePocetka))
                {
                    _datumIVrijemePocetka = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TrajanjeUMinutima 
        {
            get { return _trajanjeUMinutima; } 
            set
            {
                if (_trajanjeUMinutima != value)
                {
                    _trajanjeUMinutima = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
    }
}
