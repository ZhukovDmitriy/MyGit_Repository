using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompAccessory.Domain.Entites
{
    public class CartLine       // Класс представляет товар выбранный пользователем и его количество
    {
        // Определяем экземпляр класса Accessory - модели предметной области, для доступа к переменным этого класса
        public Accessory Accessory { get; set; }
        // Определяем переменную экземпляра класса CartLine, содержащую количество товаров
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();   // Создаем список для объектов класса CartLine

        // Определяем свойство Lines, интерфейса IEnumerable<CartLine>, обеспечивающее доступ к списку lineCollection
        // IEnumerable - предоставляет перечеслитель, поддерживающий перебор элементов указанной коллекции
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(Accessory accessory, int quantity)  // Метод добавления элемента в корзину
        {
            // Определяем ссылку на объект line класса CartLine, 
            // который будет служить в качестве "определителя" на наличие в коллекции объектов.
            // Метод Where фильтрует коллекцию на наличие в ней объекта, свойство AccessoryID которого
            // совпадает с указынным свойством AccessoryID объекта передаваемого методу как аргумент.
            // Если коллекция пуста, то метод FirstOrDefault возвращает null и CartLine line = null 
            // FirstOrDefault возвращает первый элемент, найденный во входной последовательности. 
            // Если последовательность пуста, возвращается default или null.
            // Далее, если условие if = true, то в коллекцию lineColletion добавляется новый объект, 
            // свойствам которого будут присвоенны параметры accessory и quantity 
            // Если-же метод Where фильтруя коллекцию находит объект свойства которого совпадают с заданными, 
            // то метод FirstOfDefault возвращает и присваевает объекту CartLine line данный объект и следовательно
            // if = false. Далее просто увеличевается свойство Quantity данного объекта
            CartLine line = lineCollection
                .Where(p => p.Accessory.AccessoryID == accessory.AccessoryID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Accessory = accessory,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Accessory accessory)     // Метод удаления элемента из корзины (полностью всего количества)
        {
            // RemoveAll - удаляет все элементы удовлетворяющие условиям указанного предиката
            lineCollection.RemoveAll(l => l.Accessory.AccessoryID == accessory.AccessoryID);
        }

        public decimal ComputeTotalValue()              // Метод вычисления общей стоимости элементов корзины
        {
            return lineCollection.Sum(e => e.Accessory.Price * e.Quantity);
        }

        public void Clear()                             // Метод очистки всех элементов в корзине
        {
            lineCollection.Clear();                     // Clear удаляет все элементы из коллекции
        }
    }
}
