using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Lab
{
    internal class Program
    {
        #region Old
        class GPSSEnvironment
        {
            public Dictionary<string, Queue<Element>> queue;
            public List<ICommand> commands = new List<ICommand>();
            public List<Element> active_elements = new List<Element>();
            int model_time = -1;
            Action<string[]> return_callback = null;

            public GPSSEnvironment(string[] commands_list, Action<string[]> return_callback)
            {
                queue = new Dictionary<string, Queue<Element>>();
                queue.Add("GenerationQueue", new Queue<Element>());

                this.return_callback = return_callback;

                foreach(string command in commands_list)
                {
                    if(string.IsNullOrEmpty(command) || command[0] == ';') 
                        continue;


                    if (command.Contains("GENERATE")) commands.Add(new Generate(this, command));
                    else if (command.Contains("QUEUE")) commands.Add(new Queue(this, command));
                    else if (command.Contains("SEIZE")) commands.Add(new Seize(this, command));
                    else if (command.Contains("DEPART")) commands.Add(new Depart(this, command));
                    else if (command.Contains("ADVANCE")) commands.Add(new Advance(this, command));
                    else if (command.Contains("RELEASE")) commands.Add(new Release(this, command));
                    else if (command.Contains("TIME")) model_time = int.Parse(command.Split('|')[1]);
                }
                if (model_time == -1)
                    return_callback(null);

                for (int i = 0; i < model_time; i++)
                    commands[i].Execute(i);
            }
        }
        class Generate : ICommand
        {
            GPSSEnvironment environment = null;
            int middle_time = -1;
            int variety_time = -1;
            bool has_variety = false;

            int execution_time = -1;

            void ResetExecutionTime(int current_time)
            {
                execution_time = current_time + middle_time;

                Random rnd = new Random();
                if (has_variety)
                    execution_time += rnd.Next(-variety_time, variety_time);
            }


            public void Execute(int time)
            {
                if (time != execution_time)
                    return;


                ResetExecutionTime(execution_time);
            }
            public Generate(GPSSEnvironment env, string attributes)
            {
                List<string> attributes_list = new List<string>(attributes.Split('|'));
                attributes_list.RemoveAt(0);
                this.environment = env;

                middle_time = int.Parse(attributes_list[1]);

                if (attributes_list.Count == 2)
                {
                    variety_time = int.Parse(attributes_list[2]);
                    has_variety = true;
                }

                ResetExecutionTime(0);
            }
        }
        class Queue : ICommand
        {
            string queue_name = null;
            GPSSEnvironment environment = null;
            public void Execute(int time)
            {

            }
            public Queue(GPSSEnvironment env, string attributes)
            {
                this.environment = env;
                string[] attributes_ = attributes.Split('|');
                queue_name = attributes_[1];
            }
        }
        class Seize : ICommand
        {
            string worker_name = null;
            Element element = null;

            GPSSEnvironment environment = null;
            public void Execute(int time)
            {

            }
            public Seize(GPSSEnvironment env, string attributes)
            {
                this.environment = env;
                worker_name = attributes.Split('|')[1];
            }
        }
        class Depart : ICommand
        {
            GPSSEnvironment environment = null;
            public void Execute(int time)
            {

            }
            public Depart(GPSSEnvironment env, string attributes)
            {
                this.environment = env;
            }
        }
        class Advance : ICommand
        {
            GPSSEnvironment environment = null;
            public void Execute(int time)
            {

            }
            public Advance(GPSSEnvironment env, string attributes)
            {
                this.environment = env;
            }
        }
        class Release : ICommand
        {
            GPSSEnvironment environment = null;
            public void Execute(int time)
            {
                
            }
            public Release(GPSSEnvironment env, string attributes)
            {
                this.environment = env;
            }
        }
        interface ICommand
        {
            void Execute(int time);
        }
        class Element
        {

        }
        public static string InputFilePath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/Input.txt";
        public static string OutputFilePath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}/Output.txt";
        #endregion

        static void Main(string[] args)
        {
            //if (!File.Exists(InputFilePath))
            //    return;
            //string[] commands = File.ReadAllLines(InputFilePath);
            //GPSSEnvironment gpss = new GPSSEnvironment(commands, result => File.WriteAllLines(OutputFilePath, result));

            GPSS gpss = new GPSS(2400);

            Console.WriteLine($"Done first: {gpss.first_done}");
            Console.WriteLine($"Done second: {gpss.second_done}");

            Console.WriteLine();

            int[] a_entries = new int[3]
            {
                gpss.a1.entries,
                gpss.a2.entries,
                gpss.a3.entries
            };
            double[] util = new double[3]
            {
                Math.Round(1f * gpss.a1.busy_iterations / 
                (gpss.a1.busy_iterations + gpss.a1.free_iterations),4),
                Math.Round(1f * gpss.a2.busy_iterations / 
                (gpss.a2.busy_iterations + gpss.a2.free_iterations),4),
                Math.Round(1f * gpss.a3.busy_iterations / 
                (gpss.a3.busy_iterations + gpss.a3.free_iterations),4)
            };
            float[] a_ave_time = new float[3]
            {
                (1f * gpss.a1.first.overall_time+gpss.a1.second.overall_time)/
                (gpss.a1.first.overall_timestamps_count+gpss.a1.second.overall_timestamps_count),
                (1f * gpss.a2.first.overall_time+gpss.a2.second.overall_time)/
                (gpss.a2.first.overall_timestamps_count+gpss.a2.second.overall_timestamps_count),
                (1f * gpss.a3.first.overall_time+gpss.a3.second.overall_time)/
                (gpss.a3.first.overall_timestamps_count+gpss.a3.second.overall_timestamps_count)
            };
            int[] q_entries = new int[3]
            {
                gpss.q_a1_entry,
                gpss.q_a2_entry,
                gpss.q_a3_entry
            };
            int[] q_count = new int[3]
            {
                gpss.q_a1.Count,
                gpss.q_a2.Count,
                gpss.q_a3.Count
            };
            int[] q_max_count = new int[3]
            {
                gpss.q_a1_max,
                gpss.q_a2_max,
                gpss.q_a3_max
            };
            for (int i = 0; i < a_entries.Length; i++)
                Console.WriteLine($"A{i+1}\tEntry: {a_entries[i]}\tutil.: {util[i]}\tAve.Time: {a_ave_time[i]}");

            Console.WriteLine();

            for (int i = 0; i < a_entries.Length; i++)
                Console.WriteLine($"Q1\tEntry: {q_entries[i]}\tCount: {q_count[i]}\tMax: {q_max_count[i]}");

            Console.ReadKey();
        }

        class GPSS
        {
            public GPSS(int time)
            {
                for (int i = 0; i < time; i++)
                    Loop(i);
            }
            class Generate
            {
                public int generate_time;
                public int main_time;
                public int additional_time;

                public void SetTime(int current_time)
                {
                    Random rnd = new Random();
                    generate_time = current_time + main_time + rnd.Next(-additional_time, additional_time);
                }
            }
            public class Worker
            {
                public struct WorkingTime
                {
                    public int working_time;
                    public int working_main_time;
                    public int working_additional_time;

                    public void SetTime(int current_time)
                    {
                        Random rnd = new Random();
                        working_time = current_time + working_main_time + rnd.Next(-working_additional_time, working_additional_time);

                        overall_time += working_time - current_time;
                        overall_timestamps_count++;
                    }
                    public int overall_time;
                    public int overall_timestamps_count;
                }
                public int entries = 0;
                public int busy_iterations = 0;
                public int free_iterations = 0;

                public WorkingTime first = new WorkingTime();
                public WorkingTime second = new WorkingTime();

                public bool is_free = true;

            }

            public Worker a1 = new Worker()
            {
                first = new Worker.WorkingTime()
                {
                    working_main_time = 12,
                    working_additional_time = 5
                },
                second = new Worker.WorkingTime()
                {
                    working_main_time = 5,
                    working_additional_time = 2
                }
            };
            public Worker a2 = new Worker()
            {
                first = new Worker.WorkingTime()
                {
                    working_main_time = 15,
                    working_additional_time = 5
                },
                second = new Worker.WorkingTime()
                {
                    working_main_time = 18,
                    working_additional_time = 3
                }
            };
            public Worker a3 = new Worker()
            {
                first = new Worker.WorkingTime()
                {
                    working_main_time = 20,
                    working_additional_time = 4
                },
                second = new Worker.WorkingTime()
                {
                    working_main_time = 10,
                    working_additional_time = 3
                }
            };
            Generate first_gen = new Generate()
            {
                main_time = 30,
                additional_time = 10
            };
            Generate second_gen = new Generate()
            {
                main_time = 15,
                additional_time = 3
            };
            public Queue<string> q_a1 = new Queue<string>();
            public Queue<string> q_a2 = new Queue<string>();
            public Queue<string> q_a3 = new Queue<string>();

            public int q_a1_max = 0;
            public int q_a2_max = 0;
            public int q_a3_max = 0;

            public int q_a1_entry = 0;
            public int q_a2_entry = 0;
            public int q_a3_entry = 0;

            void FirstSegment(int time)
            {
                if(first_gen.generate_time == time)
                {
                    first_gen.SetTime(time);
                    q_a2.Enqueue("");
                    q_a2_entry++;
                    if (q_a2_max < q_a2.Count)
                        q_a2_max = q_a2.Count;
                }
                if (a2.is_free && q_a2.Count != 0)
                {
                    a2.is_free = false;
                    a2.first.SetTime(time);
                    q_a2.Dequeue();
                    a2.entries++;
                }
                else if (!a2.is_free && a2.first.working_time == time)
                {
                    //q_a2.Dequeue();
                    q_a1.Enqueue("");
                    q_a1_entry++;
                    if (q_a1_max < q_a1.Count)
                        q_a1_max = q_a1.Count;
                    a2.is_free = true;
                    
                }
                if (a1.is_free && q_a1.Count != 0)
                {
                    q_a1.Dequeue();
                    a1.is_free = false;
                    a1.first.SetTime(time);
                    a1.entries++;
                }
                else if (!a1.is_free && a1.first.working_time == time)
                {
                    //q_a1.Dequeue();
                    q_a3.Enqueue("");
                    q_a3_entry++;
                    if (q_a3_max < q_a3.Count)
                        q_a3_max = q_a3.Count;
                    a1.is_free = true;

                    
                }
                if (a3.is_free && q_a3.Count != 0)
                {
                    q_a3.Dequeue();
                    a3.is_free = false;
                    a3.first.SetTime(time);
                    a3.entries++;
                }
                else if (!a3.is_free && a3.first.working_time == time)
                {
                    //q_a3.Dequeue();
                    a3.is_free = true;
                    first_done++;
                }
            }
            public int first_done = 0;
            public int second_done = 0;
            void SecondSegment(int time)
            {
                if (second_gen.generate_time == time)
                {
                    second_gen.SetTime(time);
                    q_a1.Enqueue("");
                    q_a1_entry++;
                    if (q_a1_max < q_a1.Count)
                        q_a1_max = q_a1.Count;
                }
                if (a1.is_free && q_a1.Count != 0)
                {
                    a1.is_free = false;
                    a1.second.SetTime(time);
                    q_a1.Dequeue();
                    a1.entries++;
                }
                else if (!a1.is_free && a1.second.working_time == time)
                {
                    //q_a1.Dequeue();
                    q_a3.Enqueue("");
                    q_a3_entry++;
                    if (q_a3_max < q_a3.Count)
                        q_a3_max = q_a3.Count;
                    a1.is_free = true;
                    
                }
                if (a3.is_free && q_a3.Count != 0)
                {
                    q_a3.Dequeue();
                    a3.is_free = false;
                    a3.second.SetTime(time);
                    a3.entries++;
                }
                else if (!a3.is_free && a3.second.working_time == time)
                {
                    //q_a3.Dequeue();
                    q_a2.Enqueue("");
                    q_a2_entry++;
                    if (q_a2_max < q_a2.Count)
                        q_a2_max = q_a2.Count;
                    a3.is_free = true;

                    
                }
                if (a2.is_free && q_a2.Count != 0)
                {
                    q_a2.Dequeue();
                    a2.is_free = false;
                    a2.second.SetTime(time);
                    a2.entries++;
                }
                else if (!a2.is_free && a2.second.working_time == time)
                {
                    //q_a2.Dequeue();
                    a2.is_free = true;
                    second_done++;
                }
            }

            void Loop(int time)
            {
                FirstSegment(time);
                SecondSegment(time);

                if (a1.is_free) a1.free_iterations++;
                else a1.busy_iterations++;

                if (a2.is_free) a2.free_iterations++;
                else a2.busy_iterations++;

                if (a3.is_free) a3.free_iterations++;
                else a3.busy_iterations++;
            }
        }
    }
}
    