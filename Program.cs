using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HelloWorld
{
    class Program
    {

        static char IntToChar(int a){
            if(a == 1){
                return '1';
            }
            else if(a == 2){
                return '2';
            }
            else if(a == 3){
                return '3';
            }
            else{
                return 'X';
            }
        }

        static bool IsAdjacent(char[] array, int cursor_x){
            if((array[cursor_x + 1] == ' ' || array[cursor_x + 1] == '|' ) && (array[cursor_x - 1] == ' ' || array[cursor_x - 1] == '|' )){
                return false;
            }
            else{
                return true;
            }

        }


        
        static void Main(string[] args)
        {
               

            int cursor_x = 1;
            int cursor_y = 1;
            int score = 0;

            ConsoleKeyInfo cursor_key; 

            char[] a1 = new char[32];
            char[] a2 = new char[32];
            char[] a3 = new char[32];

            for(int i = 1; i < 31; i++){
                a1[i] = a2[i] = a3[i] = ' ';
            }

            a1[0] = '|';
            a2[0] = '|';
            a3[0] = '|';
            a1[31] = '|';
            a2[31] = '|';
            a3[31] = '|';

            Random rnd = new Random();

            int random_array = rnd.Next(1,4);
            int random_index = rnd.Next(1, 31);
            int random_number = rnd.Next(1,4);


            bool is_placement_done = false;
            bool are_there_any_pairs = true;

            //Check for matching numbers then place them with a new pair.
            void MatchingNumbers(){
                while(are_there_any_pairs == true){
                    int  break_counter = 0;

                    for (int i = 0; i < 31; i++){
                        if(a1[i] == a1[i + 1] && a1[i] != ' '){
                            a1[i] = a1[i + 1] = ' ';
                            score += 10;
                            NumberPlacement(28);
                            is_placement_done = false;
                            break_counter += 1;
                        }

                        if(a2[i] == a2[i + 1] && a2[i] != ' '){
                            a2[i] = a2[i + 1] = ' ';
                            score += 10;
                            NumberPlacement(28);
                            is_placement_done = false;
                            break_counter += 1;
                        }

                        if(a3[i] == a3[i + 1] && a3[i] != ' '){
                            a3[i] = a3[i + 1] = ' ';
                            score += 10;
                            NumberPlacement(28);
                            is_placement_done = false;
                            break_counter += 1;
                        }

                    }
                    
                    if(break_counter == 0){
                        are_there_any_pairs = false;
                    }
                }
            }

            //Number placement loop.
            void NumberPlacement(int new_counter){
                while(is_placement_done == false){
                    random_array = rnd.Next(1,4);
                    random_index = rnd.Next(1, 31);
                    random_number = rnd.Next(1,4);

                    if(random_array == 1){
                        if(a1[random_index] == ' '){
                            a1[random_index] = IntToChar(random_number);
                            new_counter += 1;
                        }
                    }
                    else if(random_array == 2){
                        if(a2[random_index] == ' '){
                            a2[random_index] = IntToChar(random_number);
                            new_counter += 1;
                        }
                    }
                    else if(random_array == 3){
                        if(a3[random_index] == ' '){
                            a3[random_index] = IntToChar(random_number);
                            new_counter += 1;
                        }
                    }

                    if(new_counter == 30){
                        is_placement_done = true;
                    }
                }
            }
            NumberPlacement(-2);
            MatchingNumbers();
            is_placement_done = false;

            //Output frame of game screen.
            Console.Clear();
            Console.Write("+");
            for(int i = 0; i < 30; i++){
                Console.Write("-");
            }
            Console.WriteLine("+");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("+");
            for(int i = 0; i < 30; i++){
                Console.Write("-");
            }
            Console.WriteLine("+");

            //Main game loop
            while(true){
                
                //Reset cursor position and output arrays.
                Console.SetCursorPosition(0,1);
                for(int i = 0; i < 32; i++){
                    if(cursor_y == 1 && i == cursor_x){
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(a1[i]);
                        Console.ResetColor();
                        Console.CursorVisible = false;
                    }
                    else{
                        Console.Write(a1[i]);
                    }
                    
                    
                }
                Console.WriteLine();

                for(int i = 0; i < 32; i++){
                    if(cursor_y == 2 && i == cursor_x){
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(a2[i]);
                        Console.ResetColor();
                        Console.CursorVisible = false;
                    }
                    else{
                        Console.Write(a2[i]);
                    }
                }
                Console.WriteLine();

                for(int i = 0; i < 32; i++){
                    if(cursor_y == 3 && i == cursor_x){
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(a3[i]);
                        Console.ResetColor();
                        Console.CursorVisible = false;
                    }
                    else{
                        Console.Write(a3[i]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Score: {0}", score);

                
                //Set cursor position to it's original coordinates
                Console.SetCursorPosition(cursor_x, cursor_y);

                if(Console.KeyAvailable){
                
                    cursor_key = Console.ReadKey(true);

                    //Cursor movement with arrow keys.
                    if(cursor_key.Key == ConsoleKey.RightArrow && cursor_x < 30){
                        Console.SetCursorPosition(cursor_x, cursor_y);
                        cursor_x += 1;
                    }
                    if(cursor_key.Key == ConsoleKey.LeftArrow && cursor_x > 1){
                        Console.SetCursorPosition(cursor_x, cursor_y);
                        cursor_x -= 1;
                    }
                    if(cursor_key.Key == ConsoleKey.UpArrow && cursor_y > 1){
                        Console.SetCursorPosition(cursor_x, cursor_y);
                        cursor_y -= 1;
                    }
                    if(cursor_key.Key == ConsoleKey.DownArrow && cursor_y < 3){
                        Console.SetCursorPosition(cursor_x, cursor_y);
                        cursor_y += 1;
                    }

                    //Number movement with WASD keys
                    if(cursor_key.Key == ConsoleKey.W){
                        if(cursor_y != 1){
                            if(cursor_y == 2 && a1[cursor_x] == ' '){
                                if((a2[cursor_x + 1] == ' ' || a2[cursor_x + 1] == '|' ) && (a2[cursor_x - 1] == ' ' || a2[cursor_x - 1] == '|' )){
                                    a1[cursor_x] = a2[cursor_x];
                                    a2[cursor_x] = ' ';
                                    cursor_y -= 1;
                                    are_there_any_pairs = true;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                                
                            }
                            else if(a2[cursor_x] == ' '){
                                if((a3[cursor_x + 1] == ' ' || a3[cursor_x + 1] == '|' ) && (a3[cursor_x - 1] == ' ' || a3[cursor_x - 1] == '|' )){
                                    a2[cursor_x] = a3[cursor_x];
                                    a3[cursor_x] = ' ';
                                    cursor_y -= 1;
                                    are_there_any_pairs = true;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                        }
                    }
                    
                    if(cursor_key.Key == ConsoleKey.S){
                        if(cursor_y != 3){
                            if(cursor_y == 2 && a3[cursor_x] == ' '){
                                if((a2[cursor_x + 1] == ' ' || a2[cursor_x + 1] == '|' ) && (a2[cursor_x - 1] == ' ' || a2[cursor_x - 1] == '|' )){
                                    a3[cursor_x] = a2[cursor_x];
                                    a2[cursor_x] = ' ';
                                    cursor_y += 1;
                                    are_there_any_pairs = true;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                                
                            }
                            else if(a2[cursor_x] == ' '){
                                if((a1[cursor_x + 1] == ' ' || a1[cursor_x + 1] == '|' ) && (a1[cursor_x - 1] == ' ' || a1[cursor_x - 1] == '|' )){
                                    a2[cursor_x] = a1[cursor_x];
                                    a1[cursor_x] = ' ';
                                    cursor_y += 1;
                                    are_there_any_pairs = true;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                        }
                    }

                    if(cursor_key.Key == ConsoleKey.D){
                        if(a1[cursor_x + 1] != '|'){
                            if(cursor_y == 1 && IsAdjacent(a1, cursor_x) == false){
                                while(IsAdjacent(a1, cursor_x) == false){
                                    a1[cursor_x + 1] = a1[cursor_x];
                                    a1[cursor_x] = ' ';
                                    cursor_x += 1;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                            if(cursor_y == 2 && IsAdjacent(a2, cursor_x) == false){
                                while(IsAdjacent(a2, cursor_x) == false){
                                    a2[cursor_x + 1] = a2[cursor_x];
                                    a2[cursor_x] = ' ';
                                    cursor_x += 1;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                            if(cursor_y == 3 && IsAdjacent(a3, cursor_x) == false){
                                while(IsAdjacent(a3, cursor_x) == false){
                                    a3[cursor_x + 1] = a3[cursor_x];
                                    a3[cursor_x] = ' ';
                                    cursor_x += 1;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                            are_there_any_pairs = true; 
                        }
                    }

                    if(cursor_key.Key == ConsoleKey.A){
                        if(a1[cursor_x - 1] != '|'){
                            if(cursor_y == 1 && IsAdjacent(a1, cursor_x) == false){
                                while(IsAdjacent(a1, cursor_x) == false){
                                    a1[cursor_x - 1] = a1[cursor_x];
                                    a1[cursor_x] = ' ';
                                    cursor_x -= 1;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                            if(cursor_y == 2 && IsAdjacent(a2, cursor_x) == false){
                                while(IsAdjacent(a2, cursor_x) == false){
                                    a2[cursor_x - 1] = a2[cursor_x];
                                    a2[cursor_x] = ' ';
                                    cursor_x -= 1;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                            if(cursor_y == 3 && IsAdjacent(a3, cursor_x) == false){
                                while(IsAdjacent(a3, cursor_x) == false){
                                    a3[cursor_x - 1] = a3[cursor_x];
                                    a3[cursor_x] = ' ';
                                    cursor_x -= 1;
                                    Console.SetCursorPosition(cursor_x, cursor_y);
                                }
                            }
                            are_there_any_pairs = true;  
                        }                   
                    }

                    

                    //End the loop if the escape key is pressed.
                    if (cursor_key.Key == ConsoleKey.Escape) break;
                }

                //Check for matching numbers each iteration
                MatchingNumbers();
                
                

                //Wait for 20ms to prevent glitches in game screen.
                Thread.Sleep(20);
            }
        
        }
    }
}