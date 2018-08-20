using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Krestiki_noliki_3._0
{
    public class MachineIntelligenceModel
    {
        private DBManagerModel _dbManager = new DBManagerModel();        
        public MachineIntelligenceModel()
        { }        

        //метод, вызываемый событием изменения значения клетки: получение выборки из БД и анализ комбинаций 
        public string Analysis (out bool O_canWin)
      {
            List<CellModel> values =_dbManager.GetAllValues();
            string result = "";

        //выигрышные комбинации индексов ячеек поля, которые будут проверяться машиной
        int[] win1 = new int[3] { 0, 1, 2 };
            int[] win2 = new int[3] { 3, 4, 5 };
            int[] win3 = new int[3] { 6, 7, 8 };
            int[] win4 = new int[3] { 0, 3, 6 };
            int[] win5 = new int[3] { 1, 4, 7 };
            int[] win6 = new int[3] { 2, 5, 8 };
            int[] win7 = new int[3] { 0, 4, 8 };
            int[] win8 = new int[3] { 2, 4, 6 };
            //массив таких комбинаций
            List<int[]> Wincombination = new List<int[]>() { win1, win2, win3, win4, win5, win6, win7, win8 };

            //цель, цифры от 0 до 8 - индексы целевых ячеек поля для хода машины
            int TargetN = 0;
            /*экстренная цель, индекс целевой ячейки для хода машины в ситуациях,
            когда нужно срочно помешать выиграть сопернику или совершить победный ход. 
            По умолчанию равен 10, т.к. такого индекса нет ни у одной ячейки.*/
            int alarmTargetN = 10;

            //счетчик, следящий за заполненностью поля
            bool CountNull = false;
            //флаг, показывающий, что создалась особая ситуация, в которой машина одержит победу на следующем ходу
            O_canWin = false;

            // алгоритм обработки информации. 
            foreach (int[] win in Wincombination) //внешний цикл перебирает возможные выигрышные комбинации,
                                                  //и для каждой из них запускает внутренний цикл сравнения
            {
                int CountX = 0;//счетчик X в текущей комбинации
                int CountO = 0;//счетчик О в текущей комбинации

                for (int n = 0; n <= win.Length - 1; n++) //внутренний цикл перебирает элементы комбинации
                {
                    int i = win[n];
                    //значение каждого элемента комбинации - это индекс ячейки массива текущих значений,
                    //который будет проверяться на равенство X, O или null

                    if (values[i].CellValue == "x")
                    {
                        CountX = CountX + 1;

                    }
                    if (values[i].CellValue == "o")
                    {
                        CountO = CountO + 1;

                    }
                    if (values[i].CellValue == "")
                    {
                        TargetN = i;  //если ячейка пустая - можно сделать туда ход                    
                    }

                }

                //машина также должна предусмотреть "стратегические" ходы, чтобы помешать выиграть игроку
                //и постараться выиграть самой
                //если в одной комбинации уже стоит 2 нолика, приоритетом для машины будет поставить 3-й нолик и победить
                if ((CountO == 2) && (CountX == 0))
                {
                   // Game.MachineWins = true;
                    O_canWin = true;
                    alarmTargetN = TargetN; 
                }

                //если в одной комбинации уже стоит 2 Х игрока, нужно не дать ему поставить 3-й
                if ((CountX == 2) && (CountO == 0))
                {
                    //при условии, что машина не может выиграть прямо сейчас
                    if (O_canWin == false)
                    {
                        alarmTargetN = TargetN;
                    }
                }

                //условия выигрышей в комбинации, при которых игра прекращается: 
                //если уже набралось 3 крестика в выигрышной комбинации
                if (CountX == 3)
                {
                   CongratulationsX();

                }
                //если уже набралось 3 нолика в выигрышной комбинации
                if (CountO == 3)
                {
                   CongratulationsO();
                }

            }

            // закончены проверки всех комбинаций в этом ходе.
            //теперь машина должна проверить, остались ли свободные ячейки на игровом поле
            foreach (CellModel cell in values)
            {
                if (cell.CellValue == "")
                {
                    CountNull = true; //достаточно знать, есть ли хотя бы одна свободная ячейка
                    break;
                }
            }

            //если свободных ячеек нет, но при этом ранее не было объявлено о чьей-то победе, значит, это ничья
            if ((CountNull == false)&&(O_canWin==false))
            {
                    ViewModel.BoardLocked = false;
                    CongratulationsN();    
            }

            /*если же существует экстренная цель(ей был присвоен индекс какой-либо ячейки от 0 до 8),
            то именно она становится целевой ячейкой*/
            if (alarmTargetN < 10)
            {
                TargetN = alarmTargetN;
            }
            result = "" + TargetN;          

            return result;
        }

        public void CongratulationsO()
        {
            MessageBox.Show("Победила машина. Попытайте счастья в другой раз.");
            Application.Current.Shutdown();
        }

        public void CongratulationsX()
        {
            MessageBox.Show("Примите поздравления! Вы победили машину!");
            Application.Current.Shutdown();
        }

        public void CongratulationsN()
        {
            MessageBox.Show("Ничья! Это была отличная игра!");
            Application.Current.Shutdown();
        }
    }
}
