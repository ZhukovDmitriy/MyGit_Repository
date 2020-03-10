using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Создать класс Book. 
 * Создать классы Title, Author и Content,
 * каждый из которых должен содержать одно строковое поле и метод void Show().
 * Реализуйте возможность добавления в книгу названия книги, имени автора и содержания.
 * Выведите на экран разными цветами при помощи метода Show() название книги, имя автора и содержание.
 */
namespace Task_05
{
    class Book // Книга
    {                                                       // Добавляем другие классы в класс Book как обьекты этого класса
        private Title titleOfBook = null;                   // Заглавие
        private Author authorOfBook = null;                 // Автор 
        private Content contentOfBook = null;               // Содержание

        public Book(string titleBook, string authorBook, string contentBook)
        {
            Inicializar(titleBook, authorBook, contentBook);
        }

        private void Inicializar(string titleBook, string authorBook, string contentBook)
        {
            titleOfBook = new Title(titleBook);
            authorOfBook = new Author(authorBook);
            contentOfBook = new Content(contentBook);
        }

        public void Show()
        {
            titleOfBook.Show();
            authorOfBook.Show();
            contentOfBook.Show();
        }
    }

    class Title // Заглавие
    {
        private string titleBook = string.Empty;

        public string TitleBook { get => titleBook; }

        public Title(string title)
        {
            titleBook = title;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(TitleBook);
        }
    }

    class Author // Автор
    {
        private string authorBook = string.Empty;

        public string AuthorBook { get => authorBook; }

        public Author(string author)
        {
            authorBook = author;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(AuthorBook);
        }
    }

    class Content // Содержание
    {
        private string contentBook = string.Empty;

        public string ContentBook { get => contentBook; }

        public Content(string content)
        {
            contentBook = content;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ContentBook);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Снимаю Шляпу", "Михаил Боярский", "Секрет квантовой сингулярности");
            Book book2 = new Book("Пикап Мастер", "Твой Тренер", "Как подкатить на дырявом");
            Book book3 = new Book("Удар смерти", "Хаттори Ханзо", "Пять касаний, разрывающих сердце");

            book1.Show();
            book2.Show();
            book3.Show();

            Console.ReadKey();
        }
    }
}
