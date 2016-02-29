using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1 {
    class Program {
        static char[]   separators= {','};
        static void Main(string[] args)
        {
            string inFileName = args[0];
            Console.WriteLine("Reading \""+inFileName+"\"");

            string[] lines;
            try {
                lines = File.ReadAllLines(inFileName);
            }catch(Exception e) {
                lines = null;
                Console.WriteLine("ERROR: Failed to read "+inFileName);
                Console.WriteLine(" "+e.ToString());
                return;
            }
            List<Person> people = new List<Person>();
            for(int iline = 0; iline<lines.Length; iline++) {
                string s = lines[iline];
                string line = s.Trim();
                string[] parts = line.Split(separators);
                if(parts.Length<3) {
                    Console.WriteLine("ERROR: line("+(iline+1)+") Could read all parts");
                    return;
                }
                Person person = new Person();
                person.surname = parts[0].Trim();
                person.name = parts[1].Trim();
                string number = parts[2].Trim();
                try {
                    person.score = int.Parse(number);
                } catch(Exception e) {
                    Console.WriteLine("ERROR: line("+(iline+1)+") Couldnt read score");
                    return;
                }
                people.Add(person);
            }
            people.Sort(delegate (Person b, Person a) {
                int diff = a.score - b.score;
                if(diff!=0) {
                    return diff;
                } else {
                    diff = string.Compare(b.surname, a.surname);
                    if(diff!=0) {
                        return diff;
                    } else {
                        return string.Compare(b.name, a.name);
                    }
                }

            });
            string outFileName = inFileName;
            int lastIndex = outFileName.LastIndexOf(".");
            outFileName = outFileName.Substring(0, lastIndex)+"-graded.txt";
            Console.WriteLine("out file="+outFileName);
            try {
                TextWriter tw = new StreamWriter(outFileName);
                foreach(var person in people) {
                    tw.WriteLine(person.surname+", "+person.name+", "+person.score);
                }
                tw.Close();


                //System.IO.File.WriteAllText(outFileName,output);
            } catch(Exception e) {
                Console.WriteLine("ERROR: Failed to write "+outFileName);
                Console.WriteLine(" "+e.ToString());
                return;
            }

            Console.WriteLine("Finished: created "+outFileName);
        }

        class Person {
            public  string  name;
            public  string  surname;
            public  int     score;
            public void display()
            {
                Console.WriteLine("("+surname+","+name+","+score);
            }
        }
    }
}
