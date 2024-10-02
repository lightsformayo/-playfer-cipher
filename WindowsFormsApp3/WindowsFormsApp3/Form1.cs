using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class PlayfairCode : Form
    {
        // размеры матрицы для шифрования
        private int _matrixRows;
        private int _matrixCols;
        // матрица для шифрования
        private Char[,] _matrix;
        // язык кодировки
        private const string EngAphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string RusAphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string _workAphabet;

        /// Конструктор класса основной формы
        public PlayfairCode()
        {
            InitializeComponent();
            _matrixRows = 5;
            _matrixCols = 5;
            _workAphabet = EngAphabet;
            _matrix = new Char[_matrixRows, _matrixCols];
            lvMatrix.VirtualListSize = _matrixRows;
            ClearMatrix();
        }
        private void PlayfairCodeForm_Load(object sender, EventArgs e)
        {
        }
        // private string PlayfairEncode(string keyword, string sourcetext) {}
        private string PlayfairEncode(string keyword, string sourcetext)
        {
            // получим рабочее ключевое слово
            var workKey = GetWorkKey(keyword);
            // заполним матрицу шифрования
            FillMatrix(workKey);
            var exsymb = radioButton1.Checked ? 'J' : 'Ъ';
            var exsymbdo = radioButton2.Checked ? 'I' : 'Ь';
            // делается замена символов для сокращения алфавита, в зависимости от языка
            // получим список биграмм из текста-источника
            var bigrammas = GetBigramma(sourcetext.ToUpper().Replace(exsymb, exsymbdo));
            // посмотрим как выглядят получившиеся биграммы исходного текста
            var enumerable = bigrammas as string[] ?? bigrammas.ToArray();
            textBoxBigramma.Text = string.Join("", enumerable);
            // создадим список для зашифрованных биграмм
            var codedbigrammas = new List<string>();
            // кодируем биграммы по порядку
            foreach (var bigramma in enumerable)
            {
                // переменная для кодированной биграммы
                string coded;
                // встречаются ли символы биграммы в одной строке матрицы?
                if (BigrammaInOneRow(bigramma, out coded))
                {
                    // добавим зашифрованную биграмму в список
                    codedbigrammas.Add(coded);
                }
                // встречаются ли символы биграммы в одном столбце матрицы?
                else if (BigrammaInOneColumn(bigramma, out coded))
                {
                    // добавим зашифрованную биграмму в список
                    codedbigrammas.Add(coded);
                }
                // встречаются ли символы биграммы в разных строках и столбцах матрицы?
                else if (BigrammaInOthers(bigramma, out coded))
                {
                    // добавим зашифрованную биграмму в список
                    codedbigrammas.Add(coded);
                }
            }
            // вернем зашифрованный текст, склеив кодированные биграммы
            return string.Join("", codedbigrammas);
        }

        #region Вспомогательные функции для шифрования

        /// <summary>
        /// Ищем символ в матрице кодирования
        /// </summary>
        /// <param name="symbol">символ для поиска</param>
        /// <param name="foundRow">найденный индекс строки</param>
        /// <param name="foundCol">найденный индекс столбца</param>
        /// <returns>возвращяет истину, если символ найден</returns>
        private bool GetCoordinates(char symbol, out int foundRow, out int foundCol)
        {
            // проходим по строкам матрицы
            for (var row = 0; row < _matrixRows; row++)
            {
                // проходим по столбцам матрицы
                for (var col = 0; col < _matrixCols; col++)
                {
                    if (_matrix[row, col] != symbol) continue;
                    // символ найден
                    foundRow = row;
                    foundCol = col;
                    return true;
                }
            }
            // символ не найден
            foundRow = -1;
            foundCol = -1;
            return false;
        }

        /// <summary>
        /// Ищем символы в одной строке
        /// </summary>
        /// <param name="bigramma">биграмма с символами</param>
        /// <param name="coded">возвращаемая кодированная биграмма</param>
        /// <returns>возвращает истину, если символы были в одной строке</returns>
        private bool BigrammaInOneRow(string bigramma, out string coded)
        {
            // здесь переменные для поиска
            int row1, col1;
            int row2, col2;
            // переменная для зашифрованной биграммы
            coded = "";
            // пытаемся получить строку и столбец первого символа
            if (!GetCoordinates(bigramma[0], out row1, out col1)) return false;
            // пытаемся получить строку и столбец второго символа
            if (!GetCoordinates(bigramma[1], out row2, out col2)) return false;
            // если строки не равны, то выходим с отрицательныи результатом
            if (row1 != row2) return false;
            // берем символ следующего столбца, если он не крайний справа
            if (col1 < _matrixCols - 1)
                coded += _matrix[row1, col1 + 1];
            else
                // иначе берем символ самого первого столбца
                coded += _matrix[row1, 0];
            // берем символ следующего столбца, если он не крайний справа
            if (col2 < _matrixCols - 1)
                coded += _matrix[row2, col2 + 1];
            else
                // иначе берем символ самого первого столбца
                coded += _matrix[row2, 0];
            // возвращаем успех и закодированную биграмму в переменной coded
            return true;
        }

        /// <summary>
        /// Ищем символы в одном столбце
        /// </summary>
        /// <param name="bigramma">биграмма с символами</param>
        /// <param name="coded">возвращаемая кодированная биграмма</param>
        /// <returns>возвращает истину, если символы были в одном столбце</returns>
        private bool BigrammaInOneColumn(string bigramma, out string coded)
        {
            // здесь переменные для поиска
            int row1, col1;
            int row2, col2;
            // переменная для зашифрованной биграммы
            coded = "";
            // пытаемся получить строку и столбец первого символа
            if (!GetCoordinates(bigramma[0], out row1, out col1)) return false;
            // пытаемся получить строку и столбец второго символа
            if (!GetCoordinates(bigramma[1], out row2, out col2)) return false;
            // если столбцы не равны, то выходим с отрицательныи результатом
            if (col1 != col2) return false;
            // берем символ следующей строки, если она не крайняя снизу
            if (row1 < _matrixRows - 1)
                coded += _matrix[row1 + 1, col1];
            else
                // иначе берем символ самой первой строки
                coded += _matrix[0, col1];
            // берем символ следующей строки, если она не крайняя снизу
            if (row2 < _matrixRows - 1)
                coded += _matrix[row2 + 1, col2];
            else
                // иначе берем символ самой первой строки
                coded += _matrix[0, col2];
            // возвращаем успех и закодированную биграмму в переменной coded
            return true;
        }

        /// <summary>
        /// Меняем значения в столбцах, если символы из разных строк и столбцов
        /// </summary>
        /// <param name="bigramma">биграмма с символами</param>
        /// <param name="coded">возвращаемая кодированная биграмма</param>
        /// <returns>возвращает истину, если символы в разных строках и столбцах</returns>
        private bool BigrammaInOthers(string bigramma, out string coded)
        {
            // здесь переменные для поиска
            int row1, col1;
            int row2, col2;
            // переменная для зашифрованной биграммы
            coded = "";
            // пытаемся получить строку и столбец первого символа
            if (!GetCoordinates(bigramma[0], out row1, out col1)) return false;
            // пытаемся получить строку и столбец второго символа
            if (!GetCoordinates(bigramma[1], out row2, out col2)) return false;
            // если строки равны или столбцы равны, то выходим с отрицательныи результатом
            if (row1 == row2 || col1 == col2) return false;
            // строка остается, а столбец меняется
            coded += _matrix[row1, col2];
            // строка остается, а столбец меняется
            coded += _matrix[row2, col1];
            // возвращаем успех и закодированную биграмму в переменной coded
            return true;
        }

        /// <summary>
        /// Берем текст и разбиваем его на биграммы
        /// </summary>
        /// <param name="text">исходный текст</param>
        /// <returns>перечисление с биграммами</returns>
        private IEnumerable<string> GetBigramma(string text)
        {
            // создадим вспомогательный объект очереди
            var list = new List<Char>();
            // поместим все допустимые символы для этого алфавита из текста в очередь
            // пробелы и другие знаки, не вхоодящие в алфавит, в очередь не попадут
            foreach (var symbol in text.Where(symbol => _workAphabet.IndexOf(char.ToUpper(symbol)) >= 0))
            {
                // символы преобразуем к верхнему регистру и добавляем в начало очереди
                list.Insert(0, char.ToUpper(symbol));
            }
            // создадим вспомогательный объект стека
            var stack = new Stack<Char>();
            // поместим все символы из очереди в стек, так как очередь заполнялась с головы,
            // то при помещении в стек его крайним элементом будет начальный символ текста
            foreach (var symbol in list)
                stack.Push(symbol);
            var bigramms = new List<string>();
            var item = "";  // здесь будем хранить очередную биграмму
            var exsymb = radioButton1.Checked ? 'X' : 'Я';
            // выбираем из стека все символы по очереди
            while (stack.Count > 0)
            {
                // получаем "верхний" символ стека
                var symbol = stack.Pop();
                // если биграмма еще не наполнена
                if (item.Length < 2)
                {
                    // и добавляемый к биграмме символ не дублируется
                    if (item.IndexOf(symbol) < 0)
                        item += symbol;     // то добавляем символ к биграмме
                    else
                    {
                        stack.Push(symbol); // иначе помещаем символ обратно в стек
                        item += exsymb;        // вместо дубля добавляем символ X
                    }
                }
                // если биграмма еще не содержит два символа,
                // то продолжаем извлекать символы из стека
                if (item.Length != 2) continue;
                // биграмма укомплектована, добавляем ее в список биграмм
                bigramms.Add(item);
                // текущую биграмму очищаем для нового заполнения
                item = "";
            }
            // для случая, когда символов для биграммы не хватило, добавляем символ X
            if (item.Length == 1)
            {
                item += exsymb;
                bigramms.Add(item);
            }
            // возвращаем список биграмм
            return bigramms;
        }

        #endregion вспомогательные функции для шифрования

        /// <summary>
        /// Общая функция расшифровки текста, закодированного шифром Плейфера
        /// </summary>
        /// <param name="keyword">ключевое слово</param>
        /// <param name="sourcetext">текст на расшифровку</param>
        /// <returns></returns>
        private string PlayfairDecode(string keyword, string sourcetext)
        {
            var workKey = GetWorkKey(keyword);
            FillMatrix(workKey);
            // получим список биграмм из текста, закодированного шифром Плейфера
            var bigrammas = GetCodedBigramma(sourcetext);
            // посмотрим как выглядят получившиеся биграммы зашифрованного текста
            var enumerable = bigrammas as string[] ?? bigrammas.ToArray();
            // создадим список для зашифрованных биграмм
            var encodedbigrammas = new List<string>();
            // кодируем биграммы по порядку
            foreach (var bigramma in enumerable)
            {
                // переменная для кодированной биграммы
                string encoded;
                // встречаются ли символы биграммы в одной строке матрицы?
                if (BigrammaFromOneRow(bigramma, out encoded))
                {
                    // добавим зашифрованную биграмму в список
                    encodedbigrammas.Add(encoded);
                }
                // встречаются ли символы биграммы в одном столбце матрицы?
                else if (BigrammaFromOneColumn(bigramma, out encoded))
                {
                    // добавим зашифрованную биграмму в список
                    encodedbigrammas.Add(encoded);
                }
                // встречаются ли символы биграммы в разных строках и столбцах матрицы?
                else if (BigrammaFromOthers(bigramma, out encoded))
                {
                    // добавим зашифрованную биграмму в список
                    encodedbigrammas.Add(encoded);
                }
            }
            // вернем зашифрованный текст, склеив кодированные биграммы
            return string.Join("", encodedbigrammas);
        }

        #region Вспомогательные функции для дешифрования

        /// <summary>
        /// Ищем символы в одной строке
        /// </summary>
        /// <param name="bigramma">биграмма с символами</param>
        /// <param name="decoded">возвращаемая раскодированная биграмма</param>
        /// <returns>возвращает истину, если символы были в одной строке</returns>
        private bool BigrammaFromOneRow(string bigramma, out string decoded)
        {
            // здесь переменные для поиска
            int row1, col1;
            int row2, col2;
            // переменная для расшифрованной биграммы
            decoded = "";
            // пытаемся получить строку и столбец первого символа
            if (!GetCoordinates(bigramma[0], out row1, out col1)) return false;
            // пытаемся получить строку и столбец второго символа
            if (!GetCoordinates(bigramma[1], out row2, out col2)) return false;
            // если строки не равны, то выходим с отрицательныи результатом
            if (row1 != row2) return false;
            // берем символ предыдущего столбца, если он не крайний слева
            if (col1 > 0)
                decoded += _matrix[row1, col1 - 1];
            else
                // иначе берем символ самого правого столбца
                decoded += _matrix[row1, _matrixCols - 1];
            // берем символ предыдущего столбца, если он не крайний слева
            if (col2 > 0)
                decoded += _matrix[row2, col2 - 1];
            else
                // иначе берем символ самого правого столбца
                decoded += _matrix[row2, _matrixCols - 1];
            // возвращаем успех и раскодированную биграмму в переменной decoded
            return true;
        }

        /// <summary>
        /// Ищем символы в одном столбце
        /// </summary>
        /// <param name="bigramma">биграмма с символами</param>
        /// <param name="decoded">возвращаемая раскодированная биграмма</param>
        /// <returns>возвращает истину, если символы были в одном столбце</returns>
        private bool BigrammaFromOneColumn(string bigramma, out string decoded)
        {
            // здесь переменные для поиска
            int row1, col1;
            int row2, col2;
            // переменная для расшифрованной биграммы
            decoded = "";
            // пытаемся получить строку и столбец первого символа
            if (!GetCoordinates(bigramma[0], out row1, out col1)) return false;
            // пытаемся получить строку и столбец второго символа
            if (!GetCoordinates(bigramma[1], out row2, out col2)) return false;
            // если столбцы не равны, то выходим с отрицательныи результатом
            if (col1 != col2) return false;
            // берем символ предыдущей строки, если она не крайняя сверху
            if (row1 > 0)
                decoded += _matrix[row1 - 1, col1];
            else
                // иначе берем символ самой последней строки
                decoded += _matrix[_matrixRows - 1, col1];
            // берем символ предыдущей строки, если она не крайняя сверху
            if (row2 > 0)
                decoded += _matrix[row2 - 1, col2];
            else
                // иначе берем символ самой последней строки
                decoded += _matrix[_matrixRows - 1, col2];
            // возвращаем успех и раскодированную биграмму в переменной decoded
            return true;
        }

        /// <summary>
        /// Меняем значения в столбцах, если символы из разных строк и столбцов
        /// </summary>
        /// <param name="bigramma">биграмма с символами</param>
        /// <param name="decoded">возвращаемая раскодированная биграмма</param>
        /// <returns>возвращает истину, если символы в разных строках и столбцах</returns>
        private bool BigrammaFromOthers(string bigramma, out string decoded)
        {
            // здесь переменные для поиска
            int row1, col1;
            int row2, col2;
            // переменная для зашифрованной биграммы
            decoded = "";
            // пытаемся получить строку и столбец первого символа
            if (!GetCoordinates(bigramma[0], out row1, out col1)) return false;
            // пытаемся получить строку и столбец второго символа
            if (!GetCoordinates(bigramma[1], out row2, out col2)) return false;
            // если строки равны или столбцы равны, то выходим с отрицательныи результатом
            if (row1 == row2 || col1 == col2) return false;
            // строка остается, а столбец меняется
            decoded += _matrix[row1, col2];
            // строка остается, а столбец меняется
            decoded += _matrix[row2, col1];
            // возвращаем успех и закодированную биграмму в переменной decoded
            return true;
        }

        private IEnumerable<string> GetCodedBigramma(string text)
        {
            // создадим вспомогательный объект очереди
            var list = new List<Char>();
            // поместим все допустимые символы для этого алфавита из текста в очередь
            // пробелы и другие знаки, не вхоодящие в алфавит, в очередь не попадут
            foreach (var symbol in text.Where(symbol => _workAphabet.IndexOf(char.ToUpper(symbol)) >= 0))
            {
                // символы преобразуем к верхнему регистру и добавляем в начало очереди
                list.Insert(0, char.ToUpper(symbol));
            }
            // создадим вспомогательный объект стека
            var stack = new Stack<Char>();
            // поместим все символы из очереди в стек, так как очередь заполнялась с головы,
            // то при помещении в стек его крайним элементом будет начальный символ текста
            foreach (var symbol in list)
                stack.Push(symbol);
            var bigramms = new List<string>();
            var item = "";  // здесь будем хранить очередную биграмму
            // выбираем из стека все символы по очереди
            while (stack.Count > 0)
            {
                // получаем "верхний" символ стека
                var symbol = stack.Pop();
                // если биграмма еще не наполнена
                if (item.Length < 2)
                    item += symbol; // то добавляем символ к биграмме
                // если биграмма еще не содержит два символа,
                // то продолжаем извлекать символы из стека
                if (item.Length != 2) continue;
                // биграмма укомплектована, добавляем ее в список биграмм
                bigramms.Add(item);
                // текущую биграмму очищаем для нового заполнения
                item = "";
            }
            // для случая, когда символов для биграммы не хватило, добавляем символ X
            if (item.Length == 1)
            {
                var exsymb = radioButton1.Checked ? 'X' : 'Я';
                item += exsymb;
                bigramms.Add(item);
            }
            // возвращаем список биграмм
            return bigramms;
        }

        #endregion вспомогательные функции для дешифрования

        /// Заполнение матрицы сначала рабочим ключевым словом,
        /// а потом буквами алфавита, не встречающимися в ключевом слове
        private void FillMatrix(string workKey)
        {
            // создадим вспомогательный объект очереди
            var queue = new Queue<Char>();
            // поместим в очередь все символы рабочего ключевого слова
            foreach (var symbol in workKey)
                queue.Enqueue(symbol);
            // затем поместим в очередь символы из строки алфавита, кроме буквы J
            // и которые не встречаются в рабочем ключевом слове
            var exsymb = radioButton1.Checked ? 'J' : 'Ъ';
            foreach (var abc in _workAphabet.Where(abc => workKey.IndexOf(abc) < 0 && abc != exsymb))
                queue.Enqueue(abc);
            // проходим по строкам матрицы
            for (var row = 0; row < _matrixRows; row++)
            {
                // проходим по столбцам матрицы
                for (var col = 0; col < _matrixCols; col++)
                    // заполняем ячейку матрицы следующим символом из очереди
                    _matrix[row, col] = queue.Dequeue();
            }
            // обновим визуальное представление матрицы
            lvMatrix.Invalidate();
        }
        /// Получаем рабочее ключевое слово, без повторяющихся символов
        private string GetWorkKey(string keyword)
        {
            // создадим вспомогательный объект буфера для строки
            var result = new StringBuilder();
            var exsymb = radioButton1.Checked ? 'J' : 'Ъ';
            var exsymbdo = radioButton1.Checked ? 'I' : 'Ь';
            // для всех символов ключевого слова, которые еще не были добавлены
            // делается замена символов для сокращения алфавита, в зависимости от языка
            // пробелы также удаляются
            foreach (var keyChar in keyword.ToUpper()
                    .Replace(exsymb, exsymbdo)
                    .Where(keyChar => keyChar != ' ')
                    .Where(keyChar => result.ToString().IndexOf(keyChar) < 0))
                result.Append(keyChar);     // добавляем этот символ
            return result.ToString();       // преобразуем буфер в строку и отдаем
        }

        private void ClearMatrix()
        {
            for (var row = 0; row < _matrixRows; row++)
            {
                for (var col = 0; col < _matrixCols; col++)
                {
                    _matrix[row, col] = ' ';
                }
            }
            lvMatrix.Invalidate();
        }
        
        private void сохранитьТекстВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine("Кодовое слово: " + textBoxKeyword.Text + "\n"+ "Исходный текст: " + textBoxSource.Text + "\n" + "Зашифрованный текст: " + textBoxBigramma.Text);
                streamWriter.Close();
            }

        }

        private void открытьФайлДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string FileName = openFileDialog1.FileName;
            string FileText = System.IO.File.ReadAllText(FileName);
            textBoxSource.Text = FileText;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // отключаем размер визуализации
            lvMatrix.VirtualListSize = 0;
            // устанавливаем размер матрицы 5х5
            _matrixRows = 5;
            _matrixCols = 5;
            // удаляем старые столбцы на визуализации
            lvMatrix.Columns.Clear();
            // добавляем столбцы согласно новому размеру
            for (var i = 0; i < _matrixCols; i++)
            {
                var ch = new ColumnHeader { Width = 30 };
                lvMatrix.Columns.Add(ch);
            }
            // устанавливаем рабочий алфавит
            _workAphabet = EngAphabet;
            // создаем новую рабочую матрицу
            _matrix = new Char[_matrixRows, _matrixCols];
            // инициализируем её
            ClearMatrix();
            // задаем новый размер визуализации
            lvMatrix.VirtualListSize = _matrixRows;
            // очищаем входные и расчетные поля
            textBoxBigramma.Clear();
            textBoxKeyword.Clear();
            textBoxSource.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // отключаем размер визуализации
            lvMatrix.VirtualListSize = 0;
            // устанавливаем размер матрицы 8х4
            _matrixRows = 8;
            _matrixCols = 4;
            // удаляем старые столбцы на визуализации
            lvMatrix.Columns.Clear();
            // добавляем столбцы согласно новому размеру
            for (var i = 0; i < _matrixCols; i++)
            {
                var ch = new ColumnHeader { Width = 30 };
                lvMatrix.Columns.Add(ch);
            }
            // устанавливаем рабочий алфавит
            _workAphabet = RusAphabet;
            // создаем новую рабочую матрицу
            _matrix = new Char[_matrixRows, _matrixCols];
            // инициализируем её
            ClearMatrix();
            // задаем новый размер визуализации
            lvMatrix.VirtualListSize = _matrixRows;
            // очищаем входные и расчетные поля
            textBoxBigramma.Clear();
            textBoxKeyword.Clear();
            textBoxSource.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //поменяем значение label для зашифрования текста
            label4.Text = "Зашифрованный текст";
            // зашифруем текст шифром Плейфера
            var encoded = PlayfairEncode(textBoxKeyword.Text, textBoxSource.Text);
            // и посмотрим, что получилось
            textBoxBigramma.Text = encoded;
        }

        private void lvMatrix_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var lvi = new ListViewItem();
            // получаем провайдер для преобразования символа в строку
            var formatProvider = CultureInfo.GetCultureInfo("en-US");
            // заполняем виртуальный список
            lvi.Text = _matrix[e.ItemIndex, 0].ToString(formatProvider);
            // создаем дополнительные столбцы в цикле
            for (var col = 1; col < _matrixCols; col++)
            {
                lvi.SubItems.Add(_matrix[e.ItemIndex, col].ToString(formatProvider));
            }
            // возвращаем элемент для отображения
            e.Item = lvi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //поменяем значение label для расшифровки текста
            label4.Text = "Расшифрованный текст";
            // расшифруем текст, закодированный шифром Плейфера
            var decoded = PlayfairDecode(textBoxKeyword.Text, textBoxSource.Text);
            // и посмотрим, что получилось
            textBoxBigramma.Text = decoded;
        }

        //private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBoxBigramma.Text);
                streamWriter.Close();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBoxKeyword.Text);
                streamWriter.Close();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBoxKeyword.Text = fileText;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

