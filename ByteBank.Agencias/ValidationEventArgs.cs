using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Agencias {
  public class ValidationEventArgs : EventArgs {
    public string Text { get; private set; }
    public bool isValid { get; set; }

    public ValidationEventArgs(string text) {
      Text = text;
      isValid = true;
    }
  }
}
