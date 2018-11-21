using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP.Data
{
    public class ValidateUtil
    {
        public string Error { get; private set; }
        public bool Valide(Control parent,bool loop) {
            bool validate = true;
            foreach (Control c in parent.Controls)
            {
                if (!string.IsNullOrWhiteSpace(c.Tag+""))
                { 
                    
                }

                if (loop)
                {
                    validate = validate && Valide(c, true);
                }

            }
            return validate;
        }
    }
}
