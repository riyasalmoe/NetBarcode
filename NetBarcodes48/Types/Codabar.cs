using System;

namespace NetBarcodeNetBarcodes48.Types
{
    /// <summary>
    ///  Codabar encoding
    ///  Written by: Brad Barnhill
    ///  Refactored: Filipe Tagliatti
    /// </summary>
    internal class Codabar: Base, IBarcode
    {
        private readonly string _data;
        private System.Collections.Hashtable _codabarCode = new System.Collections.Hashtable(); //is initialized by init_Codabar()
        
        public Codabar(string data)
        {
            _data = data;
        }//Codabar

        /// <summary>
        /// Encode the raw data using the Codabar algorithm.
        /// </summary>
        public string GetEncoding()
        {
            if (_data.Length < 2) throw new Exception("ECODABAR-1: Data format invalid. (Invalid length)");

            //check first char to make sure its a start/stop char
            switch (_data[0].ToString().ToUpper().Trim())
            {
                case "A": break;
                case "B": break;
                case "C": break;
                case "D": break;
                default: throw new Exception("ECODABAR-2: Data format invalid. (Invalid START character)");
            }//switch

            //check the ending char to make sure its a start/stop char
            switch (_data[_data.Trim().Length - 1].ToString().ToUpper().Trim())
            {
                case "A": break;
                case "B": break;
                case "C": break;
                case "D": break;
                default: throw new Exception("ECODABAR-3: Data format invalid. (Invalid STOP character)");
            }//switch

            //populate the hashtable to begin the process
            this.InitCodabar();

            //replace non-numeric VALID chars with empty strings before checking for all numerics
            string temp = _data;

            foreach (char c in _codabarCode.Keys)
            {
                if (!CheckNumericOnly(c.ToString()))
                {
                    temp = temp.Replace(c, '1');
                }//if
            }//if

            //now that all the valid non-numeric chars have been replaced with a number check if all numeric exist
            if (!CheckNumericOnly(temp))
                throw new Exception("ECODABAR-4: Data contains invalid  characters.");

            string result = "";

            foreach (char c in _data)
            {
                result += _codabarCode[c].ToString();
                result += "0"; //inter-character space
            }//foreach

            //remove the extra 0 at the end of the result
            result = result.Substring(0, result.Length - 1);

            //clears the hashtable so it no longer takes up memory
            this._codabarCode.Clear();

            return result;
        }//Encode_Codabar
        private void InitCodabar()
        {
            _codabarCode.Clear();
            _codabarCode.Add('0', "101010011");
            _codabarCode.Add('1', "101011001");
            _codabarCode.Add('2', "101001011");
            _codabarCode.Add('3', "110010101");
            _codabarCode.Add('4', "101101001");
            _codabarCode.Add('5', "110101001");
            _codabarCode.Add('6', "100101011");
            _codabarCode.Add('7', "100101101");
            _codabarCode.Add('8', "100110101");
            _codabarCode.Add('9', "110100101");
            _codabarCode.Add('-', "101001101");
            _codabarCode.Add('$', "101100101");
            _codabarCode.Add(':', "1101011011");
            _codabarCode.Add('/', "1101101011");
            _codabarCode.Add('.', "1101101101");
            _codabarCode.Add('+', "101100110011");
            _codabarCode.Add('A', "1011001001");
            _codabarCode.Add('B', "1001001011");
            _codabarCode.Add('C', "1010010011");
            _codabarCode.Add('D', "1010011001");
            _codabarCode.Add('a', "1011001001");
            _codabarCode.Add('b', "1001001011");
            _codabarCode.Add('c', "1010010011");
            _codabarCode.Add('d', "1010011001");
        }//init_Codeabar
    }//class
}//namespace
