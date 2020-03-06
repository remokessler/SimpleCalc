using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    internal class FormularParser
    {
        private string _formula { get; set; }
        public FormularParser()
        {

        }

        public void ParseFormula(string formula)
        {
            _formula = formula;
            while (IsParsingNotYetFinished())
            {
                char currentChar = GetCurrentChar();
                switch ((Operator)currentChar)
                {
                    case Operator.Division:
                        HandleDivisionSign();
                        break;
                    case Operator.Multiplication:
                        HandleMultiplicationSign();
                        break;
                    case Operator.Addition:
                        HandleAdditionSign();
                        break;
                    case Operator.Subtraction:
                        HandleMinusSign();
                        break;
                    default:
                        ReadNumberUntilNextOperator();
                        break;
                }
            }
        }

        private bool IsParsingNotYetFinished()
        {
            return _currentCharIndex < _formula.Length;
        }

        private char GetCurrentChar()
        {
            return _formula[_currentCharIndex];
        }

        private void HandleDivisionSign()
        {
            AddOperatorAndGoToNextNumber(Operator.Division);
        }

        private void HandleMultiplicationSign()
        {
            AddOperatorAndGoToNextNumber(Operator.Multiplication);
        }

        private void HandleAdditionSign()
        {
            AddOperatorAndGoToNextNumber(Operator.Addition);
        }

        private void AddOperatorAndGoToNextNumber(Operator operatorCharacter)
        {
            RecalculateCurrentCharIndex(operatorCharacter);
            AddOperatorToParsedOperators(operatorCharacter);
        }

        private void RecalculateCurrentCharIndex(Operator operatorCharacter)
        {
            _currentCharIndex = _formula.IndexOf((char)operatorCharacter) + 1;
        }

        private void AddOperatorToParsedOperators(Operator operatorCharacter)
        {
            _parsedOperators.Add(operatorCharacter);
        }

        private void HandleMinusSign()
        {
            if (BelongsTheMinusToTheNumber())
            {
                ReadNumberUntilNextOperator();
            }
            else
            {
                AddOperatorToParsedOperators(Operator.Subtraction);
                IncrementCurrentCharIndex();
            }
        }

        /// <summary>
        /// this method implicit take in count, that if a minus follows an another operator it must belong to the number
        /// </summary>
        /// <returns></returns>
        private bool BelongsTheMinusToTheNumber()
        {
            return _parsedNumbers.Count - _parsedOperators.Count == 0;
        }

        private bool AreThereStillAnyOtherOperators()
        {
            return _formula.IndexOfAny(VALID_OPERATORS, _currentCharIndex + 1) >= 0;
        }

        private void AddNextNumberToParsedNumbers()
        {
            _parsedNumbers.Add(GetNumberUntilNextOperator());
        }

        private void GotoNextOperator()
        {
            _currentCharIndex = _formula.IndexOfAny(VALID_OPERATORS, _currentCharIndex + 1);
        }

        private void AddLastNumberToParsed()
        {
            _parsedNumbers.Add(ParseLastTermToDouble());
        }

        private void SetCurrentCharIndexToTheEnd()
        {
            _currentCharIndex = _formula.Length;
        }

        private void IncrementCurrentCharIndex()
        {
            _currentCharIndex++;
        }

        private void ReadNumberUntilNextOperator()
        {
            if (AreThereStillAnyOtherOperators())
            {
                AddNextNumberToParsedNumbers();
                GotoNextOperator();
            }
            else
            {
                AddLastNumberToParsed();
                SetCurrentCharIndexToTheEnd();
            }
        }

        private double GetNumberUntilNextOperator()
        {
            return Convert.ToDouble(_formula.Substring(_currentCharIndex, _formula.IndexOfAny(VALID_OPERATORS, _currentCharIndex + 1) - _currentCharIndex));
        }

        private double ParseLastTermToDouble()
        {
            return Convert.ToDouble(_formula.Substring(_currentCharIndex));
        }
    }
}
