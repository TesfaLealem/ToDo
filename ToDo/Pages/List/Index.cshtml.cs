#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Pages.List
{
    public class IndexModel : PageModel
    {
        private readonly ToDo.Data.ToDoContext _context;

        public IndexModel(ToDo.Data.ToDoContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Status { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScheduleStatus { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> statusQuery = from m in _context.Schedule
                                            orderby m.ID
                                            select m.Status;

                var title = from s in _context.Schedule
                             select s;
                var status = from s in _context.Schedule
                             select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                title = title.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScheduleStatus))
            {
                status = status.Where(s => s.Status == ScheduleStatus);
            }
            Status = new SelectList(await statusQuery.Distinct().ToListAsync());

            Schedule = await _context.Schedule.ToListAsync();
        }
    }
}
