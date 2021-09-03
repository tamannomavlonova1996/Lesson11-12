using System;

namespace Lesson11_12
{
    public class DocumentWorker
    {
        public void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }

    public class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine(
                "Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }

    public class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter pro or exp key here: ");
            string key = Console.ReadLine();
            string proKey = "000";
            string expKey = "111";
            DocumentWorker docWorker = new DocumentWorker();

            if (key.Equals(proKey))
            {
                docWorker = new ProDocumentWorker();
            }
            else if (key.Equals(expKey))
            {
                docWorker = new ExpertDocumentWorker();
            }

            docWorker.EditDocument();
            docWorker.OpenDocument();
            docWorker.SaveDocument();
        }
    }
}