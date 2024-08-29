using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TPC_Equipo_5
{
    public static class Validacion
    {
        public static bool validarTexto(object control)
        {
            if(control is TextBox txtbox)
            {
                if(string.IsNullOrEmpty(txtbox.Text))
                {
                    return false;
                }
                else return true;
            }

            return false;
        }
        public static bool esNumeroEntero(object control)
        {
            if (control is TextBox txtbox)
            {
                int numero;
                return int.TryParse(txtbox.Text, out numero);
            }
            return false;
        }
        public static bool esStockValido(object control)
        {
            if (control is TextBox txtbox)
            {
                if(txtbox.Text == "")
                    return false;
                if(int.Parse(txtbox.Text) < 0) return false;     
            }
            return false;
        }

        public static bool esNumeroDecimal(object control)
        {
            if (control is TextBox txtbox)
            {
                decimal numero;
                return decimal.TryParse(txtbox.Text, out numero);
            }
            return false;
        }

    }
}