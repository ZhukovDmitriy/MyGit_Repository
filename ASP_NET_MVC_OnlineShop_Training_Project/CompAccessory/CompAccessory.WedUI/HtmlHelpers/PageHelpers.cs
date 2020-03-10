using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using CompAccessory.WedUI.Models;

// [Пример 1 - делегат Func]
// int ParamSum(int x1, int x2, int x3)
// {
//    return x1 + x2 + x3;
// }

// void MyMeth(Func<int, int, int, int> myFunc, int n)   // Последний параметр Func - return типа
// {
//    int x1 = 100;
//    x1 = x1 + n;

//    int res = myFunc(x1, 50, 50);

//    Console.WriteLine(res);
//    Console.ReadKey();
// }

// MyMeth(ParamSum, 25);

// [Пример 2 - делегат Func]
// Func<string, string> myF;
// myF = Hello;

// string Hello(string str)
// {
//    return str + "Hello";
// }

// Console.WriteLine(myF(" World!"));
// Console.ReadKey();

namespace CompAccessory.WedUI.HtmlHelpers
{
    public static class PageHelpers
    {
        // Метод расширения - метод который расширяет функциональность уже существующих классов и типов
        // а эти классы указываются в качестве первого параметра метода (объект HtmlHelper html)
        // ключевое слово this сообщает компилятору что определяется расширяющий метод
        // Метод расширения PageLinks генерирует HTML-разметку для набора ссылок на старницы 
        // с использованием информации, предоставленном в объекте PageInfo
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {   
            // Параметр Func обеспечивает возможность передачи делегата, 
            // который будет применятся для генерации ссылок, обеспечивающих просмотр других страниц
            // Делегат Func<T> позволяет вызывать методы с типом возврата
            // Метод PageLinks принимает в качестве параметра делегат Func<int, string> pageUrl, 
            // с двумя параметрами, первый из которых принимает значение int, а второй возвращает строку string

            StringBuilder result = new StringBuilder();     // Класс StringBuilder представляет динамическую строку 
                                                            // StringBuilder используется когда необходимо сделать много операций над строками    
                                                            // так как при изменении строки система НЕ создает новый объект в памяти 
                                                            // в отличае от объектов String представляющую собой неизменную строку

            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");       // Конструируем дескриптор <a>
                                                            // TagBuilder позволяет объединять атрибуты в теге. Это класс удобства
                                                            // он хранит словарь ваших атрибутов тега, а затем выводит HTML все сразу.

                tag.MergeAttribute("href", pageUrl(i));     // Свойство MergeAttribute (string, string, bool) позволяет добавить к элементу один атрибут
                tag.InnerHtml = i.ToString();               // Метод InnerHtml позволяет установить или получить содержимое тега в виде строки

                if (i == pageInfo.CurrentPage)
                    tag.AddCssClass("selected");            // Метод AddCssClass(string) добавляет класс css к элементу
                result.Append(tag.ToString());              // Метод Append() добавляет строку к текущей строке
            }

            return MvcHtmlString.Create(result.ToString()); // Метод Create() создает строку в кодировке HTML
        }

        // [Пример] Метод расширения для типа string
        // string str = "Hello World";
        // char ch = "l";
        // int i = str.WordCount(ch);       // У всех строк мы можем вызвать данный метод, без указания первого параметра
        // Console.WriteLine(i);
        // public static class StringExtention {
        // public static int WordCount(this string s, char c)   
        // { ... подсчет количества определенных символов в строке ... } };
    }
}