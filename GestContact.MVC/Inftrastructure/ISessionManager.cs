using GestContact.MVC.Models.Client.Entities;

namespace GestContact.MVC.Inftrastructure
{
    public interface ISessionManager
    {
        SessionCustomer Customer { get; set; }
    }
}