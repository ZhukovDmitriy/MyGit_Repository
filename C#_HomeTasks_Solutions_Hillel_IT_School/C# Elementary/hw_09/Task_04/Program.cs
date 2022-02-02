using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;    // Содержит типы, разрешающие создание и использование изолированных хранилищ.
using System.IO;

/* Создайте приложение WPF Application,
 * позволяющее пользователям сохранять данные в изолированное хранилище.
 */
namespace Task_04
{
    class IsolatedStorage
    {
        IsolatedStorageFile userStorage;        // Предоставляет область изолированного хранилища, в которой содержатся файлы и каталоги.
        IsolatedStorageFileStream userStream;   // Представляет файл в изолированном хранилище.

        public void CreateStorage()
        {
            // Создание изолированного хранилища уровня  .Net сборки.
            userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Проверить существование директории.
            string[] directories = userStorage.GetDirectoryNames("UserData");

            if (directories.Length == 0)
            {
                userStorage.CreateDirectory("UserData"); // Создаем папку.
            }

            // Создание файлового потока с указанием: Директории и Имени файла, FileMode, объекта хранилища.
            userStream = new IsolatedStorageFileStream(@"UserData\text.txt", FileMode.Create, userStorage);
        }

        public void WriteToStorage(string data)
        {
            // StreamWriter - запись данных в поток userStream.
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine(data);
            userWriter.Close();
        }

        public void ReadFromStorage()
        {
            // Прочитать данные из потока.
            userStream = new IsolatedStorageFileStream(@"UserData\text.txt", FileMode.Open, userStorage);

            StreamReader userReader = new StreamReader(userStream);
            string contents = userReader.ReadToEnd();
            Console.WriteLine(contents);

            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string userData = "myData";             // Данные пользователя

            IsolatedStorage isoStorage = new IsolatedStorage();

            isoStorage.CreateStorage();
            isoStorage.WriteToStorage(userData);
            isoStorage.ReadFromStorage();
        }
    }
}