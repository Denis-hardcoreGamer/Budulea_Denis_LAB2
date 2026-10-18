using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Budulea_Denis_LAB2.Pages
{
    public class IndexModel : PageModel
    {
        public object Book { get; internal set; }

        public void OnGet()
        {

        }
    }
}
