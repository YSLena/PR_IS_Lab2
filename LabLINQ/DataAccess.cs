using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Эту ссылку надо добавить для работы с EntityFramework:
using System.Data.EntityClient;
using System.Data.Objects;

namespace LabLINQ
{
class DataAccess
    {
        private static DataAccess _instance;
        public static DataAccess GetInstance()
        {
            if (_instance != null)
                return _instance;
            else
                return new DataAccess();
        }//GetInstance

        private DataAccess()
        {
            Students = context.STUDENTS_ONE;
            _instance = this;
        }//DataAccess()

        // TODO 1
        /* Лабораторная работа посвящена использованию языка
         * LINQ - Language-Integrated Query
         * для выполнения запросов к различным источникам данных
         * 
         * На основе приведенных примеров постройте свои запросы
         * в соответствии с вариантом задания
         * После каждого упражнения программа должна
         * компилироваться и запускаться
         * 
         * Дополнительные сведения о языке LINQ
         * можно почерпнуть в документации MSDN:
         * http://msdn.microsoft.com/en-us/library/vstudio/bb397926.aspx
         */

        // Определение источника данных
        // Собственно, это и есть модель данных
        public STUDEntities context = new STUDEntities();
        ObjectQuery<STUDENTS_ONE> Students;

        public void Save()
        {
            context.SaveChanges();
        }//Save

        // TODO 2 
        // Упражнение 2
        // Используется проекция

        // TODO 2.1. Проекция на анонимный класс


        public object Query21Example()
        {
            return
                from st in context.STUDENTS_ONE
                select new
                {
                    Name = st.NAME,
                    Patronimic = st.PATRONIMIC
                };
        }

        // На основе приведенного выше примера постройте свой запрос
        public object Query21()
        {
            return null;
        }

        // TODO 2.2. Проекция на именованый класс класс

        //Создаём класс для оторбражения результатов запроса
        public class tmpClass
        {
            public string Name
            { get; set; }
            public string Patronimic
            { get; set; }
        }

        // Запрос возвращает коллекцию объектов ранее созданного класса
        public IEnumerable<tmpClass> Query22Example()
        {
            return 
                from st in context.STUDENTS_ONE
                select new tmpClass
                {
                    Name = st.NAME,
                    Patronimic = st.PATRONIMIC
                };
        }

        //Измените определение класса в соответсвии с заданием
        public class userClass
        {

        }

        // На основе приведенного выше примера постройте свой запрос
        public IEnumerable<userClass> Query22()
        {
            return null;
        }


        // TODO 3
        // Упражнение 3
        public object Query3Example()
        {
            return
                 from st in context.STUDENTS_ONE
                 orderby st.ABSENSES
                 select st;
        }

        public object Query3()
        {
            return null;
        }

        // TODO 4 
        // Упражнение 4. Выборка неповторяющихся значений
        // Здесь используется метод расширения
        public object Query4Example()
        {
            return
            (
            from st in context.STUDENTS_ONE
            select new
            {
                Absenses = st.ABSENSES
            }
            ).Distinct();
        }

        public object Query4()
        {
            return null;
        }

        // TODO 5 
        // Упражнение 5. Фильтрация данных
        public object Query5Example()
        {
            return
            from st in context.STUDENTS_ONE
            where (st.NAME == "Дмитро") && (st.ABSENSES >= 50)
            select st;
        }

        public object Query5()
        {
            return null;
        }

        // TODO 6
        // Вычисление агрегатных функций при помощи методов расширения и лямбда-выражений

        // TODO 6.1
        // Использование метода расширения с делегатом
        // Анонимный метод-делегат возвращает данные для обработки методом Max

        public int Query61Example()
        {
            return
            (
            from st in context.STUDENTS_ONE
            select st
            ).Max(
            delegate (STUDENTS_ONE Student)
            {
                return (int)Student.UNDONE_LABS;
            }
            );
        }

        public double Query61()
        {
            return -1;
        }

        // TODO 6.2 
        // Использование метода лямбда-выражений

        public int Query62Example()
        {
            return
            (
            from st in context.STUDENTS_ONE
            select st
            ).Max(stt => (int)stt.UNDONE_LABS);
        }

        public double Query62()
        {
            return -1;
        }

        // TODO 7
        // Комплексные выражения в соответсвии с вариантом задания

        public object ComplexQuery1()
        {
            return null;
        }

        public object ComplexQuery2()
        {
            return null;
        }

        public object ComplexQuery3()
        {
            return null;
        }

        /* Вопросы для подготовки:
         * Что такое LINQ-запрос?
         * Когда и как выполняется LINQ-запрос? Что такое отложенное выполнение?
         * Какие объекты могут быть источниками данных для LINQ-запроса?
         * Что обозначают термины:
         * - проекция
         * - анонимный тип
         * - метод расширения
         * - лямбда-выражение
         */


    }// class DataAccess
}