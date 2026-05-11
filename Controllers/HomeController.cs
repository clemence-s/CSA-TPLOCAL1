using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //Code reading of the xml files provide -- on retourne l'id de la page et on passe en argument la liste d'avis à afficher
                        OpinionList avis = new OpinionList();
                        List<Opinion> opinions = avis.GetAvis("XlmFile/DataAvis.xml");
                        return View(id,opinions);

                    case "Form":
                        //call the Form view with data model empty -- on retourne l'id de la page
                        return View(id);

                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidationFormulaire(Form validform)
        {
            //test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            if (!ModelState.IsValid)
            {
                //Si le modèle est invalide, on retourne la vue du formulaire
                //sur lequel sera affiché les messages d'erreur, avec la fonction Index
                return Index("Form");
            }
            //Sinon on retourne la page de validation
            return View(validform);

        }
    }
}