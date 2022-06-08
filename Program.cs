using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Dictionary[] dictionaries =
{
    new Dictionary("key1", "value1"),
    new Dictionary("key1", "value2"),
    new Dictionary("key2", "value3"),
    new Dictionary("key3", "value1"),
    new Dictionary("key2", "value2"),
};

             var values = from dictionary in dictionaries
             group dictionary by dictionary.Value into d
             select new
             {
                 Name = d.Key,
                 Group = from p in d select p
             };


Console.WriteLine("однаковi ключi з пари ключ-значення:");
foreach (var value in values)
{
    Console.WriteLine($"{value.Name}:");
    foreach (var gr in value.Group)
    {
        Console.WriteLine(gr.Key);
    }
    Console.WriteLine(); // для разделения компаний
}

          var keys = from dictionary in dictionaries
          group dictionary by dictionary.Key into d
          select new
          { Name = d.Key, Group = from p in d select p };


Console.WriteLine("однаковi значення з пари ключ-значення:");
foreach (var key in keys)
{
    Console.WriteLine($"{key.Name}:");
    foreach(var gr in key.Group)
    { 
        Console.WriteLine(gr.Value); 
    }
    Console.WriteLine();
}

Dictionary dc = new Dictionary();
dc.Serealize(dictionaries);

class Dictionary
{
    public string Key { get; set; }
    public string Value { get; set; }

    public Dictionary(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public Dictionary()
    {
    }

    public void Serealize(Dictionary[] dictionaries1)
    {
        string jsonString = JsonConvert.SerializeObject(dictionaries1);
        Console.WriteLine(jsonString);
        File.WriteAllText("D:/1курс_2семестр/Програмування-2/LAB_3/3.2_new/3.2_new/tojson.json", jsonString);
    }
}


