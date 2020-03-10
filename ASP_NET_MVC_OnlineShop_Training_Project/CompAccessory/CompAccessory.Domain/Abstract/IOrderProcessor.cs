using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompAccessory.Domain.Entites;

namespace CompAccessory.Domain.Abstract
{
    // Реализация интерфейса IOrderProcessor будет обрабатывать заказы,
    // отправляя их по электронной почте администратору сайта.
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
