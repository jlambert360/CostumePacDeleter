/*
 * Copyright (c) 2020 Bird
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms and conditions of the GNU General Public License,
 * version 2, as published by the Free Software Foundation.
 *
 * This program is distributed in the hope it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Linq;

namespace CostumePacDeleter
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Paste your \\pf\\fighter dircetory and press enter. EX: \"F:\\Project+\\pf\\fighter\"");
                Console.Write("Fighter Path: ");
                string directory = Console.ReadLine(); //Get directory to look for pac files
                try
                {
                    foreach (string d in Directory.GetDirectories(directory)) //For each folder in the directory
                    {
                        Console.WriteLine("Found folder " + d);
                        foreach (string filePath in Directory.GetFiles(d)) //For each file in the directory folders
                        {
                            var name = new FileInfo(filePath).Name; //name is .pac file names
                            name = name.ToLower(); //Set .pac names to lower case
                            bool containsInt = name.Any(char.IsDigit); //Check if the .pac files contain a number
                            bool containsAlt = name.Contains("alt"); //Check if there are AltR or AltZ files
                            bool containsExtra = name.Contains("kirby") || name.Contains("spy") || name.Contains("etc"); //Check for kirby files, spy files, and etc files
                            if (containsAlt == true && containsExtra == false || containsInt == true && containsExtra == false) //If pac file names contain a number, is an alt, and doesn't contain spy, etc, or is a kirby costume file
                            {
                                Console.WriteLine("Deleting file " + filePath);
                                File.Delete(filePath); //Delete files
                            }
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine("The process failed: {0}", e.Message); }

                Console.WriteLine("Done! \n\n" + "Press Enter to continue or type \"exit\" to close the program");

            } while (Console.ReadLine().ToLower() != "exit");
        }
    }
}