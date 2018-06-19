using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Windows;

namespace EfCoreDeadlockTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new MyContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var b1 = new Book { Title = "b1" };
                var b2 = new Book { Title = "b1" };
                var a = new Author { Name = "a1", Books = new List<Book> { b1, b2 } };
                context.Books.AddRange(b1, b2);
                context.Authors.Add(a);
                context.SaveChanges();
            }


            dataGrid.ItemsSource = GetData();
        }

        private List<Author> GetData()
        {
            using (var context = new MyContext())
            {
                var query = context.Authors.Include(a => a.Books);

                var t = query.ToListAsync();
                t.Wait();           // Deadlock
                return t.Result;
            }
        }
    }
}
