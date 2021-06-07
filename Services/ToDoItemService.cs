using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public class ToDoItemService
    {
        static List<ToDoItem> ToDoItems;

        static int nextId = 3;

        static ToDoItemService()
        {
            ToDoItems = new List<ToDoItem>
            {
                new ToDoItem {Id= 1, Name="Start session", IsCompleted= false},
                new ToDoItem {Id= 2, Name="Start introduction", IsCompleted= false}
            };
        }

        public static List<ToDoItem> GetAll() => ToDoItems;

        public static ToDoItem Get(int id) => ToDoItems.FirstOrDefault(i => i.Id == id);

        public static void Add(ToDoItem item)
        {
            item.Id = nextId++;
            ToDoItems.Add(item);
        }

        public static void Update(ToDoItem item)
        {
            var index = ToDoItems.FindIndex(i => i.Id == item.Id);
            if (index == -1)
                return;

            ToDoItems[index] = item;
        }

        public static void Delete(int id)
        {
            //ToDoItems.Add(item);
            var item = Get(id);
            if (item is null)
                return;

            ToDoItems.Remove(item);
        }
    }
}
