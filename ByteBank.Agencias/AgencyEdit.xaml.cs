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
using System.Windows.Shapes;

namespace ByteBank.Agencias {
  /// <summary>
  /// Lógica interna para AgencyEdit.xaml
  /// </summary>
  public partial class AgencyEdit : Window {
    private readonly Agencia _agency;
    public AgencyEdit(Agencia agencia ) {
      InitializeComponent();

      _agency = agencia ?? throw new ArgumentNullException(nameof(agencia));
      RefreshFields();
      RefreshControls();
    }

    private void RefreshFields() {
      txtNumber.Text = _agency.Numero;
      txtName.Text = _agency.Nome;
      txtTelephone.Text = _agency.Telefone;
      txtDescription.Text = _agency.Telefone;
      txtAddress.Text = _agency.Endereco;
    }

    private void RefreshControls() {
      RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
      RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

      var okEventHandler = dialogResultTrue + CloseWindow;
      var cancelEventHandler = dialogResultFalse + CloseWindow;

      btnOK.Click += okEventHandler;
      btnCancel.Click += cancelEventHandler;

      txtNumber.Validation += NullFieldValidation;
      txtNumber.Validation += ValidateNumber;

      txtName.Validation += NullFieldValidation;

      txtTelephone.Validation += NullFieldValidation;

      txtDescription.Validation += NullFieldValidation;
      
      txtAddress.Validation += NullFieldValidation;

      //RoutedEventHandler dialogResultTrue = delegate (object o, RoutedEventArgs e) {
      //  DialogResult = true;
      //};

      //RoutedEventHandler dialogResultFalse = delegate (object o, RoutedEventArgs e) {
      //  DialogResult = false;
      //};

      //var okEventHandler = (RoutedEventHandler)btnOK_Click + CloseWindow;
      //var cancelEventHandler = (RoutedEventHandler)btnCancel_Click + CloseWindow;

      // Makes the same as the upper line
      //var cancelEventHandler = 
      //  (RoutedEventHandler)Delegate.Combine(
      //    (RoutedEventHandler)btnCancel_Click,
      //    (RoutedEventHandler)CloseWindow);

      //btnOK.Click += new RoutedEventHandler(btnOK_Click);
      //btnOK.Click += new RoutedEventHandler(CloseWindow);

      //btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
      //btnCancel.Click += new RoutedEventHandler(CloseWindow);
    }

    private void ValidateNumber(object sender, ValidationEventArgs e) {
      e.isValid = e.Text.All(Char.IsDigit);
    }

    private void NullFieldValidation(object sender, ValidationEventArgs e) {
      e.isValid = !String.IsNullOrEmpty(e.Text);
    }
    
    //private void btnOK_Click(object sender, EventArgs e) {
    //  DialogResult = true;
    //}

    //private void btnCancel_Click(object sender, EventArgs e) {
    //  DialogResult = false;
    //}

    private void CloseWindow(object sender, EventArgs e) {
      Close();
    }
  }
}
