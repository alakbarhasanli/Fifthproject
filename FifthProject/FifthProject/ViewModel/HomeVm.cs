using Project.BL.DTOs;
using Project.DAL.Entities;
using System.Collections;

namespace FifthProject.ViewModel
{
    public class HomeVm
    {
        public ICollection<Travel> travels { get; set; }
        public ICollection<Category> categories { get; set; }


    }
}
