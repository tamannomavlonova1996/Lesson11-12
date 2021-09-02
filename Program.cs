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

    interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }

    interface IRecordable
    {
        void Record();
        void Pause();
        void Stop();
    }

    public class Player : IPlayable, IRecordable
    {
        void IPlayable.Play()
        {
            Console.WriteLine("Music is playing");
        }

        void IPlayable.Pause()
        {
            Console.WriteLine("Music is paused");
        }

        void IPlayable.Stop()
        {
            Console.WriteLine("Music is stopped");
        }

        void IRecordable.Record()
        {
            Console.WriteLine("Recording");
        }

        void IRecordable.Pause()
        {
            Console.WriteLine("Recording is paused");
        }

        void IRecordable.Stop()
        {
            Console.WriteLine("Recording is stopped");
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
            
            IPlayable player1 = new Player();
            IRecordable player2 = new Player();
            player2.Stop();
            player1.Play();
        }
    }
}