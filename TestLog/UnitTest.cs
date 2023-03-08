using NUnit.Framework;
using System.IO;
using DesafioLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestLog
{
    [TestFixture]
    public class Tests
    {
       // public static string GetCurrentDirectory();
       
       //Verifica se está escrevendo corretamente no arquivo
        [Test]
        public void testEcrever()
        {
            clLog mlog = new clLog();

            string txt = "TesteTeste";

            if(File.Exists(mlog.path)) File.Delete(mlog.path);
            if (File.Exists(mlog.oldpath)) File.Delete(mlog.oldpath);

            mlog.WriteLog(txt);

            StreamReader r = File.OpenText(mlog.path);
            string aa = r.ReadLine();// esta lendo a ultima linha?
            r.Close();  

            Assert.IsTrue(aa.Contains(txt));



            }

        //Verifica a existência do arquivo OLD
        
        [Test]
        public void testOld()
        {
            clLog mlog = new clLog();


            string txt = String.Concat(Enumerable.Repeat("Camiltcha", 100).ToArray());


            if (File.Exists(mlog.path)) File.Delete(mlog.path);
            if (File.Exists(mlog.oldpath)) File.Delete(mlog.oldpath);

            mlog.WriteLog(txt);
            mlog.WriteLog(txt);


            if ((new FileInfo(mlog.path).Length) >= mlog.MaxFileLengh)
            { 
                Assert.IsTrue(File.Exists(mlog.oldpath));
                
            }
        }

        //Verifica se está imprimindo o DateTime corretamente
        [Test]
        public void testTimeStamp()
        {
            clLog mlog = new clLog();

            string txt = "Camila";

            if (File.Exists(mlog.path)) File.Delete(mlog.path);
            if (File.Exists(mlog.oldpath)) File.Delete(mlog.oldpath);

            mlog.WriteLog(txt);
            
            int seg = DateTime.Now.Second;

            StreamReader r = File.OpenText(mlog.path);
            string aa = r.ReadLine();
            r.Close();

            string[] retorno = aa.Split(" ");
            string[] extrairHor = retorno[0].Split(" ");
            string[] extrairSeg = retorno[1].Split(":");
            string FileSegundo = extrairSeg[2];
            int resultado = int.Parse(FileSegundo) - seg;

            Assert.AreEqual(true, resultado < 2);

        }

        //Verifica a criação da pasta default
        [Test]
        public void pastaDefault()
        {
            clLog mlog = new clLog();

            string txt = " ";

            if (File.Exists(mlog.path)) File.Delete(mlog.path);
            if (File.Exists(mlog.oldpath)) File.Delete(mlog.oldpath);

            mlog.WriteLog(txt);

            if (File.Exists(mlog.DefaultFileName))
            {
                Assert.IsTrue(true);
            }
        }
    }
}