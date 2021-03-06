﻿using System;
using System.IO;
using System.Windows.Forms;

namespace TestSystem
{   
    
    public class TaskList
    {
       public  class Task
        {
            ///const byte maxCode = 14;
            private string Question;
            private string [] Ans = new string[7];
            private string[] codeSample = new string[14];
            private string Correct;
            public Task(string Question, string[] codeSample, int maxCode, string[] Answers, string correct)
            {
                this.Question = Question;
                Array.Copy(codeSample, this.codeSample , maxCode);
                Array.Copy(Answers, this.Ans, 7);
                this.Correct = correct;
            }
            public string GetQuestion()
            {
                return Question;
            } 
            public string [] GetCodeSample()
            {
                return codeSample;
            }
            public string [] GetAnswers()
            {
                ///Random rand = new Random();
                ///string[] str = this.Ans.OrderBy(x => rand.Next()).ToArray();
                ///Array.Resize(ref str, 7);
                return Ans;
            }
            public bool SendAnswer(string ans)
            {
                if (ans != this.Correct) { return false; }
                else { return true; }
            }  
        }
        private Task[] Tasks = new Task[50];
        private int Length;
        public TaskList()
        {
            ///const byte maxCode = 14;
            // MessageBox.Show(Directory.GetCurrentDirectory());
            using (StreamReader readStream = new StreamReader(Directory.GetCurrentDirectory()+"\\Tasks.txt"))
            {
                Length = Convert.ToInt16(readStream.ReadLine());
                int current = 0;
                string[] lines = new string[7];
                string[] code = new string[14];
                string Quest;
                string correct = "";
                string kod;
               // while (readStream.Peek() != -1)
                 for(int p=0; p<Length; p++)
                {
                    Quest = readStream.ReadLine();
                    int j = 0;
                    int maxCode = 0;
                    kod = readStream.ReadLine();
                    ///MessageBox.Show(kod);
                    while (kod[0] != '&')
                    {
                        maxCode++;
                        code[j] = kod;
                        kod = readStream.ReadLine();
                        j++;                                    
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        lines[i] = readStream.ReadLine();
                        //MessageBox.Show(lines[i]);
                        if (lines [i][lines[i].Length-1] == '&')
                        {
                            lines[i] = lines[i].Remove(lines[i].Length - 1);
                            correct = lines[i];
                        }
                    }
                    //MessageBox.Show(lines[0]+"current="+current.ToString());
                    Tasks[current] = new Task(Quest, code, maxCode, lines, correct);
                    current++;
                    //MessageBox.Show(Tasks[current-1].GetAnswers()[0]+ Tasks[current - 1].GetAnswers()[1] + Tasks[current - 1].GetAnswers()[2] + Tasks[current - 1].GetAnswers()[3] + Tasks[current - 1].GetAnswers()[4]);
                   // MessageBox.Show("current="+(current-1).ToString()+Tasks[current-1].GetAnswers()[0]);
                   // MessageBox.Show("current=" + (current - 1).ToString() + GetTask(current-1).GetAnswers()[0]);
                }
            }
        }
        public Task GetTask(int num)
        {
            return Tasks[num];
        }
        public int Len()
        {
            return Length;
        }
    }
}
