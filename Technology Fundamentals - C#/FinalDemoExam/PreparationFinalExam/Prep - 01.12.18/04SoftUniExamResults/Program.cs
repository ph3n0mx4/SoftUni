namespace _04SoftUniExamResults// не става с клас ;(
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class ExamList
    {
        public string Language { get; set; }

        public int Point{ get; set; }

        public ExamList()
        {
            Language = "";
            Point = 0;
        }
            

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('-');
            var banned = new List<string>();
            var list = new Dictionary<string, ExamList>();
            while (input[0]!= "exam finished")
            {
                if(input[1]=="banned")
                {
                    banned.Add(input[0]);
                    input = Console.ReadLine().Split('-');
                    continue;
                }

                string name = input[0];
                string language = input[1];
                int point= int.Parse(input[2]);

                if(!list.ContainsKey(name))
                {
                    list[name] = new ExamList();
                }

                if (list[language].Language.Contains(name) )
                {
                    list[name].Point = point;
                }

                else
                {
                    list[name].Language = language;
                    list[name].Point = point;
                }


                input = Console.ReadLine().Split('-');
            }
            Console.WriteLine();
        }
    }
}
