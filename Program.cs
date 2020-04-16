using System;
using System.Collections.Generic;
using System.Linq;
using FacultyOfPhysics.Model;
using FacultyOfPhysics.DAL;

namespace FacultyOfPhysics
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("База данных студентов физического факультета");
            Console.WriteLine("Идет загрузка данных о студентах, пожалуйста подождите");
            do
            {
                ShowAllFaculty();
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - добавить нового студента");
                Console.WriteLine("2 - удалить студента");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    choice = 5;
                }
                switch(choice)
                {
                    case 1:
                        AddNewStudent();
                        break;
                    case 2:
                        DeleteStudent();
                        break;
                    default:
                        Console.WriteLine("Команда неизвестна");
                        break;
                }

                
                Console.WriteLine("Если хотите выйти, нажмите - 3");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    choice = 5;
                }

            } while(choice != 3);

            
        }

        static void ShowAllFaculty()
        {
            using(GroupContext groupContext = new GroupContext())
            {
                List<Group> groups = groupContext.Group.ToList();
                if (groups == null)
                {
                    Console.WriteLine("На данный момент групп на ФизФаке нет");
                }
                else 
                {
                    foreach (var group in groups)
                    {
                        
                        if (group.Students.Count == 0)
                        {
                            Console.WriteLine("В группу \"{0}\" студенты еще не зачислены", group.NameGroup);
                        }
                        else 
                        {   Console.WriteLine();
                            Console.WriteLine("Название группы \"{0}\" ({1})", group.NameGroup, group.Students.Count);
                            foreach (var student in group.Students.OrderBy(p => p.LastName))
                            {
                                Console.WriteLine("{0} {1} {2}", student.LastName, student.FirstName, student.Patronymic);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        static void AddNewStudent()
        {

            using (GroupContext groupContext = new GroupContext())
            {   
                var groups = groupContext.Group.ToList();
                if (groups.Count == 0)
                {
                    Console.WriteLine("На данный момент ни одной группы не открыто");
                    Console.WriteLine("Поробуйте войти позже...");
                }
                else
                {
                    Student student = new Student();
                    Console.WriteLine("Введите номер группы, в который будет учиться студент");
                    Console.WriteLine("Список групп");
                    foreach (var group in groups)
                    {
                        if (group.GroupId != groups.Max(p => p.GroupId))
                        {
                            Console.Write("{0} - {1}, ", group.GroupId, group.NameGroup);
                        }
                        else
                        {
                            Console.Write("{0} - {1}.", group.GroupId, group.NameGroup);
                        }
                    
                    }
                    Console.WriteLine();
                    try
                    {
                        student.GroupId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите Фамилию");
                        student.LastName = Console.ReadLine();
                        Console.WriteLine("Введите Имя");
                        student.FirstName = Console.ReadLine();
                        Console.WriteLine("Введите Отчество");
                        student.Patronymic = Console.ReadLine();

                    
                        groupContext.Students.Add(student);
                        groupContext.SaveChanges();
                        Console.WriteLine("Добавление студента прошло успешно");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошел сбой. Причина сбоя: {0}", ex.Message);
                    }
                }
           }
        }


        static void DeleteStudent()
        {
            int choice;
            using (GroupContext groupContext = new GroupContext())
            {
                
                List<Group> groups = groupContext.Group.ToList();
                if (groups.Count == 0)
                {
                    List<Student> students = groupContext.Students.ToList();
                    if (students == null)
                    {
                        Console.WriteLine("Студентов, доступных для удаления, нет");
                        Console.WriteLine("Поробуйте войти позже...");
                    }
                    else
                    {
                        Console.WriteLine("Введите номер студента, которого хотите удалить");
                        foreach (var student in students.OrderBy(p => p.LastName))
                        {
                            Console.WriteLine("{0} - {1} {2} {3}", student.StudentId, student.LastName, student.FirstName, student.Patronymic);

                        }
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                       
                            groupContext.Students.Remove(students.Where(p => p.StudentId == choice).FirstOrDefault());
                            groupContext.SaveChanges();
                            Console.WriteLine("Удаление студента прошло успешно");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Произошел сбой. Причина сбоя: {0}", ex.Message);
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("Введите номер группы, из которой хотите удалить студента");
                    Console.WriteLine("Список групп");
                    foreach (var group in groups)
                    {
                        if (group.GroupId != groups.Max(p => p.GroupId))
                        {
                            Console.Write("{0} - {1}, ", group.GroupId, group.NameGroup);
                        }
                        else
                        {
                            Console.Write("{0} - {1}.", group.GroupId, group.NameGroup);
                        }

                    }
                    Console.WriteLine();
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        choice = -1;
                    }
                    List<Student> students = groupContext.Students.Where(p=>p.GroupId == choice).ToList();
                    if (students.Count == 0)
                    {
                        Console.WriteLine("Студентов, доступных для удаления, нет");
                        Console.WriteLine("Поробуйте войти позже...");
                    }
                    else
                    {
                        Console.WriteLine("Введите номер студента, которого хотите удалить");
                        foreach (var student in students.OrderBy(p => p.LastName))
                        {
                            Console.WriteLine("{0} - {1} {2} {3}", student.StudentId, student.LastName, student.FirstName, student.Patronymic);

                        }
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                            groupContext.Students.Remove(students.Where(p => p.StudentId == choice).FirstOrDefault());
                            groupContext.SaveChanges();
                            Console.WriteLine("Удаление студента прошло успешно");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Произошел сбой. Причина сбоя: {0}", ex.Message);
                        }

                    }

                }

            }

        }


    }
}
