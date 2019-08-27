using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region Todos
        // Create
        public static void TodoCreate()
        {
            Debug.Print("--- TodosCreate ---");
            // KlasseA
            Data.Todos todo1 = new Data.Todos();
            todo1.Description = "Artikel 1";
            todo1.ExpiryDate = DateTime.Today;
            Int64 todo1Id = todo1.Create();
            Debug.Print("Artikel erstellt mit Id:" + todo1Id);
        }
        public static void TodoCreateShort()
        {
            Data.Todos todo2 = new Data.Todos { Description = "Artikel 2", Done = true, ExpiryDate = DateTime.Today, Colour = 2, Priority = 3 };
            Int64 todo2Id = todo2.Create();
            Debug.Print("Artikel erstellt mit Id:" + todo2Id);
        }

        // Read
        public static void TodoRead()
        {
            Debug.Print("--- TodoRead ---");
            // Demo liest alle
            foreach (Data.Todos todo in Data.Todos.ReadAll())
            {
                Debug.Print("Artikel Id:" + todo.TodoId + " Name:" + todo.Description);
            }
        }
        // Update
        public static void TodoUpdate()
        {
            Debug.Print("--- TodoUpdate ---");
            // KlasseA ändert Attribute
            Data.Todos todo = Data.Todos.ReadId(1);
            todo.Description = "Artikel 1 nach Update";
            todo.Update();
        }
        // Delete
        public static void TodoDelete()
        {
            Debug.Print("--- TodoDelete ---");
            Data.Todos.ReadId(2).Delete();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
