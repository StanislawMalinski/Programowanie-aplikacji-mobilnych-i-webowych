using Client.ViewModel;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Windows
{
    //MVVM

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SearchFilmForm : Window
    {
        private readonly SearchFilmFormViewModel _viewModel;
        public SearchFilmForm(SearchFilmFormViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }
    }
}