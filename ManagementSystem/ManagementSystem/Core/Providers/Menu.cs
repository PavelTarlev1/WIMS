using ManagementSystem.Core.Contracts;
using System;
using System.Collections.Generic;


namespace ManagementSystem.Core.Providers
{

    public class Menu : IMenu
    {
        public static int index = 0;

        public string DrawMenu(List<string> items)
        {
            

            while (true)
            {


                for (int i = 0; i < items.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(items[i]);
                    }
                    else
                    {
                        Console.WriteLine(items[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo ckey = Console.ReadKey();
                System.Threading.Thread.Sleep(50);
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == items.Count - 1)
                    {
                        //index = 0; //Remove the comment to return to the topmost item in the list
                    }
                    else { index++; }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        //index = menuItem.Count - 1; //Remove the comment to return to the item in the bottom of the list
                    }
                    else { index--; }
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    
                    return items[index];
                }
                Console.Clear();
               
               
            }
        }
    }
}
