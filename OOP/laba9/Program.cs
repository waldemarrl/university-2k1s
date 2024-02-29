using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Concurrent;

namespace laba9
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<string, int> sorted = new (5);
            sorted.Add("one", 1);
            sorted.Add("two", 2);
            
            Console.WriteLine(sorted["two"]);

            Product product = new("Milk", "20");
            Product product1 = new("Bread", "50");
            Product product2 = new("Button", "40");

            Console.WriteLine("--------------------------------------------------------------\n\n\n");

            ConcurrentBag<Product, int> concurrentBag = new(3);
            concurrentBag.Add(product, 200);
            concurrentBag.Add(product1, 300);
            concurrentBag.Add(product2, 500);

            Console.WriteLine(concurrentBag[product1]);

            Console.WriteLine("--------------------------------------------------------------\n\n\n");
            ObservableCollection<Product> observableCollection = new();
            observableCollection.CollectionChanged += CollectionChange;
            observableCollection.Add(product);
            observableCollection.Add(product1);
            observableCollection.Add(product2);
            observableCollection.Remove(product);
            static void CollectionChange(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine("Add");
                        break;
                }
            }
        }
    }
}
