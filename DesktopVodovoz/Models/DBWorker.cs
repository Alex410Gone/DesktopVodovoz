using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopVodovoz.Models
{
    /// <summary>
    /// Содержит основные команды для работы с БД
    /// </summary>

    public class DBWorker
    {
        //Выводит подразделения:
        //[id] [namedivision] [secondname] [firstname] [middlename]
        public List<ModelDivision> GetDivisions()
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                var query = db.division.ToList().Join(db.users,
                        u => u.iduser,
                        d => d.iduser,
                        (u, d) => new ModelDivision
                        {
                            iddivision = u.iddivision,
                            namedivision = u.namedivision,
                            iduser = u.iduser,
                            fullname = $"{d.secondname} {d.firstname} {d.middlename}"
                        }).ToList();
                return query;
            }
        }

        // Добавление в таблицу новое подразделение:
        //
        public void AddDivision(string namedivision, int? idleader)
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                division division = new division
                {
                    namedivision = namedivision.Trim(),
                    iduser = idleader
                };

                db.division.Add(division);
                db.SaveChanges();
            }
        }

        // Обновление подразделения
        //
        public void UpdateDivision(int iddivision, string namedivision, int? idleader)
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                var p = db.division.Where(d => d.iddivision == iddivision).FirstOrDefault();
                p.namedivision = namedivision.Trim();
                p.iduser = idleader;

                db.SaveChanges();
            }
        }


        //Выводит пользователей:
        //[id] [secondname] [firstname] [middlename] [gender] [datebirth] [namedivision]
        public List<ModelUser> GetUsers()
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                var query = db.users.ToList().Join(db.division,
                        u => u.iddivision,
                        d => d.iddivision,
                        (u, d) => new ModelUser
                        {
                            iduser = u.iduser,
                            firstname = u.firstname,
                            secondname = u.secondname,
                            middlename = u.middlename,
                            gender = u.gender,
                            datebirth = u.datebirth.ToString("d"),
                            division = d.namedivision,
                            fullname = $"{u.secondname} {u.firstname} {u.middlename}"
                        }).ToList();

                return query;
            }
        }

        // Добавление в таблицу нового Пользователя
        //
        public void AddUser(string secondname, string firstname, string middlename, string gender , DateTime birthdate, int? iddivision)
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                users users = new users
                {
                    secondname = secondname.Trim(),
                    firstname = firstname.Trim(),
                    middlename = middlename.Trim(),
                    datebirth = birthdate,
                    gender = gender.ToString(),
                    iddivision = iddivision
                };

                db.users.Add(users);
                db.SaveChanges();
            }
        }

        // Обновление пользователя
        //
        public void UpdateUser(int id, string secondname, string firstname, string middlename, string gender, DateTime birthdate, int? iddivision)
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                var p = db.users.Where(d => d.iduser == id).FirstOrDefault();
                p.secondname = secondname.Trim();
                p.firstname = firstname.Trim();
                p.middlename = middlename.Trim();
                p.gender = gender;
                p.datebirth = birthdate;
                p.iddivision = iddivision;

                db.SaveChanges();
            }
        }


        // Выводит Товар
        //
        public List<ModelOrder> GetOrders()
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                var query = db.orders.ToList().Join(db.users,
                        u => u.iduser,
                        d => d.iduser,
                        (u, d) => new ModelOrder
                        {
                            idorder = u.idorders,
                            nameproduct = u.nameproduct,
                            iduser = u.iduser,
                            fullname = $"{d.secondname} {d.firstname} {d.middlename}"
                        }).ToList();
                return query;
            }
        }

        // Добавление в таблицу новый Товар
        //
        public void AddOrder(string nameproduct, int? iduser)
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                orders orders = new orders
                {
                    nameproduct = nameproduct.Trim(),
                    iduser = iduser
                };

                db.orders.Add(orders);
                db.SaveChanges();
            }
        }

        // Обновление Товар
        //
        public void UpdateOrder(int idorder, string nameproduct, int? iduser)
        {
            using (dbvodovozEntities db = new dbvodovozEntities())
            {
                var p = db.orders.Where(d => d.idorders == idorder).FirstOrDefault();
                p.nameproduct = nameproduct;
                p.iduser = iduser;

                db.SaveChanges();
            }
        }
    }
}
