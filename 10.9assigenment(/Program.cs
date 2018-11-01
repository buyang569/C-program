/*
                                by yangshao(by)  
                                2018/10/22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test3._7
{
    class MyDArray
    {
        private double[] DetialDep;
        private double[] DetialWith;
        public MyDArray(int length)
        {
            this.DetialDep = new double[length];
            this.DetialWith = new double[length];
        }
        //获取数组
        public double[] DetialDep1
        {
            get { return DetialDep; }
        }
        public double[] DetialWith1
        {
            get { return DetialWith; }
        }
    }
    class MySArray
    {
        private string[] DetialDepT;
        private string[] DetialWithT;
        public MySArray(int length)
        {
            this.DetialDepT = new string[length];
            this.DetialWithT = new string[length];
        }
        //获取数组
        public string[] DetialDepT1
        {
            get { return DetialDepT; }
        }
        public string[] DetialWithT1
        {
            get { return DetialWithT; }
        }
    }
    class AccountInfor
    {
        private int AccountNum;
        private string Name;
        private int Time;
        private int ID;
        private double Asset = 0;
        public int i = 0, j = 0;
        MyDArray dou = new MyDArray(100);
        MySArray str = new MySArray(100);

        //public AccountInfor(string name, int id)
        //{
        // this.Name = name;
        //this.ID = id;
        //}
        public double Asset1
        {
            get { return Asset; }
            set { Asset = value; }
        }
        public string Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        public void openAccount(string name,int id)
        {
            Name = name;
            ID = id;
            Random rd = new Random((int)DateTime.Now.Ticks);
            AccountNum = rd.Next(1000);
            Console.WriteLine(name);
            Console.WriteLine(id);
            Console.WriteLine("卡号：{0,10}", AccountNum);
        }


        public void deposit(double money)//存款
        {
            Asset += money;
            dou.DetialDep1[i] = money;
            // Console.WriteLine("{0}", dou.DetialDep1[0]);

            DateTime time = new DateTime();
            time = DateTime.Now;
            str.DetialDepT1[i] = time.ToString();

            i++;
            // Console.WriteLine("{0}",Asset);
        }


        public void withdrawal(double money)//取款
        {
          
                Asset -= money;
                dou.DetialWith1[j] = money;

                DateTime time = new DateTime();
                time = DateTime.Now;
                str.DetialWithT1[j] = time.ToString();

                j++;
        }
        public void searchBalance()//查询余额并返回余额
        {
            Console.WriteLine("账户余额为{0}", Asset);
        }
        public void searchDetial()//查询明细并返回明细
        {
            for (int m = 0; m < i; m++)
            {
                Console.WriteLine(str.DetialDepT1[m]);
                Console.WriteLine("存入{0,6}", dou.DetialDep1[m]);
            }
            for (int n = 0; n < j; n++)
            {
                Console.WriteLine(str.DetialWithT1[n]);
                Console.WriteLine("取出{0,6}", dou.DetialWith1[n]);
            }
        }
        public void closeAccount(ref string name, ref int AccountNum)
        {
            name = null;
            AccountNum = 0;
        }
        public bool judge(int inter)
        {
            if (inter == AccountNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            
            List<AccountInfor> account = new List<AccountInfor>();   
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请输入所办业务序号：");
                Console.WriteLine("1 开    户");
                Console.WriteLine("2 存    钱");
                Console.WriteLine("3 取    钱");
                Console.WriteLine("4 查询余额");
                Console.WriteLine("5 查询明细");
                Console.WriteLine("6 销    户");

                string i = Convert.ToString(Console.ReadLine());
                Console.Clear();
                switch (i)
                {
                    case "1"://开户
                        {
                            AccountInfor acc = new AccountInfor();
                            Console.WriteLine("请输入开户人姓名：");
                            string name = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("请输入开户人身份证号：");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (name == null || id == 0)
                            {
                                Console.WriteLine("输入有误，请重新输入");
                                break;
                            }
                            else
                            {
                                acc.openAccount(name, id);
                                account.Add(acc);
                            }
                            break;
                        }
                    case "2": //存钱
                        {
                            AccountInfor person = null;
                            bool a=false;
                            double money = 0;
                            Console.Clear();
                            Console.WriteLine("请输入卡号");
                            int accountnum = Convert.ToInt16(Console.ReadLine());
                            if (Convert.ToString(accountnum)=="-1") break;
                            foreach (AccountInfor acc in account)
                            {
                                if (acc.judge(accountnum)==true)
                                {
                                    person = acc;
                                    a = true;
                                }
                            }
                            if (a)
                            {
                                Console.WriteLine("欢迎，{0}",person.Name1);
                                Console.WriteLine("请输入所存金额");
                                money = Convert.ToDouble(Console.ReadLine());
                                person.deposit(money);
                                Console.WriteLine("存款成功");
                            }
                            else
                            {
                                Console.WriteLine("查询无此账户");
                            }
                            break;
                        }
                    case "3": //取钱
                        {
                            AccountInfor person = null;
                            bool a = false;
                            double money1 = 0;
                            Console.Clear();
                            Console.WriteLine("请输入卡号");
                            int accountnum = Convert.ToInt16(Console.ReadLine());
                            if (Convert.ToString(accountnum) == "-1") break;
                            foreach (AccountInfor acc in account)
                            {
                                if (acc.judge(accountnum) == true)
                                {
                                    person = acc;
                                    a = true;
                                }
                            }
                            if (a)
                            {
                                Console.WriteLine("欢迎，{0}", person.Name1);
                                Console.WriteLine("请输入所取金额");
                                money1 = Convert.ToInt16( Console.ReadLine());
                                if (money1 <= person.Asset1)
                                {
                                    person.withdrawal (money1);
                                    Console.WriteLine("取款成功");
                                }
                                else
                                {
                                    Console.WriteLine("余额不足，请重试");
                                }
                            }
                            else
                            {
                                Console.WriteLine("查询无此账户");
                            }
                            break;
                        }
                    case "4": //查询余额
                        {
                            AccountInfor person = null;
                            bool a = false;
                            Console.Clear();
                            Console.WriteLine("请输入卡号");
                            int accountnum = Convert.ToInt16(Console.ReadLine());
                            if (Convert.ToString(accountnum) == "-1") break;
                            foreach (AccountInfor acc in account)
                            {
                                if (acc.judge(accountnum) == true)
                                {
                                    person = acc;
                                    a = true;
                                }
                            }
                            if (a)
                            {
                                person.searchBalance();
                            }
                            else
                            {
                                Console.WriteLine("查询无此账户");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "5"://明细查询
                        {
                            AccountInfor person = null;
                            bool a = false;
                            Console.Clear();
                            Console.WriteLine("请输入卡号");
                            int accountnum = Convert.ToInt16(Console.ReadLine());
                            if (Convert.ToString(accountnum) == "-1") break;
                            foreach (AccountInfor acc in account)
                            {
                                if (acc.judge(accountnum) == true)
                                {
                                    person = acc;
                                    a = true;
                                }
                            }
                            if (a)
                            {
                                person.searchDetial();
                            }
                            else
                            {
                                Console.WriteLine("查询无次账户");
                            }
                            break;
                        }
                    case "6":
                        {
                            AccountInfor person = null;
                            bool a = false;
                            int judge = 0;
                            Console.Clear();
                            Console.WriteLine("请输入卡号");
                            int accountnum = Convert.ToInt16(Console.ReadLine());
                            if (Convert.ToString(accountnum) == "-1") break;
                            foreach (AccountInfor acc in account)
                            {
                                if (acc.judge(accountnum) == true)
                                {
                                    person = acc;
                                    a = true;
                                }
                            }
                            if (a)
                            {
                                Console.WriteLine("请确认是否销户");
                                Console.WriteLine("确认请键入：1");
                                Console.WriteLine("取消请键入：2");
                                judge = Convert.ToInt16( Console.ReadLine());
                                if (judge == 1)
                                {
                                    account.Remove(person);
                                    Console.WriteLine("销户成功");
                                }
                                else if (judge == 2)
                                {
                                    Console.WriteLine("取消销户");
                                }
                                else
                                {
                                    Console.WriteLine("请重新操作");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("查询无次账户");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("错误输入代码，请重新输入");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
