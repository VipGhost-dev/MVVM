using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MVVM
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstNum
        {
            set
            {
                Model.FirstNumber = value;
            }
        }
        public string SecondNum
        {
            set
            {
                Model.SecondNumber = value;
            }
        }

        public string Result
        {
            get
            {
                return Model.result.ToString();
            }
        }

        public List<String> ComboChange
        {
            get
            {
                return Model.Symbols;
            }
        }
        int index = -1;
        public int IndexSelected
        {
            set
            {
                Model.comboIndex = value;
                index = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChangeIndex"));
            }
        }

        public string ChangeIndex
        {
            get
            {
                if (index == -1)
                {
                    return "";
                }
                else
                {
                    return Model.CharSymbols[index];
                }
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                double numberFirst = 0;
                double numberSecondly = 0;
                if (Model.FirstNumber != "")
                {
                    try
                    {
                        numberFirst = Convert.ToDouble(Model.FirstNumber);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Первое поле имеет неверный формат, оно должно быть числовым (дробная часть отделяется символом \",\")!");
                        return;
                    }
                }
                if (Model.SecondNumber != "")
                {
                    try
                    {
                        numberSecondly = Convert.ToDouble(Model.SecondNumber);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Второе поле имеет неверный формат, оно должно быть числовым (дробная часть отделяется символом \",\")!");
                        return;
                    }
                }
                switch (Model.comboIndex)
                {
                    case -1:
                        MessageBox.Show("Арифметическая операция не выбрана");
                        return;
                    case 0:
                        Model.result = Convert.ToString(numberFirst + numberSecondly);
                        break;
                    case 1:
                        Model.result = Convert.ToString(numberFirst - numberSecondly);
                        break;
                    case 2:
                        Model.result = Convert.ToString(numberFirst * numberSecondly);
                        break;
                    case 3:
                        if (numberSecondly == 0)
                        {
                            Model.result = "Деление на 0 (ноль) не допустимо";
                        }
                        else
                        {
                            Model.result = Convert.ToString(numberFirst / numberSecondly);
                        }
                        break;
                    default:
                        MessageBox.Show("При расчёте возникла ошибка");
                        return;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ResultChange"));
            }
            catch
            {
                MessageBox.Show("При вычисление арифметической операции возникла ошибка");
            }
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
