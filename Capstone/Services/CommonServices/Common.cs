using ModelAuto.Models;
using ModelAuto;
using Services.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Services.ResponseModel.OrgnizationModel;

namespace Services.CommonServices
{
    public class CommonImpl : ICommon
    {
        #region"List"
        public string autoGenCode3character(string tableName, string firstCode)
        {
            try
            {
                string query = "select Code from " + tableName + " order by Id desc";
                DataTable dt = DAOContext.GetDataBySql(query);
                DataRow lastRow = dt.Rows[0];
                string Code = lastRow["Code"].ToString();

                if (Code != null)
                {
                    string number = Code.Substring(Code.Length - 3);
                    return firstCode + (Convert.ToInt32(number) + 1).ToString("000");
                }
                else
                {
                    return firstCode + "001";
                }
            }
            catch
            {
                return firstCode + "001";
            }
        }

        public string autoGenCode(string tableName, int? rank, string nameColumn, int? parentID)
        {
            try
            {
                if (rank > 1 && parentID != null && parentID > 0)
                {
                    string sql = "select count(*) COUNT from " + tableName + " where parentId= " + parentID;
                    DataTable dt = DAOContext.GetDataBySql(sql);
                    DataRow lastRow = dt.Rows[0];
                    int count = Convert.ToInt32(lastRow["COUNT"]) + 1;
                    string sql2 = "select code from " + tableName + " where id =" + parentID;
                    DataTable dt2 = DAOContext.GetDataBySql(sql2);
                    DataRow lastRow2 = dt2.Rows[0];
                    string code = lastRow2["code"].ToString() + "." + count;
                    return code;
                }
                else
                {
                    string sql = "select CODE from " + tableName + " where " + nameColumn + " = 1 order by id desc";
                    DataTable dt = DAOContext.GetDataBySql(sql);
                    DataRow lastRow = dt.Rows[0];
                    int code = Convert.ToInt32(lastRow["CODE"]);
                    return (code + 1).ToString();
                }
            }
            catch
            {
                return "1";
            }

        }


        #endregion


