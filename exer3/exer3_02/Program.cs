using System;
namespace exer03.e01
{
    public delegate bool DateValidationHandler(DateTime dateTime);
    public class Order
    {
        private readonly DateValidationHandler _orderDateValidator;
        private readonly DateValidationHandler _deliveryDateValidator;
        public DateTime OrderDate {get;set;}
        public DateTime DeliveryDate {get;set;}
        public Order(DateValidationHandler orderDateValidator, DateValidationHandler deliveryDateValidator){
            _orderDateValidator = orderDateValidator;
            _deliveryDateValidator = deliveryDateValidator;
        }

        public bool IsValid() => _orderDateValidator(OrderDate) && _deliveryDateValidator(DeliveryDate);
    }

    public static class Program
    {
        private static bool IsWeekendDate(DateTime date){
            Console.WriteLine(" called IsWeekendDate");
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        private static bool IsPastDate(DateTime date){
            Console.WriteLine("called IsPastDate");
            return date < DateTime.Today;
        }
        public static void Main(){
            var orderDateValidator = new DateValidationHandler(IsPastDate);
            var deliveryDateValidator = new DateValidationHandler(IsWeekendDate);
            var order = new Order(orderDateValidator, deliveryDateValidator){
                OrderDate = DateTime.Today.AddDays(-10),
                DeliveryDate = new DateTime(202, 12, 31)
            };
        Console.WriteLine($"Ordered: {order.OrderDate:dd-MMM-yy}");
        Console.WriteLine($"Delivered: {order.DeliveryDate:dd-MMM-yy}");
        Console.WriteLine($"IsValies: {order.IsValid()}");
        var futureValidator = new Func<DateTime, bool>(DateValidator.IsFuture);
        var weekendValidator = new Func<DateTime, bool>(DateValidator.IsWeekend);
        var isFuture1 = futureValidator?.Invoke(new DateTime(2000, 12, 31));
        var isFuture2 = futureValidator.Invoke(new DateTime(2000, 12, 31));
        var isFuture3 = futureValidator(new DateTime(2000, 12, 31));

        }
    }
    public static class DateValidator
    {
        public static bool IsWeekend(DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        public static bool IsFuture(DateTime dateTime) => dateTime.Date > DateTime.Today;
    }
}