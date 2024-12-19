using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //To jest messanger, którzy oczekuje na Stringa. Jak string zostanie złapany to wywołuje metode Open, która jest zdefiniowana w regionie Private Helpers.
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Towary",
                    new BaseCommand(() => this.ShowAllTowar())),

                new CommandViewModel(
                    "Towar",
                    new BaseCommand(() => this.CreateTowar())),
                 new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.ShowAllFaktury())),
                  new CommandViewModel(
                    "Faktura",
                    new BaseCommand(() => this.CreateFaktura())),
                  new CommandViewModel(
                    "Film",
                    new BaseCommand(() => this.CreateFilm())),
                  new CommandViewModel(
                    "Filmy",
                    new BaseCommand(() => this.ShowAllFilmy())),
                  new CommandViewModel(
                    "Bilet",
                    new BaseCommand(() => this.CreateBilet())),
                  new CommandViewModel(
                    "Bilety",
                    new BaseCommand(() => this.ShowAllBilety())),
                  new CommandViewModel(
                    "Klient",
                    new BaseCommand(() => this.CreateKlient())),
                  new CommandViewModel(
                    "Klienci",
                    new BaseCommand(() => this.ShowAllKlienci())),
                  new CommandViewModel(
                    "Promocja",
                    new BaseCommand(() => this.CreatePromocja())),
                  new CommandViewModel(
                    "Promocje",
                    new BaseCommand(() => this.ShowAllFPromocje())),
                  new CommandViewModel(
                    "Recenzja",
                    new BaseCommand(() => this.CreateRecenzja())),
                  new CommandViewModel(
                    "Recenzje",
                    new BaseCommand(() => this.ShowAllRecenzje())),
                  new CommandViewModel(
                    "Rezerwacja",
                    new BaseCommand(() => this.CreateRezerwacja())),
                  new CommandViewModel(
                    "Rezerwacje",
                    new BaseCommand(() => this.ShowAllRezerwacje())),
                  new CommandViewModel(
                    "Repertuar",
                    new BaseCommand(() => this.CreateRepertuar())),
                  new CommandViewModel(
                    "Repertuary",
                    new BaseCommand(() => this.ShowAllRepertuary())),
                  new CommandViewModel(
                    "Dostawca",
                    new BaseCommand(() => this.CreateDostawca())),
                  new CommandViewModel(
                    "Dostawcy",
                    new BaseCommand(() => this.ShowAllDostawcy())),
                  new CommandViewModel(
                    "Kontrahent",
                    new BaseCommand(() => this.CreateKontrahent())),
                  new CommandViewModel(
                    "Kontrahenci",
                    new BaseCommand(() => this.ShowAllKontrahenci())),
                  new CommandViewModel(
                    "Sala",
                    new BaseCommand(() => this.CreateSala())),
                  new CommandViewModel(
                    "Sale",
                    new BaseCommand(() => this.ShowAllSale())),
                  new CommandViewModel(
                    "Statystyka",
                    new BaseCommand(() => this.CreateStatystyka())),
                  new CommandViewModel(
                    "Statystyki",
                    new BaseCommand(() => this.ShowAllStatystyki())),
                  new CommandViewModel(
                    "Domowienie",
                    new BaseCommand(() => this.CreateDomowienie())),
                  new CommandViewModel(
                    "Domowienia",
                    new BaseCommand(() => this.ShowAllDomowienia())),
                  new CommandViewModel(
                    "Raport Sprzedazy",
                    new BaseCommand(() => this.CreateRaportSprzedazy())),
                  new CommandViewModel(
                    "Raport Sprzedazy Towarow",
                    new BaseCommand(() => this.CreateRaportSprzedazyTowarow())),



            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
       
        private void CreateTowar()
        {
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRaportSprzedazyTowarow()
        {
            RaportSprzedazyTowarowViewModel workspace = new RaportSprzedazyTowarowViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRaportSprzedazy()
        {
            RaportSprzedazyViewModel workspace = new RaportSprzedazyViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateDomowienie()
        {
            NoweDomowienieViewModel workspace = new NoweDomowienieViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateStatystyka()
        {
            NowaStatystykaViewModel workspace = new NowaStatystykaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateSala()
        {
            NowaSalaViewModel workspace = new NowaSalaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateKontrahent()
        {
            NowyKontrahentViewModel workspace = new NowyKontrahentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateDostawca()
        {
            NowyDostawcaViewModel workspace = new NowyDostawcaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRepertuar()
        {
            NowyRepertuarViewModel workspace = new NowyRepertuarViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRezerwacja()
        {
            NowaRezerwacjaViewModel workspace = new NowaRezerwacjaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRecenzja()
        {
            NowaRecenzjaViewModel workspace = new NowaRecenzjaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePromocja()
        {
            NowaPromocjaViewModel workspace = new NowaPromocjaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateKlient()
        {
            NowyKlientViewModel workspace = new NowyKlientViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateBilet()
        {
            NowyBiletViewModel workspace = new NowyBiletViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateFilm()
        {
            NowyFilmViewModel workspace = new NowyFilmViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKontrahenci()
        {
            WszyscyKontrahenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel)
                as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllDomowienia()
        {
            WszystkieDomowieniaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieDomowieniaViewModel)
                as WszystkieDomowieniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieDomowieniaViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStatystyki()
        {
            WszystkieStatystykiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStatystykiViewModel)
                as WszystkieStatystykiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatystykiViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllSale()
        {
            WszystkieSaleViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieSaleViewModel)
                as WszystkieSaleViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSaleViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFilmy()
        {
            WszystkieFilmyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFilmyViewModel)
                as WszystkieFilmyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFilmyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllDostawcy()
        {
            WszyscyDostawcyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyDostawcyViewModel)
                as WszyscyDostawcyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyDostawcyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRepertuary()
        {
            WszystkieRepertuaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRepertuaryViewModel)
                as WszystkieRepertuaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRepertuaryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRezerwacje()
        {
            WszystkieRezerwacjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRezerwacjeViewModel)
                as WszystkieRezerwacjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRezerwacjeViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllRecenzje()
        {
            WszystkieRecenzjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRecenzjeViewModel)
                as WszystkieRecenzjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRecenzjeViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFPromocje()
        {
            WszystkiePromocjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePromocjeViewModel)
                as WszystkiePromocjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePromocjeViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKlienci()
        {
            WszyscyKlienciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKlienciViewModel)
                as WszyscyKlienciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKlienciViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllBilety()
        {
            WszystkieBiletyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieBiletyViewModel)
                as WszystkieBiletyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieBiletyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(string name) //name to jest wysłany komunikat
        {
            if (name == "TowaryAdd") CreateView(new NowyTowarViewModel());
            if (name == "DomowieniaAdd") CreateView(new NoweDomowienieViewModel());
            if (name == "StatystkiAdd") CreateView(new NowaStatystykaViewModel());
            if (name == "SaleAdd") CreateView(new NowaSalaViewModel());
            if (name == "KontrahenciAdd") CreateView(new NowyKontrahentViewModel());
            if (name == "RepertuaryAdd") CreateView(new NowyRepertuarViewModel());
            if (name == "DostawcyAdd") CreateView(new NowyDostawcaViewModel());
            if (name == "RezerwacjeAdd") CreateView(new NowaRezerwacjaViewModel());
            if (name == "RecenzjeAdd") CreateView(new NowaRecenzjaViewModel());
            if (name == "PromocjeAdd") CreateView(new NowaPromocjaViewModel());
            if (name == "KlienciAdd") CreateView(new NowyKlientViewModel());
            if (name == "FakturyAdd") CreateView(new NowaFakturaViewModel());
            if (name == "BiletyAdd") CreateView(new NowyBiletViewModel());
            if (name == "FilmyAdd") CreateView(new NowyFilmViewModel());                
        }
        private void CreateView (WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        #endregion
    }
}
