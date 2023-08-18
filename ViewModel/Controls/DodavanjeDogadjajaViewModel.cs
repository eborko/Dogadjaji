using Dogadjaji.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dogadjaji.ViewModel.Controls
{
    class DodavanjeDogadjajaViewModel : DependencyObject
    {
        public Dogadjaj Dogadjaj
        {
            get { return (Dogadjaj)GetValue(DogadjajProperty); }
            set { SetValue(DogadjajProperty, value); }
        }
        public DodavanjeDogadjajaViewModel()
        {
            Dogadjaj = new Dogadjaj("Naziv dogadjaja", new Grad("Naziv Grada"), DateTime.Now, 0);
        }

        public static readonly DependencyProperty DogadjajProperty = DependencyProperty.Register(
            name: "Dogadjaj",
            propertyType: typeof(Dogadjaj),
            ownerType: typeof(DodavanjeDogadjajaViewModel));
    }
}
