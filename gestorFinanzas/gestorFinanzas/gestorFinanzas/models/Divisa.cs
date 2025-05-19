using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorFinanzas.models
{
    public class Divisa
    {
        private List<string> listaDivisa = new List<string>
        {
            "AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN",
            "BAM", "BBD", "BDT", "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BRL",
            "BSD", "BTN", "BWP", "BYN", "BZD", "CAD", "CDF", "CHF", "CLP", "CNY",
            "COP", "CRC", "CUP", "CZK", "DKK", "DOP", "DZD", "EGP", "EUR", "FJD",
            "GBP", "GEL", "GHS", "GTQ", "HKD", "HNL", "HRK", "HUF", "IDR", "ILS",
            "INR", "IQD", "IRR", "ISK", "JMD", "JOD", "JPY", "KES", "KGS", "KHR",
            "KMF", "KRW", "KWD", "KYD", "LAK", "LBP", "LKR", "LRD", "LSL", "LYD",
            "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MUR", "MVR",
            "MWK", "MXN", "MYR", "NAD", "NGN", "NOK", "NPR", "NZD", "OMR", "PAB",
            "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON", "RSD", "RUB",
            "RWF", "SAR", "SCR", "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SRD",
            "SSP", "STD", "SYP", "SZL", "THB", "TJS", "TMT", "TND", "TOP", "TRY",
            "TTD", "TWD", "TZS", "UAH", "UGX", "USD", "UYU", "UZS", "VEF", "VND",
            "VUV", "WST", "XAF", "XCD", "XOF", "XPF", "YER", "ZAR", "ZMW", "ZWL"
        };

        public Divisa()
        {

        }

        public List<String> getlistaMonedas()
        {
            return this.listaDivisa;
        }
    }
}
