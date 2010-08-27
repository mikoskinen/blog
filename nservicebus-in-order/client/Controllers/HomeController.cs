using System.Web.Mvc;
using messages;
using NServiceBus;

namespace client.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessages()
        {
            for (int i = 0; i < 50; i++)
            {
                var createUserMessage = new CreateUserCommand() { UserId = i };
                MvcApplication.Bus.Send(createUserMessage);

                var changeEmailMessage = new ChangeUserEmailAddressCommand() {UserId = i};
                MvcApplication.Bus.Send(changeEmailMessage);
            }

            return View("Index");
        }

        public ActionResult SendMessagesInOrder()
        {
            for (int i = 0; i < 50; i++)
            {
                var createUserMessage = new CreateUserCommand() { UserId = i };
                var changeEmailMessage = new ChangeUserEmailAddressCommand() { UserId = i };

                MvcApplication.Bus.Send(new IMessage[] {createUserMessage, changeEmailMessage});
            }

            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
