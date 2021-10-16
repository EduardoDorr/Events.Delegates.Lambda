using ByteBank.Agencias.DAL;
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

namespace ByteBank.Agencias {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
    private readonly ListBox lstAgencies;
    public MainWindow() {
      InitializeComponent();

      lstAgencies = new ListBox();

      RefreshControls();
      RefreshList();
    }

    private void RefreshControls() {
      lstAgencies.Width = 270;
      lstAgencies.Height = 290;
      Canvas.SetTop(lstAgencies, 15);
      Canvas.SetLeft(lstAgencies, 15);

      btnEdit.Click += new RoutedEventHandler(btnEdit_Click);
      lstAgencies.SelectionChanged += new SelectionChangedEventHandler(lstAgencies_SelectionChanged);

      container.Children.Add(lstAgencies);
    }

    private void RefreshList() {
      lstAgencies.Items.Clear();
      var agencias = _contextoBancoDeDados.Agencias.ToList();

      foreach (var agencia in agencias) {
        lstAgencies.Items.Add(agencia);
      }
    }

    private void btnEdit_Click(object sender, RoutedEventArgs e) {
      var actualAgency = (Agencia)lstAgencies.SelectedItem;
      var editWindow = new AgencyEdit(actualAgency);
      var result = editWindow.ShowDialog().Value;

      if (result) {
        // Usuário clicou ok
      }
      else {
        // Usuário clicou cancelar
      }
    }

    private void lstAgencies_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      var agencySelected = (Agencia)lstAgencies.SelectedItem;

      txtNumber.Text = agencySelected.Numero;
      txtName.Text = agencySelected.Nome;
      txtTelephone.Text = agencySelected.Telefone;
      txtDescription.Text = agencySelected.Telefone;
      txtAddress.Text = agencySelected.Endereco;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      var confirmation = MessageBox.Show("Você deseja realmente excluir este item?",
                                         "Confirmação",
                                         MessageBoxButton.YesNo);

      if (confirmation == MessageBoxResult.Yes) {
        // Delete
      }
      else {
        // Make nothing
      }
    }
  }
}
