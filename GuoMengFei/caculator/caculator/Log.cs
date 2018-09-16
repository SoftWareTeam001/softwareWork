using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;
//reactor
namespace caculator
{
    class Log
    {
        public Log(string formula="",string result = "")
        {
            this.formula = formula;
            this.result = result;
        }
        public string formula;
        public string result;
        public static int CurrentLog=1;
        public static string DirPath = "../../log.txt";
        public void CreateLog()
        {
            FileStream logFile = new FileStream(DirPath, FileMode.Append, FileAccess.ReadWrite);
            logFile.Close();
        }
        public void AddLog()
        {
            StreamWriter streamWriter = new StreamWriter(DirPath,true);
            string log = "[" + formula + ":" + result + "]";
            streamWriter.WriteLine(log);
            streamWriter.Close();
        }
        public string ReadLog()
        {
            StreamReader streamReader = new StreamReader(DirPath);
            string logContent="";
            string eachLine;
            while ((eachLine=streamReader.ReadLine()) != null)
            {
                logContent += eachLine;
            }
            return eachLine;
        }
        public string ReadLastLog()
        {
            string[] log=new string[100];
            StreamReader streamReader = new StreamReader(DirPath);
            int i = 0;
            string eachLine;
            for(;(eachLine=streamReader.ReadLine())!=null && i<100; i++)
            {
                log[i]= eachLine;
            }
            return log[i-CurrentLog];
        }
        public string ReadNextLog()
        {
            string[] log = new string[100];
            StreamReader streamReader = new StreamReader(DirPath);
            int i = 0;
            string eachLine;
            for (; (eachLine=streamReader.ReadLine() )!= null && i < 100; i++)
            {
                log[i] = eachLine;
            }
            return log[i - CurrentLog-1];
        }
        public string GetResultFromLog(string log)
        {
            string resultPattern = @"(?<=:).+?(?=\])";
            string result="";
            foreach (Match match in Regex.Matches(log, resultPattern))
            {
                result = match.Value;
            }
            return result;
        }
        public string getFormulaFromLog(string log)
        {
            string formulaPattern = @"(?<=\[).+?(?=\:)";
            string formula = "";
            foreach(Match match in Regex.Matches(log, formulaPattern))
            {
                formula = match.Value;
            }
            return formula;
        }
    }
}
