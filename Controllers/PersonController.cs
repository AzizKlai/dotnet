using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tp3sqlite.Models;

namespace tp3sqlite.Controllers;

public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }




    [Route("Person")]
    [Route("Person/All")]
    public ViewResult All([FromQuery(Name = "page")] string page)
    {  
        personal_info ps=new personal_info();
        List<Person> l=new List<Person>();
        l=ps.GetAllPerson();
        
        return View(l);
    
    }

       
    [Route("Person/{id?}")]
    public IActionResult Personid(int id)
    { personal_info ps=new personal_info();
       Person p= ps.GetPerson(id);
       if(p==null){
        TempData["warning"]="   Invalid id ";
       return RedirectToAction("All");
       }
        return View(p);
    }
       
    [Route("Person/Search")]
    public IActionResult Search()
    { List<Person> l=new List<Person>();
      return View(l);
    }    
    
    [Route("Person/Search")]
    [HttpPost]
    public IActionResult Search(String firstname, String country)
    { personal_info ps=new personal_info();
        List<Person> l=new List<Person>();
        l=ps.GetPersonBy(firstname,country);
        if(l.Count==0){ TempData["warning"]="No Data found !" ;}
        if(l.Count==1){
          return  RedirectToAction("Personid",new {id=""+l[0].id});
        }
        else 
        return View(l);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {   
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
