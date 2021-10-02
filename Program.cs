using System;

namespace HangManGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu;
            Hangman game = new Hangman(); //สร้าง object game จากคลาส Hangman
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Play game\n2. Exit"); //แสดงตัวเลือกให้ผู้ใช้เลือก
            Console.Write("Please Select Menu : ");
            menu = Convert.ToInt32(Console.ReadLine()); //รับค่าตัวเลือกใส่ไว้ในตัวแปร menu

            if(menu == 1) //ถ้าผู้ใช้เลือก 1
            {
                game.play(); //เรียกใช้ method play() ในคลาส Hangman
            }
        }
    }
}
