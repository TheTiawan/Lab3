using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
    public class Matrix<T>
    {
        private T[,] _items;
        private int _rows, _cols;
        private BinaryFormatter _formatter = new();
        public Matrix(int rowCount, int columnCount, string extension = ".matrix")
        {
            _items = new T[rowCount, columnCount];
            Extension = extension;
        }
        public string Extension 
        {
            get;
            private set; 
        }

        public void DefaultInit()
        {
            _cols = default;
            _rows = default;
            _items = default;
        }

        public T this[int row, int col]
        {
            get 
            { 
                return _items[row,col]; 
            }
            set 
            {
                _items[row,col] = value; 
            }
        }


        public void Save(string path)
        {
            string fullPath = string.Concat(path,Extension);
            
            //Режим работы с файлом указыается - создание
            using (FileStream stream = new(fullPath, FileMode.Create))
            {
                _formatter.Serialize(stream, _items);
            }

        }

        public void Load(string path)
        {
            string fullPath = string.Concat(path, Extension);
            
            //Режим работы с файлом указыается - открытие
            using (FileStream stream = new(fullPath, FileMode.Open))
            {
                _items = _formatter.Deserialize(stream) as T[,];
            }


        }
        public int Rows => _items.GetLength(0);

        public int Columns => _items.GetLength(1);

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < Columns; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < Rows; i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < Columns; j++)
                {
                    row[j] = _items[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }

       

    }
    
}
