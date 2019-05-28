using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User()
            {
                ID = 111,
                Name = "张一",
                Address = "上海市某某区",
                Phone = "13547878787",
                Age = 30,
                Sex = "男",
                SchID = 1
            };
            User user2 = new User()
            {
                ID = 112,
                Name = "李小二",
                Address = "上海市某某区",
                Phone = "13547878783",
                Age = 30,
                Sex = "女",
                SchID = 1
            };
            User user3 = new User()
            {
                ID = 113,
                Name = "张三",
                Address = "上海市某某区",
                Phone = "13547878784",
                Age = 30,
                Sex = "男",
                SchID = 1
            };
            User user4 = new User()
            {
                ID = 114,
                Name = "李四",
                Address = "上海市某某区",
                Phone = "13547878785",
                Age = 30,
                Sex = "男",
                SchID = 1
            };
            List<User> userlist = new List<User>(4) { user1, user2, user3, user4 };
            List<School> Schlist = new List<School>() {
new School(1,"武汉大学"),new School(2,"华中科技大学"),new School(3,"华中师范大学")
};
            //求和
            //var sum = userlist.Where(a => { return a.ID > 0; }).Sum(a => a.ID);

            var sum = (from a in userlist where a.ID > 0 select a.ID).Sum();
            Console.WriteLine(sum);
            //最大值
            var max = userlist.Max(a => a.ID);
            Console.WriteLine(max);
            //最小值
            var min = userlist.Min(a => a.ID);
            Console.WriteLine(min);

            //循环输出
            userlist.ForEach(a =>
            {
                if (a.Age > 20)
                {
                    Console.WriteLine(a.ID);
                }

            });

            //筛选
            var user = userlist.Where(a => a.ID == 114).Single();
            //筛选所有男性用户
            var templist = userlist.Where(a => a.Sex == "男").ToList();
            //排序  根据ID逆序
            templist = userlist.OrderByDescending(a => a.ID).ToList();
            //升序
            templist = userlist.OrderBy(a => a.ID).ToList();

            //分组
            var lookup = userlist.ToLookup(a => a.Sex);
            foreach (var item in lookup)
            {
                Console.WriteLine(item.Key);
                foreach (var sub in item)
                {
                    Console.WriteLine("\t\t" + sub.Name + " " + sub.Age);
                }
            }
            //另一种
            var dic = userlist.GroupBy(a => a.Sex);
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key);
                foreach (var sub in item)
                {
                    Console.WriteLine("\t\t" + sub.Name + " " + sub.Age);
                }
            }

            //联接
            var temp = from usertemp in userlist
                       join sch in Schlist on usertemp.SchID equals sch.SchID
                       select new { Id = usertemp.ID, Name = usertemp.Name, Age = usertemp.Age, Schname = sch.SchName };

            //类型查找
            List<object> objlist = new List<object>() { 1, "2", false, "s", new User() { ID = 1, Name = "xx" } };

            IEnumerable<string> query1 = objlist.OfType<string>();

            foreach (string fruit in query1)
            {
                Console.WriteLine(fruit);
            }


            //查找深层嵌套
            //初始化数据


            Company ChinaMobile = new Company("中国移动", userlist);
            Company ChinaUnicom = new Company("中国联通", userlist);
            List<Company> companylist = new List<Company>() { ChinaMobile, ChinaUnicom };
            //找出2个公司所有女性成员
            var selectlist = companylist.SelectMany(a => a.Users).Where(b => b.Sex == "女");
            foreach (var item in selectlist)
            {
                Console.WriteLine(item.Name + ":" + item.Sex);
            }

            foreach (Company c in companylist)
            {

                foreach (var item in c.Users)
                {
                    if (item.Sex == "女")
                    {
                        Console.WriteLine(item.Name + ":" + item.Sex);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
