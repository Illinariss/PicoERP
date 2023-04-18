using System.Windows.Controls;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace WpfPicoErp.Pages;

public partial class ListManageBase<T> : Page where T : class, new()
{
    public ObservableCollection<T> Items { get; set; }
    private DbContext _dbContext;

    public ListManageBase(DbContext dbContext, DbSet<T> items)
    {
        _dbContext = dbContext;
        Items = new ObservableCollection<T>(items);
    }

    public void AddItem(T item)
    {
        Items.Add(item);
        _dbContext.Add(item);
        _dbContext.SaveChanges();
    }

    public void RemoveItem(T item)
    {
        Items.Remove(item);
        _dbContext.Remove(item);
        _dbContext.SaveChanges();
    }
}
