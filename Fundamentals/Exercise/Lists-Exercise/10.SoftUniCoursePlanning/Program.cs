using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coursePlan = Console.ReadLine().Split(", ").ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "course start")
            {
                // turns out I don't need this :(
                //for (int i = 0; i < coursePlan.Count; i++)
                //{
                //    if ((i == 0 || i % 2 == 0) && coursePlan[i].Contains("Exercise"))
                //    {
                //        string lectureName = coursePlan[i].Split('-')[0];
                //        if (coursePlan.Any(x => x == lectureName) && i != 0 && coursePlan[i - 1] != lectureName)
                //        {
                //            int lectureIndex = coursePlan.IndexOf(lectureName);
                //            coursePlan.RemoveAt(lectureIndex);
                //            coursePlan.Insert(i, lectureName);
                //        }
                //        else
                //        {
                //            coursePlan.Insert(i, lectureName);
                //        }
                //    }
                //}
                //for (int i = 0; i < coursePlan.Count; i++)           
                //{
                //    if (coursePlan[i].Contains("Exercise"))
                //    {
                //        continue;
                //    }
                //    for (int j = i; j < coursePlan.Count; j++)
                //    {
                //        if (coursePlan[j] == coursePlan[i]
                //            && !coursePlan.Any(x => x == coursePlan[i] + "-Exercise")
                //            && ((i == coursePlan.Count - 1 && !coursePlan[i].Contains("Exercise"))
                //                || coursePlan[i + 1] != coursePlan[i] + "-Ecercise"))
                //        {
                //            coursePlan.Insert(i + 1, coursePlan[i] + "-Exercise");
                //        }
                //    }
                //}

                string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string lessonTitle = cmdArgs[1];

                switch (action)
                {
                    case "Add":
                        if (!coursePlan.Any(x => x == lessonTitle))
                        {
                            coursePlan.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        if (!coursePlan.Any(x => x == lessonTitle))
                        {
                            int index = int.Parse(cmdArgs[2]);
                            coursePlan.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        coursePlan.Remove(lessonTitle);
                        break;
                    case "Swap":
                        string lessonTitle2 = cmdArgs[2];
                        if (coursePlan.Any(x => x == lessonTitle2))
                        {
                            int index1 = coursePlan.IndexOf(lessonTitle);
                            int index2 = coursePlan.IndexOf(lessonTitle2);

                            string tempVariable = coursePlan[index1];
                            coursePlan[index1] = coursePlan[index2];
                            coursePlan[index2] = tempVariable;
                            if (index1 + 1 < coursePlan.Count && coursePlan[index1 + 1].Contains(lessonTitle))
                            {
                                coursePlan.Insert(index2 + 1, coursePlan[index1 + 1]);
                                coursePlan.RemoveAt(index1 + 2);
                            }
                            if (index2 + 1 < coursePlan.Count && coursePlan[index2 + 1].Contains(lessonTitle2))
                            {
                                coursePlan.Insert(index1 + 1, coursePlan[index2 + 1]);
                                coursePlan.RemoveAt(index2 + 2);
                            }
                        }
                        break;
                    case "Exercise":
                        if (coursePlan.Any(x => x == lessonTitle) && !coursePlan.Any(x => x == lessonTitle + "-Exercise"))
                        {
                            int index = coursePlan.IndexOf(lessonTitle);
                            coursePlan.Insert(index + 1, lessonTitle + "-Exercise");
                        }
                        else if (!coursePlan.Any(x => x == lessonTitle + "-Exercise"))
                        {
                            coursePlan.Add(lessonTitle);
                            coursePlan.Add(lessonTitle + "-Exercise");
                        }
                        break;
                    default:
                        break;
                }
            }

            coursePlan = coursePlan.Distinct().ToList();
            for (int i = 0; i < coursePlan.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{coursePlan[i]}");
            }
        }
    }
}
