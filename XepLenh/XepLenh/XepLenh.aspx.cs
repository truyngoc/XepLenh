using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XepLenh
{
    public partial class XepLenh : System.Web.UI.Page
    {
        public List<GH_Info> ListGH
        {
            get
            {
                if (HttpContext.Current.Session["LIST_GH"] != null)
                {
                    return HttpContext.Current.Session["LIST_GH"] as List<GH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["LIST_GH"] = value; }
        }

        public List<PH_Info> ListPH
        {
            get
            {
                if (HttpContext.Current.Session["LIST_PH"] != null)
                {
                    return HttpContext.Current.Session["LIST_PH"] as List<PH_Info>;
                }
                return null;
            }
            set { HttpContext.Current.Session["LIST_PH"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.ListPH == null)
                {
                    this.ListPH = InitializePH();
                }

                if (this.ListGH == null)
                {
                    this.ListGH = InitializeGH();
                }

                grvGH.DataSource = this.ListGH;
                grvGH.DataBind();

                grvPH.DataSource = this.ListPH;
                grvPH.DataBind();
            }
        }

        public List<PH_Info> InitializePH()
        {
            List<PH_Info> lstPH = new List<PH_Info>();
            //string[] codeid = { "0101", "0102", "0201", "0202", "010101" };
            string[] codeid = { "0101", "0102", "0201", "0202", "010101","010102","020101","020102" };

            for (var i = 1; i <= 8; i++)
            {
                PH_Info ph = new PH_Info();
                ph.ID = i;
                ph.CodeId = codeid[i - 1];
                ph.CreateDate = DateTime.Now;
                ph.Status = 0;

                //Random r = new Random();
                //var total = r.Next(1,5);
                //System.Threading.Thread.Sleep(100);

                var total = 3;

                ph.Amount = total;
                ph.CurrentAmount = total;

                lstPH.Add(ph);
            }
            return lstPH;   
        }

        public List<GH_Info> InitializeGH()
        {
            List<GH_Info> lstGH = new List<GH_Info>();
            string[] codeid = { "0", "01", "02" };

            for (var i = 1; i <= 3; i++)
            {
                GH_Info gh = new GH_Info();
                gh.ID = i;
                gh.CodeId = codeid[i - 1];
                gh.CreateDate = DateTime.Now;
                gh.Status = 0;

                Random r = new Random();
                decimal total = r.Next(5);
                //decimal total = 5;
                total = total + (total * 10) / 100;

                gh.Amount = total;
                gh.CurrentAmount = 0;

                lstGH.Add(gh);
            }
            return lstGH;
        }

        protected void btnXepLenh_Click(object sender, EventArgs e)
        {
            STATEMENT_Info statement = new STATEMENT_Info { ID = 1, DateCreate = DateTime.Today, UserCreate = "ADMIN", StatementCode=DateTime.Today.ToShortDateString().Replace(@"/","_") + "_1" };
            List<STATEMENT_Info> lstStatement = new List<STATEMENT_Info>();
            lstStatement.Add(statement);
            grvStatement.DataSource = lstStatement;
            grvStatement.DataBind();

            List<STATEMENT_DETAIL_Info> lstStatementDetail = new List<STATEMENT_DETAIL_Info>();
            STATEMENT_DETAIL_Info statementDetail;

            var _ListPH = InitializePH();
            var _ListGH = InitializeGH();

            foreach (var p in _ListPH)
            {
                // kiem tra con GH de cho nua ko -> neu ko con thi dung lai
                int iGH_remaining = _ListGH.Where(g => g.Amount != g.CurrentAmount).Count();
                // lap den khi PH cho di het
                while (p.CurrentAmount != 0 && iGH_remaining > 0)
                {
                    foreach (var g in _ListGH)
                    {
                        // chi duyet tren nhung thang GH chua nhan du                       
                        if (g.Amount != g.CurrentAmount)
                        {
                            if (g.CurrentAmount == 0)
                            {                                
                                // duyet lan dau
                                if (p.CurrentAmount - g.Amount <= 0)
                                {
                                    // TH: PH thieu cho GH                                                                      
                                    // ----------------- //
                                    statementDetail = new STATEMENT_DETAIL_Info();
                                    statementDetail.Statement_ID = 1;
                                    statementDetail.PH_ID = p.ID;
                                    statementDetail.GH_ID = g.ID;
                                    statementDetail.Amount = p.CurrentAmount;
                                    statementDetail.DateCreate = DateTime.Now;
                                    // ----------------- //                                    
                                    lstStatementDetail.Add(statementDetail);                                    
                                                                        
                                    
                                    if (g.CurrentAmount == 0)
                                    {
                                        if (g.Amount - p.CurrentAmount != 0)
                                        {
                                            g.CurrentAmount = g.Amount - p.CurrentAmount;   // neu PH voi 1 GH moi
                                        }
                                        else
                                        {
                                            g.CurrentAmount = g.Amount;
                                        }
                                    }
                                    else
                                        g.CurrentAmount = g.Amount - p.Amount;  // neu PH het luon 1 lan

                                    p.CurrentAmount = 0;

                                    break;
                                }
                                else
                                {
                                    // TH: PH thua cho GH
                                    // TH: PH thieu cho GH                                                                      
                                    // ----------------- //
                                    statementDetail = new STATEMENT_DETAIL_Info();
                                    statementDetail.Statement_ID = 1;
                                    statementDetail.PH_ID = p.ID;
                                    statementDetail.GH_ID = g.ID;
                                    statementDetail.Amount = g.Amount;
                                    statementDetail.DateCreate = DateTime.Now;
                                    // ----------------- //   
                                    // ----------------- //                                    
                                    lstStatementDetail.Add(statementDetail);    


                                    g.CurrentAmount = g.Amount;

                                    if (p.CurrentAmount != p.Amount)
                                        p.CurrentAmount = p.CurrentAmount - g.Amount;   // neu da PH roi thi lay current - g.amount
                                    else
                                        p.CurrentAmount = p.Amount - g.Amount;  // neu chua PH
                                }
                            }
                            else
                            {
                                // duyet tiep neu chua gh du?
                                if (p.CurrentAmount - g.CurrentAmount <= 0)
                                {
                                    // van chua du
                                    // ----------------- //
                                    statementDetail = new STATEMENT_DETAIL_Info();
                                    statementDetail.Statement_ID = 1;
                                    statementDetail.PH_ID = p.ID;
                                    statementDetail.GH_ID = g.ID;
                                    statementDetail.Amount = p.CurrentAmount;
                                    statementDetail.DateCreate = DateTime.Now;
                                    // ----------------- //
                                    lstStatementDetail.Add(statementDetail);

                                    p.CurrentAmount = 0;
                                    g.CurrentAmount = g.CurrentAmount - p.Amount;

                                    break;
                                }
                                else
                                {
                                    // du roi
                                    // ----------------- //
                                    statementDetail = new STATEMENT_DETAIL_Info();
                                    statementDetail.Statement_ID = 1;
                                    statementDetail.PH_ID = p.ID;
                                    statementDetail.GH_ID = g.ID;
                                    statementDetail.Amount = g.CurrentAmount;
                                    statementDetail.DateCreate = DateTime.Now;
                                    // ----------------- //
                                    lstStatementDetail.Add(statementDetail);

                                    p.CurrentAmount = p.Amount - g.CurrentAmount;
                                    g.CurrentAmount = g.Amount;

                                    break;
                                }
                            }
                        }                        
                    }
                    iGH_remaining = _ListGH.Where(g => g.Amount != g.CurrentAmount).Count();
                }
                                
            }


            var lstPH_Thua = _ListPH.Where(m => m.CurrentAmount != 0).ToList();
            var lstGH_Thua = _ListGH.Where(m => m.CurrentAmount != m.Amount).ToList();


            grvStatementList.DataSource = lstStatementDetail;
            grvStatementList.DataBind();

            grvPH_Thua.DataSource = lstPH_Thua;
            grvPH_Thua.DataBind();

            grvGH_Thua.DataSource = lstGH_Thua;
            grvGH_Thua.DataBind();
        }
    }
}