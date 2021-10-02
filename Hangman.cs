using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGame
{
    class Hangman
    {
        private string[] wordList; //ลิสของคำทาย

        public Hangman()
        {
            wordList = new string[] { "Tennis", "Football", "Badminton" }; //เมื่อ object ถูกสร้างลิสของคำทายก็จะถูกสร้างขึ้น
        }

        public void play() //method เมื่อผู้ใช้กดเล่น
        {
            char[] wordGuess, word; //wordguess สำหรับแสดงตัวคำใบ้, word จะเป็นตัวอักษรแต่ละตัวของคำ
            char guess; //ตัวอักษรทายของผู้ใช้
            bool isWon = false; //เอาไว้เก็บค่าถ้าชนะ
            int incorrect; //เอาไว้เก็บค่าจำนวนที่ทายผิด

            int rnd = new Random().Next(0, wordList.Length); //สุ่มคำในลิส
            String w = wordList[rnd].ToLower(); //นำค่าที่สุ่มได้ใน wordLidt ไปใส่ไว้ใน w และกำหนดให้เป็นตัวพิมพ์เล็กทั้งหมด
            word = w.ToCharArray();  //แยกคำเป็นตัวอักษรแลพเก็บในตัวแปร word
            wordGuess = new char[word.Length]; //กำหนด wordguess ให้มีความยาวเท่ากับตัวอักษรของคำ
            for (int j = 0; j < w.Length; j++) //วนลูปกำหนดให้ตัวอักษรใน wordguess เป็น "_" ทั้งหมด
            {
                wordGuess[j] = '_';
            }

            incorrect = 0; //กำหนดจำนวนผิดเป็น 0 (ค่าเริ่มต้น)
            do //วนลูป
            {
                Console.Clear(); //เคลียร์หน้าจอ
                Console.WriteLine("Play Game Hangman");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(" Incorrect Score: " + incorrect); //แสดงจำนวนครั้งที่ผิด
                for (int j = 0; j < wordGuess.Length; j++) //วนลูปเพื่อแสดงคำทาย
                {
                    Console.Write(wordGuess[j] + " ");
                }
                Console.WriteLine();
                Console.Write("Input letter alphabet: "); //ให้ผู้ใช้ใส่ตัวอักษร
                guess = Convert.ToChar(Console.ReadLine()); //เก็บค่าอักษรที่ผู้ใช้ใส่มาใน guess
                bool right = false; //กำหนดค่าเริ่มต้นว่าทายถูกไหมเป็น false
                for (int j = 0; j < word.Length; j++) //วนลูปตรวจสอบคำ
                {
                    if (word[j] == guess) //ถ้าตัวอักษรที่ใส่มาตรงกับตัวอักษรในคำนั้นๆ
                    {
                        wordGuess[j] = guess; //กำหนดคำทายที่แสดงเป็นตัวอักษรนั้น
                        right = true; //กำหนดค่าทายถูกเป็น true
                    }
                }

                for (int j = 0; j < wordGuess.Length; j++) //ตรวจสอบว่าชนะหรือยัง
                {
                    if (wordGuess[j] != '_') //ถ้าไม่มี "_"
                    {
                        isWon = true; //กำหนดค่าชนะเป็น true
                    }
                    else //ถ้ายังมี "_"
                    {
                        isWon = false; //กำหนดค่าชนะเป็น false
                        break; //ออกจากลูป
                    }
                }

                if (right == false) //ถ้าทายตัวอักษรไม่ถูก
                {
                    incorrect += 1; //จำนวนทายผิดเพิ่มขึ้น 1
                }

                if (isWon == true) //ถ้าชนะ
                {
                    Console.Clear(); //เคลียหน้าจอ
                    Console.WriteLine("Play Game Hangman");
                    Console.WriteLine("----------------------------------------");
                    for (int j = 0; j < wordGuess.Length; j++) //วนลูปปริ้นคำที่ถูกต้องทั้งหมด
                    {
                        Console.Write(wordGuess[j] + " ");
                    }
                    incorrect = 6; //กำหนดจำนวนคำผิดให้เป็น 6 เพื่อที่จะหลุดจากลูป
                }
            } while (incorrect < 6 && isWon == false); //ถ้าจำนวนคำผิดน้อยกว่า 6 และยังไม่ชนะจะยังไม่หลุดจากลูป

            if (isWon == true) //ถ้าชนะ
            {
                Console.WriteLine("\nYou win!!"); //แสดงผลว่าชนะ
            }
            else //ถ้าแพ้
            {
                Console.WriteLine("GAME OVER"); //แสดงผลว่าแพ้
            }
        }
    }
}
