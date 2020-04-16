using System;
using System.Collections.Generic;
using FacultyOfPhysics.Model;


namespace FacultyOfPhysics.DAL
{
    class GroupInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GroupContext>
    {
        protected override void Seed(GroupContext context)
        {
            

            var groups = new List<Group>
            {
            new Group{ NameGroup = "Радиофизика" },
            new Group{ NameGroup = "Микроэлектроника" },
            new Group{ NameGroup = "Общая физика" },
            };

            groups.ForEach(s => context.Group.Add(s));

            var students = new List<Student>
            {
            new Student{FirstName="Игорь",LastName="Коток", Patronymic = "Иванович", GroupId = 1},
            new Student{FirstName="Сергей",LastName="Антоннов", Patronymic = "Игоревич", GroupId = 1},
            new Student{FirstName="Валерий",LastName="Петров", Patronymic = "Валерьевич", GroupId = 1},
            new Student{FirstName="Инакентий",LastName="Сидоров", Patronymic = "Анатольевич", GroupId = 2},
            new Student{FirstName="Игнатий",LastName="Веселов", Patronymic = "Владимирович", GroupId = 2},
            new Student{FirstName="Петр",LastName="Гнутов", Patronymic = "Васильевич", GroupId = 2},
            new Student{FirstName="Алексей",LastName="Сухоруков", Patronymic = "Дмитриевич", GroupId = 3},
            new Student{FirstName="Игорь",LastName="Колесников", Patronymic = "Алексеевич", GroupId = 3},
            new Student{FirstName="Дмитрий",LastName="Фролов", Patronymic = "Игоревич", GroupId = 3},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            



        }

    }
}
