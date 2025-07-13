using MotorShop_Project.Model.Classes;
using System.ComponentModel.DataAnnotations;

namespace Motorshop_Project.MVC.ViewModels
{
    public class OrderVm
    {
        public OrderVm()
        {
            
        }
        public OrderVm(Order order, List<int> selectedExtraIds)
        {
            Order = order;
            SelectedExtraIds = selectedExtraIds;
        }

        public Order Order { get; set; } = new Order();

        [Display(Name = "Select Extras")]
        public List<int> SelectedExtraIds { get; set; } = new();
    }
}
