using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public class Calculator
    {
        //ToDo: Extraction into Enum

        private IList<double> _parsedNumbers;
        private IList<char> _parsedOperators;
        private string _formula = string.Empty;
        private int _currentCharIndex;


        public double Calculate(string formula)
        {
            InitMembers(formula);
            ParseFormula();
            return CalculateTerms();
        }

        private void InitMembers(string formula)
        {
            _formula = CutSpaces(formula);
            _currentCharIndex = 0;
            _parsedNumbers = new List<double>();
            _parsedOperators = new List<char>();
        }

        private string CutSpaces(string formula)
        {
            return formula.Replace(" ", string.Empty);
        }

        #region parsing

        #endregion

        #region calculating


        private double CalculateTerms()
        {
            double result = _parsedNumbers[0];

            try
            {
                _parsedNumbers.Remove(result);

                foreach (char c in _parsedOperators)
                {
                    switch (c)
                    {
                        case DIVISION:
                            result = Divide(result);
                            break;
                        case MULTIPLICATION:
                            result = Multiply(result);
                            break;
                        case ADDITION:
                            result = Add(result);
                            break;
                        case SUBSTRACTION:
                            result = Subtract(result);
                            break;
                    }
                    _parsedNumbers.Remove(_parsedNumbers[0]);
                }
            }
            catch (Exception)
            {
                throw new ArithmeticException("Calculation failed!");
            }

            return Math.Round(result, 5);
        }

        private double Divide(double result)
        {
            return result / _parsedNumbers[0];
        }

        private double Multiply(double result)
        {
            return result * _parsedNumbers[0];
        }

        private double Add(double result)
        {
            return result + _parsedNumbers[0];
        }

        private double Subtract(double result)
        {
            return result - _parsedNumbers[0];
        }

        #endregion

    }
}