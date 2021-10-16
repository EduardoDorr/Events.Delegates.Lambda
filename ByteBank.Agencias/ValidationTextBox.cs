using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias {
  public delegate void ValidationEventHandler(object sender, ValidationEventArgs e);

  public class ValidationTextBox : TextBox {
    private ValidationEventHandler _validation;
    
    public event ValidationEventHandler Validation {
      add {
        _validation += value;
        OnValidation();
      }
      remove {
        _validation -= value;
        OnValidation();
      }
    }

    protected override void OnTextChanged(TextChangedEventArgs e) {
      base.OnTextChanged(e);
      OnValidation();
    }

    protected virtual void OnValidation() {
      if (_validation != null) {
        var validationList = _validation.GetInvocationList();
        var eventArgs = new ValidationEventArgs(Text);
        var isValid = true;

        foreach (ValidationEventHandler validation in validationList) {
          validation(this, eventArgs);

          if (!eventArgs.isValid) {
            isValid = false;
            break;
          }
        }

        Background = isValid
          ? new SolidColorBrush(Colors.White)
          : new SolidColorBrush(Colors.OrangeRed);
      }
    }
  }
}
