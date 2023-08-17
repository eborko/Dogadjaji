using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dogadjaji.Model
{
    class Grad : INotifyPropertyChanged
    {
        #region Fields
        private Guid _id;
        private string _naziv;
        private ISet<Dogadjaj> _dogadjaji;
        #endregion

        #region Constructors
        public Grad(string naziv)
        {
            _id = Guid.NewGuid();
            _naziv = naziv;
            _dogadjaji = new HashSet<Dogadjaj>();
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
                if (value != null && !value.Equals(_naziv, StringComparison.InvariantCultureIgnoreCase))
                { 
                    _naziv = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ISet<Dogadjaj> Dogadjaji { get { return _dogadjaji; } }
        #endregion
    }
}
