using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Total.DealerCom.BL.StandingDryLogs;
using Total.DealerCom.Core;
using Total.DealerCom.Core.ViewModels;
using Total.DealerCom.DataAccessLayer.DataAccess;
using Total.DealerCom.DataAccessLayer.Facade.Interfaces;
using Total.DealerCom.Web.Controllers;
using Total.DealerCom.Web.Http;
using Total.DealerCom.Web.Models;
namespace Total.DealerCom.Web.Http
{
    public class StandingDryLogController : ApiController
    {
        public  static IEnumerable<IssueResultVm> _issuesList;
        static StandingDryLogController()
        {
            _issuesList = BaseApiController.FacadeRepository.GetIssueFacade().Report(new Issue()).Select(x => new IssueResultVm
            {
                ProductName = x.ProductName,
                SOCName = x.SOCName,
                DealerName = x.DealerName,
                DateDryFrom = x.DateDryFrom,
                DateDryTo = x.DateDryTo,
                IDRequestStatus = x.RequestStatusName,
                TankName = x.TankName,
                OutletNo = x.UserId,
                IDInstance = x.IDInstance

            }).ToArray();
        }
        [HttpGet]
        public PagedCollection<IssueResultVm> GetAll(int? page, int? pageSize)
        {
            var currPage = page.GetValueOrDefault(0);
            var currPageSize = pageSize.GetValueOrDefault(0);
            var paged = _issuesList.Skip(currPage * currPageSize)
                .Take(currPageSize)
                .ToArray();

            var totalCount = _issuesList.Count();

            return new PagedCollection<IssueResultVm>()
            {
                Page = currPage,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / currPageSize),
                Items = paged

            };
        }

        // GET: api/Clubs/pageSize/pageNumber/orderBy(optional)
        [Route("{pageSize:int}/{pageNumber:int}/{orderBy:alpha?}")]
        public IHttpActionResult FetchAll(int pageSize, int pageNumber, string orderBy = "")
        {
            var totalCount = _issuesList.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var issueList = _issuesList;


            var clubs = issueList.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            var result = new
            {
                TotalCount = totalCount,
                totalPages = totalPages,
                Clubs = clubs
            };

            return Ok(result);
        }

        [HttpGet]
        public IEnumerable<IssueResultVm> ExportToExcel()
        {
            return _issuesList;
        }


        [HttpGet]
        public IEnumerable<IssueResult> FetchIssues(Issue issue,string UserId,string IDTank,string IDSoc,string IDProduct,string IDRequestStatus,string OutletNo,string DateDryFrom,string  DateDryTo)
        {
            IEnumerable<IssueResult> data = BaseApiController.FacadeRepository.GetIssueFacade().Search(issue);
            return data;
        }

        [HttpGet]
        public StandingDrySearchVM GetIssueLists()
        {
            var all_lists=new StandingDrySearchLists();
            var model = new StandingDrySearchVM
            {
                DealerUserList = all_lists.PopulateDealerUserList(),
                ProductList = all_lists.PopulateProductList(),
                RequestStatuslist = all_lists.PopulateRequestStatusList(),
                Soclist = all_lists.PopulateSOCList(),
                Tanklist = all_lists.PopulateTankList()                
            };
            return model;           
        }
        [HttpGet]
        public IssueResult GetIssueInstance(string id) {

            IssueResult result = BaseApiController.FacadeRepository.GetIssueFacade().GetInstance(id);
            return result;
        }
      
        }
    }

