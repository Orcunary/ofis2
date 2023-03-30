using Java.Sql;
using Java.Util;
using SQLite;
using System;

namespace ofis.Data;

public class Tahsilatlar
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Unvan { get; set; }
    public DateTime Tarih { get; set; }
    public bool Tur { get; set; }
    public Double Tutar   { get; set; }   
}