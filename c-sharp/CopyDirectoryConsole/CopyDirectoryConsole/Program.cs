using System;
using System.IO;

namespace CopyDirectoryConsole
{
    ///---------------------------------------------------------------------------------
    ///   Namespace:    CopyDirectoryConsole
    ///   Class:        Program
    ///   Author:       Mark Hamner (adaption of code originally from MSDN)
    ///   Description:  This is a console application that demonstrates recursively copying
    ///                 a directory and its sub-directories
    ///---------------------------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            //Get the source and target directory from the user via the console
            Console.WriteLine("Please enter the directory to copy from: ");
            string fromDir = Console.ReadLine();
            Console.WriteLine("Please enter the directory to copy to: ");
            string toDir = Console.ReadLine();

            //Note:  Right now this will still require the user to enter the escaped
            //  directory structure; can add code to convert their entry to a string literal
            //  to make it a bit more user-friendly

            //Call our main directory copy and send an error message if there's a problem
            try
            {
                Copy(fromDir, toDir);
                Console.WriteLine("Directory copy successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error encountered during directory copy: \n"
                    + ex.ToString());
            }
           
        }

        /// <summary>
        /// Copy the source directory and all sub-directories to the target directory
        /// </summary>
        /// <param name="src">source directory</param>
        /// <param name="tar">target directory</param>
        public static void Copy(string src, string tar)
        {
            DirectoryInfo dirSource = new DirectoryInfo(src);
            DirectoryInfo dirTarget = new DirectoryInfo(tar);

            RecursiveCopy(dirSource, dirTarget);
        }

        /// <summary>
        /// Copies all sub-directories from source to target using recursion (i.e. calling itself)
        /// </summary>
        /// <param name="source">source directory</param>
        /// <param name="target">targe directory</param>
        public static void RecursiveCopy(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            //Note:  Recursive approach does expose the possibility of a stack
            //  overflow error, but that should only be a possibility on very deeply
            //  nested directories
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                RecursiveCopy(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