        #region Get by ID
        public OrgnizationResponseServices getOrgByID(int id)
        {
            OrgnizationResponseServices obj = new OrgnizationResponseServices();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    var query = from o in context.Orgnizations.Where(x => x.Id == id)
                                from na in context.Nations.Where(x => x.Id == o.NationId).DefaultIfEmpty()
                                from pr in context.Provinces.Where(x => x.Id == o.ProvinceId).DefaultIfEmpty()
                                from di in context.Provinces.Where(x => x.Id == o.DistrictId).DefaultIfEmpty()
                                from wa in context.Wards.Where(x => x.Id == o.WardId).DefaultIfEmpty()
                                from em in context.Employees.Where(x => x.Id == o.ManagerId).DefaultIfEmpty()
                                from o2 in context.Orgnizations.Where(x => x.Id == o.ParentId).DefaultIfEmpty()
                                select new OrgnizationResponseServices
                                {
                                    id = o.Id,
                                    name = o.Name,
                                    code = o.Code,
                                    address = o.Address,
                                    nationID = o.NationId,
                                    nationName = na.Name,
                                    provinceID = o.ProvinceId,
                                    provinceName = pr.Name,
                                    districtID = o.DistrictId,
                                    districtName = di.Name,
                                    wardID = o.WardId,
                                    wardName = wa.Name,
                                    managerID = o.ManagerId,
                                    parentID = o.ParentId,
                                    email = o.Email,
                                    fax = o.Fax,
                                    dissolutionDate = o.DissolutionDate.Value.Year==1000?null: o.DissolutionDate,
                                    effectDate = o.Effectdate,
                                    numberBusiness = o.NumberBussines,
                                    phoneNumber = o.Phone,
                                    parentName= o2.Name,
                                    managerName= em.FullName,
                                    Level= o.Level,
                                    office= o.Address,
                                    note= o.Note
                                };
                    return query.FirstOrDefault();
                }
            }
            catch
            {
                
            }
            return obj;
        }

        public Title getTitleByID(int id)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Title obj = context.Titles.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }
        public Position getPositionByID(int id)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Position obj = context.Positions.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }
        #endregion




        #region "Get OtherList type"    

        public List<OtherListType> GetOtherListType()
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<OtherListType> list = context.OtherListTypes.Where(x => x.Status == -1).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<OtherListType>();
            }
        }
        #endregion




        #region EMAIL
        public bool sendMail(MailDTO mailobj)
        {

            MailMessage mail = new MailMessage();
            // you need to enter your mail address
            mail.From = new MailAddress(mailobj.fromMail);

            //To Email Address - your need to enter your to email address
            mail.To.Add(mailobj.tomail);

            mail.Subject = mailobj.subject;

            //you can specify also CC and BCC - i will skip this
            if (mailobj.listCC.Count > 0)
            {
                foreach (var item in mailobj.listCC)
                {
                    mail.CC.Add(item);
                }
            }

            if (mailobj.listBC.Count > 0)
            {
                foreach (var item in mailobj.listBC)
                {
                    mail.Bcc.Add(item);
                }
            }

            mail.IsBodyHtml = true;
            mail.Body = mailobj.content;


            //create SMTP instant

            //you need to pass mail server address and you can also specify the port number if you required
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            //Create nerwork credential and you need to give from email address and password
            NetworkCredential networkCredential = new NetworkCredential(mailobj.fromMail, mailobj.pass);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = networkCredential;
            smtpClient.Port = 25; // this is default port number - you can also change this
            smtpClient.EnableSsl = true; // if ssl required you need to enable it
            smtpClient.Send(mail);
            return true;

        }
        #endregion


        #region "Cryptography"

        public string sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        #endregion



        public int getTotalRecord(string tableName, bool isRank)
        {
            string query = isRank == true ? ("select count(*) COUNT from " + tableName + " where Rank=1") : ("select count(*) COUNT from " + tableName);
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int COUNT = Convert.ToInt32(lastRow["COUNT"]);
            return COUNT;
        }


        #region OtherList

        public List<OtherList> GetOtherList(string code, int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    OtherListType type = context.OtherListTypes.Where(x => x.Code.Trim().ToLower().Equals(code)).FirstOrDefault();
                    List<OtherList> list = context.OtherLists.Where(x => x.TypeId == type.Id).OrderByDescending(x => x.Id).Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<OtherList>();
            }
        }


        public List<OtherList> GetOtherListsCombo(string code, int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    OtherListType type = context.OtherListTypes.Where(x => x.Code.Trim().ToLower().Equals(code)).FirstOrDefault();
                    List<OtherList> list = context.OtherLists.Where(x => x.TypeId == type.Id && x.Status == -1).OrderByDescending(x => x.Id).Skip(index * size).Take(size).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<OtherList>();
            }
        }
        public bool InsertOtherList(OtherList T)
        {
            ICommon c = new CommonImpl();
            try
            {
                OtherList tobj = new OtherList();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Other_List", "OT");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.Atribute1 = T.Atribute1;
                tobj.Atribute2 = T.Atribute2;
                tobj.Atribute3 = T.Atribute3;
                tobj.TypeId = T.TypeId;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.OtherLists.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyOtherList(OtherList T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    OtherList tobj = context.OtherLists.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteOtherList(List<int> list)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        OtherList tobj = new OtherList();
                        tobj = context.OtherLists.Where(x => x.Id == item).FirstOrDefault();
                        context.OtherLists.Remove(tobj);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ActiveOrDeActiveOtherList(List<int> list, int status)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        OtherList tobj = new OtherList();
                        tobj = context.OtherLists.Where(x => x.Id == item).FirstOrDefault();
                        tobj.Status = status;
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion



    }
}
