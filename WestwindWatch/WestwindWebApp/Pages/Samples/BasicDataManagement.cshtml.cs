using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WestwindWebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        //create bound properties that are directly tied to a control on the form
        //bound properties have the data automatically transferred from the control
        //      into the property

        [BindProperty]
        public int Num { get; set; } //this is tied to the control use the asp-for
        [BindProperty]
        public string FavouriteCourse { get; set; }
        [BindProperty]
        public string Comments { get; set; }

        //Annotation TempData is required IF you are processing multiple requests (OnPost 
        //      followed by OnGet) to retain data within the property
        //[TempData]
        public string FeedBack { get; set; }



        public void OnGet()
        {
            //executes for a Get request
            //the first time the page is requested an automatic Get request is sent
            //execellent "event" to use to do any intialization to your web page display
            //      as the page is shown for the first time
        }

        public void OnPost()
        {
            //process the OnPost request of the form (method="post")
            //the returndatatype can be void or IActionResult
            //OnPost request is the request from a <button> that has NOT indicated a
            //      specific process Post using the asp-page-handler
            //logic that your wish to accomplish should be isolated to the actions
            //  desired for the button
            FeedBack = $"Number {Num}, Course {FavouriteCourse} Comments {Comments}";
        }

        public void OnPostA()
        {
            //process the OnPost request of the form (method="post")
            //this method is called due to the helper-tag on the form button
            //the "string" used on the helper-tag asp-page-handler="string" is
            //   add to the OnPost method name
            FeedBack = $"Button A was pressed";
        }
        public void OnPostB()
        {
            //process the OnPost request of the form (method="post")
            //this method is called due to the helper-tag on the form button
            //the "string" used on the helper-tag asp-page-handler="string" is
            //   add to the OnPost method name
            FeedBack = $"Button B was pressed";
        }
    }
}
