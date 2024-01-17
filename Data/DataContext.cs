using Microsoft.EntityFrameworkCore;
using SuperHeroes.Models;
using System;


namespace SuperHeroes.Data;
public class DataContext : DbContext
{
    public string DbPath { get; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "SuperHeroes.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    public DbSet<SuperHeros> SuperHeroes { get; set; }
}
